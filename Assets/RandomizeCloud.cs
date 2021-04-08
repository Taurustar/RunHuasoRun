using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,Random.Range(0.3f, 1.0f));
        float scaleFactor = Random.Range(0.12f, 0.18f);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
