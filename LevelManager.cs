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

public class LevelManager : MonoBehaviour 
{	
	private float splashTime = 2.5F;
    private bool  isPause    = false;

	void Start()
	{
		if(Application.loadedLevel == 0)
			Invoke ("LoadNextLevel", splashTime);
	}

	//Load level by its name
	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}
	
	//Load level by index sequence - Build order related
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}

    public void PauseGame()
    {
        isPause = !isPause;

        if (isPause)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
