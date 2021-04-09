using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !collision.isTrigger)
        {
            StartCoroutine(PlaySound());
            RunHuasoRun.instance.score += score;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;            
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
