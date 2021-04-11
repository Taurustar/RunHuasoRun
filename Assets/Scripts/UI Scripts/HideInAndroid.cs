using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideInAndroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE
        gameObject.GetComponent<Image>().enabled = false;
#endif
    }
}
