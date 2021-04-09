using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EoGCanvas : MonoBehaviour
{

    public Text scoreText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateValues()
    {
        if(scoreText)
        {
            scoreText.text = "Score: " + RunHuasoRun.instance.score.ToString();
        }
        if(timeText)
        {
            timeText.text = "Your Time: " + RunHuasoRun.instance.elapsedTime.ToString("0");
        }
    }
}
