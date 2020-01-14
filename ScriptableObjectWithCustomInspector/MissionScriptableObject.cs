using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;

#endif

[CreateAssetMenu(fileName = "Mission", menuName = "ScriptableObjects/MissionScriptableObject", order = 1)]
public class MissionScriptableObject : ScriptableObject
{
    public CharacterName CharacterName;
    public Level[] Levels;
}

#if UNITY_EDITOR
[CustomEditor(typeof(MissionScriptableObject))]
public class MissionScriptableObject_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        MissionScriptableObject script = (MissionScriptableObject)target;

        script.CharacterName = (CharacterName)EditorGUILayout.EnumPopup("CharacterName", script.CharacterName);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Levels"), true);

        serializedObject.ApplyModifiedProperties();
    }
}

[CustomPropertyDrawer(typeof(Level))]
public class LevelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        var columnsTextRect = new Rect(position.x, position.y, 50, position.height);
        var columnsRect = new Rect(position.x + 55, position.y, 30, position.height);
        var rowsRect = new Rect(position.x + 90, position.y, 30, position.height);
        var gameModeRect = new Rect(position.x + 125, position.y, 100, position.height);
        var timeLimitTextRect = new Rect(position.x + 230, position.y, 70, position.height);
        var timeLimitRect = new Rect(position.x + 305, position.y, position.width - 340, position.height);
        
        var gameMode =  property.FindPropertyRelative("gameMode");

        EditorGUI.LabelField(columnsTextRect, "Col/Rows");
        EditorGUI.PropertyField(columnsRect, property.FindPropertyRelative("columns"), GUIContent.none);
        EditorGUI.PropertyField(rowsRect, property.FindPropertyRelative("rows"), GUIContent.none);
        EditorGUI.PropertyField(gameModeRect, property.FindPropertyRelative("gameMode"), new GUIContent("", "GameMode"));

        if (gameMode.enumValueIndex == (int) GameMode.TimeLimitMode)
        {
            EditorGUI.LabelField(timeLimitTextRect, "Time limit");
            EditorGUI.PropertyField(timeLimitRect, property.FindPropertyRelative("timeLimit"), GUIContent.none);
        }

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
#endif

public enum GameMode
{
    Normal,
    TimeLimitMode,
    HardcoreMode
}

public enum CharacterName
{
    Fiona,
    Ariel,
    Margaret,
    Luise,
    Lucia,
    Ania
}

