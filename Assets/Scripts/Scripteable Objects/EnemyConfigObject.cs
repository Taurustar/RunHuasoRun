using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Create Enemy Config", order = 2)]
public class EnemyConfigObject : ScriptableObject
{
    public enum ENEMY_TYPE
    {
        STATIC_ENEMY,
        MOVABLE_ENEMY

    };
    [HideInInspector]
    public bool isMovable;
    [Tooltip("Set ups the enemy type")]    
    public ENEMY_TYPE enemyType;
    [Tooltip("Damage dealed by the enemy to the player")]
    public int damage;
    [Tooltip("Check if the enemy is destroyed after collision")]
    public bool destructible;
    [ConditionalHide("isMovable")]
    [Tooltip("Sets up the enemy speed. Only works for Movable Enemies")]
    public int speed;
    [Tooltip("Sets up a sound when this enemy is instantiated in the scene")]
    public AudioClip spawnSound;

    private void OnValidate()
    {
        if(enemyType == ENEMY_TYPE.MOVABLE_ENEMY)
        {
            isMovable = true;
        }
        else
        {
            isMovable = false;
        }
    }
}
