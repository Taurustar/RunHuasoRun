using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyConfigObject))]
public class EnemyConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EnemyConfigObject enemyConfig = (EnemyConfigObject)target;
        if (GUILayout.Button("Reset Default Values"))
        {
            enemyConfig.ReturnDefaultValues();
        }

    }
}
