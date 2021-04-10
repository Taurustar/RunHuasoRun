using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{  

    // Update is called once per frame
    void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;

            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
