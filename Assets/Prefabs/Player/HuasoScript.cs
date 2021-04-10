using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuasoScript : MonoBehaviour
{
    [Tooltip("Configuration Scriptable Object")]
    public PlayerConfigObject configObject;
    [Tooltip("HP inherited from Scriptable Object")]
    public int health;
    [Tooltip("Player Speed inherited Scriptable Object")]
    public float speed;
    [Tooltip("is the player alive?")]
    public bool alive;
    [Tooltip("is the player jumping?")]
    public bool jumping;
    [Tooltip("checks when the player gets hurt")]
    public bool beignHurt;
    // Start is called before the first frame update
    void Start()
    {
        health = configObject.startingHealth;
        speed = configObject.speed;
        jumping = false;
        alive = true;
        beignHurt = false;
        if (RunHuasoRun.instance.endlessLevel)
        {
            GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("Running", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            //Controls
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (!RunHuasoRun.instance.endlessLevel)
                    GetComponent<SpriteRenderer>().flipX = true;
                transform.position -= transform.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                if (!jumping)
                {
                    jumping = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed * 25);                    
                }
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                
                GetComponent<Animator>().SetBool("Idle", false);
                GetComponent<Animator>().SetBool("Running", true);
            }
            else
            {
                if (!RunHuasoRun.instance.endlessLevel)
                {
                    GetComponent<Animator>().SetBool("Idle", true);
                    GetComponent<Animator>().SetBool("Running", false);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Enemy")
        {
            StartCoroutine(Hurt());
        }
        if (collision.collider.tag == "EndGame")
        {
            RunHuasoRun.instance.LevelEnd(true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            StartCoroutine(JumpingCoroutine());
        }
    }

    public IEnumerator JumpingCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        jumping = false;
        
    }


    public IEnumerator Hurt()
    {
        beignHurt = true;
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
        beignHurt = false;
    }
}
