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
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position += transform.right * speed * Time.deltaTime;
        } 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (!jumping)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed * 150);
                jumping = true;
            }
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Idle", true);
            GetComponent<Animator>().SetBool("Running", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
        {
            jumping = false;
        }
        if (collision.collider.tag == "Enemy")
        {
            StartCoroutine(Hurt());
        }
    }


    public IEnumerator Hurt()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.4f);
    }
}
