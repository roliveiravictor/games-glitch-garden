﻿/**********************************************************************/
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

public class LoserCollider : MonoBehaviour {

    private LevelManager levelManager;

	void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        levelManager.LoadLevel("03B Lose");
    }
}
