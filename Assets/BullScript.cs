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
            if (configObject.destructible)
            {
                Destroy(gameObject);
            }
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
