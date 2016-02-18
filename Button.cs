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

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public        GameObject defenderPrefab;

    private       Button[] buttonArray;
    private       Text     costTxt;

	void Start ()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costTxt     = GetComponentInChildren<Text>();
        
        //Set star cost on button for each defender type
        if(costTxt)
            costTxt.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }

    //Set selected defender with a different color
    void OnMouseDown()
    {
        foreach(Button thisButton in buttonArray)
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
