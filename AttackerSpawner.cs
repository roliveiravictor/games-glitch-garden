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

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackers;
	
	void Update ()
    {
        foreach (GameObject thisAttacker in attackers)
            if (isTimeToSpawn(thisAttacker))
                Spawn(thisAttacker);
	}

    bool isTimeToSpawn(GameObject enemy)
    {
        float spawnDelay = enemy.GetComponent<Attacker>().seenEverySecond;
        float spawnsPerSecond = (1 / spawnDelay) * Time.deltaTime / 5F;

        spawnsPerSecond = spawnsPerSecond * PlayerPrefsManager.GetDifficulty() / 2F;

        return Random.value < spawnsPerSecond;
    }

    void Spawn(GameObject enemy)
    {
        GameObject spawned = Instantiate(enemy) as GameObject;

        spawned.transform.parent = this.transform;
        spawned.transform.position = this.transform.position;
    }
}
