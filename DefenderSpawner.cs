/**********************************************************************/
/*                                                                    */
/*                        Glitch Garden  							  */
/*																	  */
/*		This is the code from a game created to practice my           */
/*      Unity and Game Development skills. Most of this was           */
/*      made watching Ben Tristem's tutorial at Udemy.                */
/*                                                                    */
/*      For more information please visit:                            */
/*      https://www.udemy.com/unitycourse/                            */
/*                                                                    */
/*                                                                    */
/**********************************************************************/

using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public GameObject   starsEffect;

    private GameObject  defendersParent;
    private GameObject  starFail;
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay     = GameObject.FindObjectOfType<StarDisplay>();
        defendersParent = GameObject.Find("Defenders");

        if (!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
            defendersParent.transform.position = Vector3.zero;
        }
    }

    void OnMouseDown()
    {
        GameObject  defender = Button.selectedDefender;
        Vector2     rawPos   = CalculateWorldPoint();
        Vector2     spawnPos = SnapToGrid(rawPos);

        if(defender)
        {
            int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;
            bool isInstantiable = starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS;

            //Check if has enough stars to afford defender
            if (isInstantiable)
            {
                SpawnDefender(spawnPos, defender);
            }
            else
            {
                //Prevent from spawning different star particles (effect of not enough stars) - instantiate just one and change its position when needed
                if (!starFail)
                {
                    starFail = Instantiate(starsEffect, spawnPos, Quaternion.identity) as GameObject;
                }
                else
                {
                    starFail.transform.position = spawnPos;
                    starFail.GetComponent<ParticleSystem>().Play();
                }
            }
        }    
    }

    void SpawnDefender(Vector2 spawnPos, GameObject defender)
    {
        defender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity) as GameObject;
        defender.transform.SetParent(defendersParent.transform);
    }

    Vector2 SnapToGrid(Vector2 rawPos)
    {
        float x = Mathf.RoundToInt(rawPos.x);
        float y = Mathf.RoundToInt(rawPos.y);

        return new Vector2(x, y);
    }

    //Acquires clicked mouse position based on world point coordinates
    Vector2 CalculateWorldPoint()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector3 pos = new Vector3(mouseX, mouseY, 10F);

        return Camera.main.ScreenToWorldPoint(pos);
    }
}
