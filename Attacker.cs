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

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    //Short information displayed on unity for designers
    [Tooltip ("Average number of seconds between appearances")]
    public float       seenEverySecond;

    private float 		currentSpeed;       
	private GameObject	currentTarget;
    private Animator    animator;
	
	void Start ()
	{
		rigidbody2D.isKinematic = true;

        animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
        //Make attacker walk
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
            animator.SetBool("isAttacking", false);
	}
		
    //Set walk speed
	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}
	
	//Called from animator at attack action
	public void StrikeCurrentTarget(float damage)
	{
		if(currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			
			if(health)
				health.DealDamage(damage);
		}
	}	
	
	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}
}
