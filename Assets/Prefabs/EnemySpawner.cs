using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject spawnPoint;
    public bool variableLocation;

    [ConditionalHide("variableLocation")]
    public float xMaxLeftOffset;
    [ConditionalHide("variableLocation")]
    public float xMaxRightOffset;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !collision.isTrigger)
        {
            GameObject instancedEnemy = Instantiate(enemy);
            if(variableLocation)
            {
                instancedEnemy.transform.position = new Vector3(Random.Range(spawnPoint.transform.position.x - xMaxLeftOffset, spawnPoint.transform.position.x + xMaxRightOffset), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            }
            else
            {
                instancedEnemy.transform.position = spawnPoint.transform.position;
            }

            gameObject.GetComponent<Collider2D>().enabled = false;
            
        }
    }

}
