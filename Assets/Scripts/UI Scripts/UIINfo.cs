using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIINfo : MonoBehaviour
{
    public Text hpText, scoreText;
    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + RunHuasoRun.instance.playerGameObject.GetComponent<HuasoScript>().health.ToString();
        scoreText.text = "Score: " + RunHuasoRun.instance.score.ToString();

    }
}
