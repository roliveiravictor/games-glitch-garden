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

public class OptionsController : MonoBehaviour {

	public Slider 			volumeSlider;
	public Slider 			difficultySlider;
	public LevelManager		levelManager;
	
	private MusicManager	musicManager;

	void Start () 
	{
		musicManager           = GameObject.FindObjectOfType<MusicManager>();	
		volumeSlider.value     = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update () 
	{
		musicManager.SetVolume(volumeSlider.value);
	}
	
    //Save player preferences and exit from options
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		
		levelManager.LoadLevel("01A Start");
	}
	
    //Set options default
	public void SetDefaults()
	{
		volumeSlider.value = 0.5F;
		difficultySlider.value = 2F;
	}
}
