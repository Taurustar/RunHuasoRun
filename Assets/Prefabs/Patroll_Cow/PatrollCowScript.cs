using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollCowScript : MonoBehaviour
{
    [Tooltip("Configuration Scriptable Object")]
    public EnemyConfigObject configObject;
    [Tooltip("it's mooing")]
    bool moo;
    float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        moo = false;
        StartCoroutine(Patrolling());
       
    }

    public IEnumerator Patrolling()
    {
        int direction = 1;
        if (Random.Range(0, 2) == 1) 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            direction = 1;
        } 
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            direction = -1;
        } 
        yield return new WaitForSeconds(Random.Range(1, 6));
        float patrollSeconds = 0;
        gameObject.GetComponent<Animator>().SetBool("Idle", false);
        gameObject.GetComponent<Animator>().SetBool("Walk", true);
        do
        {
            patrollSeconds += Time.deltaTime;
            if (RunHuasoRun.instance.endlessLevel)
            {
                transform.position += transform.right * Time.deltaTime * configObject.speed * (difficulty * 2) * direction;
            }
            else
            {
                transform.position += transform.right * Time.deltaTime * configObject.speed * direction;
            }
            yield return new WaitForEndOfFrame();
        } while (patrollSeconds < 3);

        gameObject.GetComponent<Animator>().SetBool("Idle", true);
        gameObject.GetComponent<Animator>().SetBool("Walk", false);

        StartCoroutine(Patrolling());
    }

    // Update is called once per frame
    void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
        
            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<HuasoScript>().health -= configObject.damage;
            if (collision.collider.GetComponent<HuasoScript>().health <= 0)
            {
                collision.collider.GetComponent<HuasoScript>().health = 0;
                collision.collider.GetComponent<HuasoScript>().alive = false;
                RunHuasoRun.instance.LevelEnd(false);
            }
            if (configObject.destructible)
            {
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !moo && collision.isTrigger)
        {
            moo = true;
            GetComponent<AudioSource>().PlayOneShot(configObject.spawnSound);
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        moo = false;
    }*/
}
