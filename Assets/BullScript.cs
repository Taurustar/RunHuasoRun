using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullScript : MonoBehaviour
{

    public EnemyConfigObject configObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<HuasoScript>().health -= configObject.damage;
            if (collision.collider.GetComponent<HuasoScript>().health <= 0)
            {
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

    private void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(configObject.spawnSound);
    }

    private void Update()
    {
        transform.position -= transform.right * configObject.speed * Time.deltaTime;
    }

}
