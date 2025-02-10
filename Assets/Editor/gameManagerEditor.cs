using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class gameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // 保留默认 Inspector 显示

        GameManager gameManager = (GameManager)target;

        if (GUILayout.Button("Generate Small Ball")) // 在 Inspector 添加按钮
        {
            gameManager.GenerateSmallBall();
        }
    }
}
