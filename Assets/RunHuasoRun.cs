using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHuasoRun : MonoBehaviour
{
    public int score;
    public float elapsedTime;
    public GameObject playerGameObject;
    public bool endlessLevel;
    public static RunHuasoRun instance;
    public AudioSource musicPlayer;

    public AudioClip musicLose;
    public Canvas winUI;
    public Canvas loseUI;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (endlessLevel)
        {
            elapsedTime += Time.deltaTime;
            playerGameObject.transform.position -= playerGameObject.transform.right * Time.deltaTime;
        }
    }

    private void Start()
    {
        if (endlessLevel)
        {
            StartCoroutine(AddScoreInTime());
        }
    }

    //Coroutine for the Endless Runner level
    public IEnumerator AddScoreInTime()
    {
        yield return new WaitForSeconds(5);
        score += 10;
        if(playerGameObject.GetComponent<HuasoScript>().alive)
        StartCoroutine(AddScoreInTime());
    }

    public void LevelEnd(bool win)
    {
        Destroy(playerGameObject.GetComponent<Rigidbody2D>());
        Destroy(FindObjectOfType<UIINfo>().gameObject);
        playerGameObject.GetComponent<HuasoScript>().alive = false;
        playerGameObject.GetComponent<Animator>().SetBool("Idle", true);
        playerGameObject.GetComponent<Animator>().SetBool("Running", false);
        if(win)
        {
            playerGameObject.GetComponent<Animator>().SetBool("Win", true);
            winUI.GetComponent<EoGCanvas>().UpdateValues();
            winUI.enabled = true;
            loseUI.enabled = false;            
        }
        else
        {
            musicPlayer.clip = musicLose;
            musicPlayer.loop = false;
            musicPlayer.Play();
            playerGameObject.GetComponent<HuasoScript>().alive = false;
            playerGameObject.GetComponent<Animator>().SetBool("Idle", true);
            playerGameObject.GetComponent<Animator>().SetBool("Running", false);
            playerGameObject.GetComponent<SpriteRenderer>().enabled = false;
            loseUI.GetComponent<EoGCanvas>().UpdateValues();
            winUI.enabled = false;
            loseUI.enabled = true;
        }



    }


}
