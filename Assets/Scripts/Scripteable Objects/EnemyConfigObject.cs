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
    public bool isMovable = false;
    [Tooltip("Set ups the enemy type")]    
    public ENEMY_TYPE enemyType = ENEMY_TYPE.STATIC_ENEMY;
    [Tooltip("Damage dealed by the enemy to the player")]
    public int damage = 1;
    [Tooltip("Check if the enemy is destroyed after collision")]
    public bool destructible = true;
    [ConditionalHide("isMovable")]
    [Tooltip("Sets up the enemy speed. Only works for Movable Enemies")]
    public int speed = 3;
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

    public void ReturnDefaultValues()
    {
        isMovable = false;
        enemyType = ENEMY_TYPE.STATIC_ENEMY;
        damage = 1;
        destructible = true;
        speed = 3;
        spawnSound = null;
    }
}
