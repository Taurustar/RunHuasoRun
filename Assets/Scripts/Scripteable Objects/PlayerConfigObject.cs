using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Create Player", order = 2)]
public class PlayerConfigObject : ScriptableObject
{
    [Range(10, 100)]
    [Tooltip("Starting health value")]
    public int startingHealth = 100;
    [Range(1, 4)]
    [Tooltip("Sets the player's speed")]
    public float speed = 3;


    public void ReturnDefaultValues()
    {
        startingHealth = 100;
        speed = 3;
    }

}
