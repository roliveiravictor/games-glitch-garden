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

public class GameTimer : MonoBehaviour {

    public float            levelSeconds;

    private Slider          slider;
    private AudioSource     audioSource;
    private LevelManager    levelManager;
    private GameObject      winLabel;
    private GameObject      stars;
    private GameObject      pause;
    private bool            isLevelEnd = false;

    void Start ()
    {
        levelSeconds    = levelSeconds * (PlayerPrefsManager.GetDifficulty() / 2F);

        winLabel        = GameObject.Find("You Won");
        stars           = GameObject.Find("Stars");
        pause           = GameObject.Find("Pause");
        levelManager    = GameObject.FindObjectOfType<LevelManager>();
        slider          = GetComponent<Slider>();
        audioSource     = GetComponent<AudioSource>();

        winLabel.SetActive(false);
    }
	
	void Update ()
    {
        //Set running time
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);

        //if time is over - play quest complete sound, load win screen, disable all other objects visibility except win label
        if(Time.timeSinceLevelLoad >= levelSeconds && !isLevelEnd)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isLevelEnd = true;

            winLabel.SetActive(true);
            gameObject.SetActive(false);
            stars.SetActive(false);
            pause.SetActive(false);

            //Another way to handle win condition would be tagging every object in scene to be destroyed
            GameObject buttons = GameObject.Find("Buttons");
            GameObject defenders = GameObject.Find("Defenders");
            GameObject projectiles = GameObject.Find("Projectiles");
            GameObject spawners = GameObject.Find("Spawners");

            buttons.SetActive(false);
            defenders.SetActive(false);
            projectiles.SetActive(false);
            spawners.SetActive(false);
        }
	}

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
