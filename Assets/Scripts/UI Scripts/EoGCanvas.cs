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
            int mins = Mathf.FloorToInt(RunHuasoRun.instance.elapsedTime / 60);
            int secs = Mathf.FloorToInt(RunHuasoRun.instance.elapsedTime % 60);
            timeText.text = "Your Time: " + mins.ToString("00") + ":" + secs.ToString("00");
        }
    }
}
