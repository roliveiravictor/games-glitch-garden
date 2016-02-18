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

public class Projectile : MonoBehaviour {

    public float       pr_Speed;
    public float       pr_Damage;
    public GameObject  blood;

    private GameObject bloodsParent;

	void Start ()
    {
        bloodsParent = GameObject.Find("Bloods");

        if (!bloodsParent)
        {
            bloodsParent = new GameObject("Bloods");
            bloodsParent.transform.position = Vector3.zero;
        }
    }
	
	void Update ()
    {
        transform.Translate(Vector3.right * pr_Speed * Time.deltaTime);

        //Should cache blood in a real case instead of instantiate/destroy many times
        Component[] particles = bloodsParent.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem thisParticle in particles)
            if (!thisParticle.IsAlive())
                Destroy(thisParticle.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         GameObject obj = col.gameObject;

        //Leave method if not colliding with defender
        if (obj.GetComponent<Defender>())
            return;

        Health hp = obj.GetComponent<Health>();

        if(hp)
        {
            bool requireBlood = hp.DealDamage(pr_Damage);

            //Check if it's to instantiate blood effect or destroy attacker
            if(requireBlood)
            {
                Quaternion rotation = Quaternion.Euler(0F, 90F, 0F);
                Vector3 pos = obj.transform.position;

                pos = new Vector3(pos.x - 0.4F, pos.y - 0.1F, pos.z);

                GameObject bloodEffect = Instantiate(blood, pos, rotation) as GameObject;

                bloodEffect.transform.SetParent(bloodsParent.transform);
            }

            Destroy(gameObject);
        }              
    }
}
