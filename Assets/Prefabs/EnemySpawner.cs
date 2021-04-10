using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject spawnPoint;
    public bool variableLocation;
    bool multiples = false;
    [ConditionalHide("variableLocation")]
    public float xMaxLeftOffset;
    [ConditionalHide("variableLocation")]
    public float xMaxRightOffset;


    [Header("Endless Runner Settings")]
    [ConditionalHide("multiples")]
    public GameObject[] enemiesToSpawn;
    [ConditionalHide("multiples")]
    [Range(0,2)]
    public int randomness;
    [Range(1,5)]
    public float difficulty = 1;


    GameObject far, near;

    private void Start()
    {
        multiples = RunHuasoRun.instance.endlessLevel;
        if (RunHuasoRun.instance.endlessLevel)
        {
            StartCoroutine(SpawnerCoroutine(0));
        }
    }


    public void Update()
    {
        if(RunHuasoRun.instance.endlessLevel)
        {
            difficulty = Time.timeSinceLevelLoad / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
        }
    }

    public IEnumerator SpawnerCoroutine(int nextEnemyIndex)
    {
        yield return new WaitForSeconds(5 / difficulty);
        GameObject instancedEnemy = Instantiate(enemiesToSpawn[nextEnemyIndex]);
        if (variableLocation)
        {
            instancedEnemy.transform.position = new Vector3(Random.Range(spawnPoint.transform.position.x - xMaxLeftOffset, spawnPoint.transform.position.x + xMaxRightOffset), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        }
        else
        {
            instancedEnemy.transform.position = spawnPoint.transform.position;
        }

        if (!far) far = instancedEnemy;
        else if (!near) near = instancedEnemy;

        switch(randomness)
        {
            case 0:
                nextEnemyIndex = Random.Range(0, enemiesToSpawn.Length);
                break;
            case 1:
                if (enemiesToSpawn.Length > 1)
                {
                    do
                    {
                        nextEnemyIndex = Random.Range(0, enemiesToSpawn.Length);
                    } while (enemiesToSpawn[nextEnemyIndex].GetComponent<EnemyID>().id == near.GetComponent<EnemyID>().id);
                }
                else
                {
                    randomness = 0;
                }
                break;
            case 2:
                if (enemiesToSpawn.Length > 2)
                {
                    do
                    {
                        nextEnemyIndex = Random.Range(0, enemiesToSpawn.Length);
                    } while (enemiesToSpawn[nextEnemyIndex].GetComponent<EnemyID>().id == near.GetComponent<EnemyID>().id || enemiesToSpawn[nextEnemyIndex].GetComponent<EnemyID>().id == far.GetComponent<EnemyID>().id);
                }
                else
                {
                    randomness = 1;
                }
                break;
        }

        StartCoroutine(SpawnerCoroutine(nextEnemyIndex));

    }



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
