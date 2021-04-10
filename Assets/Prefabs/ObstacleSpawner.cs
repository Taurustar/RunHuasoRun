using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public bool variableLocation;
  
    [ConditionalHide("variableLocation")]
    public float xMaxLeftOffset;
    [ConditionalHide("variableLocation")]
    public float xMaxRightOffset;
    public GameObject[] obstaclesToSpawn;
    [Range(0, 2)]
    public int randomness;
    [Range(1, 5)]
    public float difficulty = 1;
    public float variability;

    public GameObject empanadaPrefab;


    GameObject far, near;

    private void Start()
    {     
        StartCoroutine(SpawnerCoroutine(0));
        StartCoroutine(SpawnerEmpanadas());
    }

    public IEnumerator SpawnerEmpanadas()
    {
        if (Random.Range(0, 2) == 1)
        {
            GameObject empanada = Instantiate(empanadaPrefab);
            empanada.transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
        }

        yield return new WaitForSeconds(Random.Range(1.0f, 10.0f));

        StartCoroutine(SpawnerEmpanadas());
    }

    public IEnumerator SpawnerCoroutine(int nextObstacleIndex)
    {
        float frecuency = 10 / difficulty;
        variability = Random.Range(0, frecuency);

        if(Random.Range(0,2) == 1)
        yield return new WaitForSeconds(frecuency - variability);
        else
            yield return new WaitForSeconds(frecuency + variability);


        
       

            GameObject instancedEnemy = Instantiate(obstaclesToSpawn[nextObstacleIndex]);
        if (variableLocation)
        {
            instancedEnemy.transform.position = new Vector3(Random.Range(transform.position.x - xMaxLeftOffset, transform.position.x + xMaxRightOffset), transform.position.y, transform.position.z);
        }
        else
        {
            instancedEnemy.transform.position = transform.position;
        }

        if (!far) far = instancedEnemy;
        else if (!near) near = instancedEnemy;

        switch (randomness)
        {
            case 0:
                nextObstacleIndex = Random.Range(0, obstaclesToSpawn.Length);
                break;
            case 1:
                if (obstaclesToSpawn.Length > 1)
                {
                    do
                    {
                        nextObstacleIndex = Random.Range(0, obstaclesToSpawn.Length);
                    } while (obstaclesToSpawn[nextObstacleIndex].GetComponent<EnemyID>().id == near.GetComponent<EnemyID>().id);
                }
                else
                {
                    randomness = 0;
                }
                break;
            case 2:
                if (obstaclesToSpawn.Length > 2)
                {
                    do
                    {
                        nextObstacleIndex = Random.Range(0, obstaclesToSpawn.Length);
                    } while (obstaclesToSpawn[nextObstacleIndex].GetComponent<EnemyID>().id == near.GetComponent<EnemyID>().id || obstaclesToSpawn[nextObstacleIndex].GetComponent<EnemyID>().id == far.GetComponent<EnemyID>().id);
                }
                else
                {
                    randomness = 1;
                }
                break;
        }

        StartCoroutine(SpawnerCoroutine(nextObstacleIndex));

    }

}
