using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
   public void PlayNormalGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void PlayEndlessRunner()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Endless", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
