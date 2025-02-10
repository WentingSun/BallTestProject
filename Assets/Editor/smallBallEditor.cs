using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SmallBall))]
public class SmallBallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // 保留默认 Inspector 显示

        SmallBall smallBall = (SmallBall)target;

        if (GUILayout.Button("Apply Random Force")) // 在 Inspector 添加按钮
        {
            smallBall.ApplyRandomForce();
        }
    }
}
