using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHuasoRun : MonoBehaviour
{
    public int score;
    public GameObject playerGameObject;
    public bool endlessLevel;
    public static RunHuasoRun instance;

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
        yield return new WaitForSeconds(1);
        score += 10;
        StartCoroutine(AddScoreInTime());
    }

    public void LevelEnd(bool win)
    {
        StopCoroutine(AddScoreInTime());
        if(win)
        {
            winUI.enabled = true;
            loseUI.enabled = false;
        }
        else
        {
            winUI.enabled = false;
            loseUI.enabled = true;
        }
    }


}
