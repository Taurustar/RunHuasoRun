using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuasoScript : MonoBehaviour
{

    public PlayerConfigObject configObject;
    public int health;
    public float speed;

    public bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        health = configObject.startingHealth;
        speed = configObject.speed;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * -speed);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (!jumping)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed * 300);
                jumping = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
        {
            jumping = false;
        }
    }
}
