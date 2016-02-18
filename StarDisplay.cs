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

[RequireComponent (typeof (Text))]
public class StarDisplay : MonoBehaviour {

    public enum  Status { SUCCESS, FAILURE};

    private Text starTxt;
    private int  stars;

    void Start ()
    {
        starTxt = GetComponent<Text>();
        stars   = 100;

        UpdateDisplay();
    }

    //Use stars to spawn defender
    public Status UseStars (int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }

    //Make user aware of his star points
    public void SetStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        starTxt.text = "Stars: \n" + stars.ToString();
    }
}
