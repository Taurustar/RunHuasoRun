﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    public EnemyConfigObject configObject;
    bool moo;


    // Start is called before the first frame update
    void Start()
    {
        moo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<HuasoScript>().health -= configObject.damage;
            if(configObject.destructible)
            {
                Destroy(gameObject);
            }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        moo = false;
    }
}