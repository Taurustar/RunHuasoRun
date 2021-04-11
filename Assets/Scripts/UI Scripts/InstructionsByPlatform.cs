using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsByPlatform : MonoBehaviour
{
    public Canvas pcInstructions, androidInstructions;

    public void Action()
    {
#if UNITY_STANDALONE
        pcInstructions.enabled = true;
#endif

#if UNITY_ANDROID
        androidInstructions.enabled = true;
#endif
    }
}
