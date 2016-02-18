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
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float     hp;

    private Text     hpTxt;
    private Attacker attacker;
    private bool     isHard;
        
    void Start ()
    {
        isHard   = PlayerPrefsManager.GetDifficulty() >= PlayerPrefsManager.MAX_DIFF / 2;
        attacker = GetComponent<Attacker>(); 
        hpTxt    = GetComponentInChildren<Text>();

        DisplayHP(hp);         
    }
	
	public bool DealDamage(float damage)
	{
		hp -= damage;

        DisplayHP(hp);
        		
		if(hp <= 0)
		{
            //Demolish could set inside a death animation to play 
            DemolishObject();
            return false;
		}

        return true;
	}
	
	public void DemolishObject()
	{
		Destroy(gameObject);
	}

    void DisplayHP(float health)
    {
        if (attacker)
            return;

        if (!isHard)
            hpTxt.text = "HP: " + health;       
        else
            hpTxt.text = "";
    }
}
