using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bonus Object", menuName = "ScriptableObjects/Create a Bonus Object", order = 2)]
public class BonusConfigObject : ScriptableObject
{
    [Tooltip("Sets up the score when the player picks up the object")]
    public int score;
    [Tooltip("Sets up a pick up sound for this specific kind of object")]
    public AudioClip pickUpSound;
}
