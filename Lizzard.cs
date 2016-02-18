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

//Whenever a Lizzard script is added to an object, an Attacker script also needs to be attached
[RequireComponent (typeof (Attacker))]
public class Lizzard : MonoBehaviour {
	
	private Animator anim;
    private Attacker attacker;

	void Start () 
	{
		anim     = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{		
		GameObject obj = col.gameObject;
		
		//Leave method if not colliding with defender
		if(!obj.GetComponent<Defender>())
			return;
		
		anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
	}
}
