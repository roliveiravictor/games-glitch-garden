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

public class Shooter : MonoBehaviour {

    public GameObject   projectile;
    public GameObject   gun;

    private GameObject  projectilesParent;
    private Animator    animator;

    void Start ()
    {
        animator          = GetComponent<Animator>();
        projectilesParent = GameObject.Find("Projectiles");

        if (!projectilesParent)
        {
            projectilesParent = new GameObject("Projectiles");
            projectilesParent.transform.position = Vector3.zero;
        }
	}
	
	void Update ()
    {
        if(AttackerAhead())
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
	}

    //Check if exists attacker ahead to start shooting
    bool AttackerAhead()
    {
        GameObject spawner = GameObject.Find("Lane " + this.transform.position.y);

        if (spawner)
        {
            //If there is an attacker behind a spawned defender, he won't fire
            foreach(Transform attacker in spawner.transform)
                if (spawner.transform.childCount >= 0 && attacker.transform.position.x > this.transform.position.x) 
                    return true;
                else
                    return false;
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProj = Instantiate(projectile) as GameObject;

        newProj.transform.parent = projectilesParent.transform;
        newProj.transform.position = gun.transform.position;
    }
}
