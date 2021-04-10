using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyParallax;

public class DifficultyMultiplier : MonoBehaviour
{

    float originalSpeed;
    private void Start()
    {
        originalSpeed = GetComponent<SpriteMovement>().speed;
    }
    // Update is called once per frame
    void Update()
    {
        float difficulty = Time.timeSinceLevelLoad / 30;
        if (difficulty < 1) difficulty = 1;
        if (difficulty > 5) difficulty = 5;

        GetComponent<SpriteMovement>().speed = originalSpeed * difficulty;

    }
}
