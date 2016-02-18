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

public class PlayerPrefsManager : MonoBehaviour {

    //Max difficulty is settle here because it's called on Health script
    public const float  MAX_DIFF            = 3F;

	const string        MASTER_VOLUME_KEY 	= "master_volume";
	const string        DIFFICULTY_KEY 	    = "difficulty";
	const string        LEVEL_KEY 			= "level_unlocked_";

	public static void SetMasterVolume(float volume)
	{
		if(volume >= 0F && volume <= 1F)
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		else
			Debug.LogError("Master volume out of range");
	}
	
	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
    //If the game had different levels would be used to save player's progression
	public static void UnlockLevel(int level)
	{
		if(level <= Application.levelCount - 1)
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		else
			Debug.LogError("Unkown level to be unlocked");
	}
	
	public static bool IsLevelUnlocked(int level)
	{
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if(level <= Application.levelCount - 1)
			return isLevelUnlocked;
		else
		{
			Debug.LogError("Unkown level to be unlocked");
			return false;
		}
	}
	
	public static void SetDifficulty(float diff)
	{
		if(diff >= 1F && diff <= MAX_DIFF)
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
		else
			Debug.LogError("Difficulty out of range");
	}
	
	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
