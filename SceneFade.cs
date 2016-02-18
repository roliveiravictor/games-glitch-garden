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

//Just a class to make scenes' transition smooth
public class SceneFade : MonoBehaviour {

	public float  fade_speed;
	public float  fade_inTime;
	
	private Image panel;

	void Start ()
	{
		panel = GetComponent<Image>();	
	}

	void Update () 
	{
		FadeToClear();
	}
	
	void FadeToClear ()
	{
		if(Time.timeSinceLevelLoad < fade_inTime)
		{
			// Lerp the colour of the texture between itself and transparent.
			panel.color = Color.Lerp(panel.color, Color.clear, fade_speed * Time.deltaTime);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
