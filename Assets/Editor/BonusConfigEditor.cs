using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BonusConfigObject))]
public class BonusConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BonusConfigObject bonusConfigObject = (BonusConfigObject)target;
        if (GUILayout.Button("Reset Default Values"))
        {
            bonusConfigObject.ReturnDefaultValues();
        }

    }
}
