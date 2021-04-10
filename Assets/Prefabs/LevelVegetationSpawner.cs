using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVegetationSpawner : MonoBehaviour
{

    public GameObject[] vegetationPool;
    float difficulty = 1;
    public float originalFrecuency = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            difficulty = Time.timeSinceLevelLoad / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
        }

    }

    public IEnumerator Spawn()
    {
       GameObject instancedObject = Instantiate(vegetationPool[Random.Range(0, vegetationPool.Length)],transform);
        instancedObject.transform.position = new Vector2(instancedObject.transform.position.x, instancedObject.transform.position.y + Random.Range(-0.3f, 0));
        instancedObject.GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2) == 1 ? true : false;
        instancedObject.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-8, -3);
        yield return new WaitForSeconds(originalFrecuency / difficulty);
        StartCoroutine(Spawn());
    }
}
