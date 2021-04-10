using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int score;

    private void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;

            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !collision.isTrigger)
        {
            StartCoroutine(PlaySound());
            RunHuasoRun.instance.score += score;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;            
        }

        if (collision.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }


    public IEnumerator PlaySound()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
