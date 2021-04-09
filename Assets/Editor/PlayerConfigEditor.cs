using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerConfigObject))]
public class PlayerConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerConfigObject playerConfigObject = (PlayerConfigObject)target;
        if (GUILayout.Button("Reset Default Values"))
        {
            playerConfigObject.ReturnDefaultValues();
        }

    }
}
