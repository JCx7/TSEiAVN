using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(WalkToBehaviour))]
public class WalkToDrawer : PropertyDrawer
{
    public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
    {
        int fieldCount = 2;
        return fieldCount * EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty meshAgent = property.FindPropertyRelative("meshAgent");
        SerializedProperty target = property.FindPropertyRelative("target");

        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(singleFieldRect, meshAgent);
        singleFieldRect.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(singleFieldRect, target);
    }
}
