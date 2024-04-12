using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawEventsSection();
		DrawHealthSettingsSection();
		DrawAttackSettingsSection();
		DrawAlternateFireSettingsSection();
		DrawAbilitySettingsSection();
		serializedObject.ApplyModifiedProperties();
    }

    private void DrawEventsSection()
    {
        EditorGUILayout.LabelField("Events", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("bomb"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("fire"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altFire"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("death"));
    }

    private void DrawHealthSettingsSection()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Health Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxHealth"));
    }

    private void DrawAttackSettingsSection()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Attack Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("bulletPool"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("damage"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("FireRate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BulletQuantity"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("FireArc"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AngleVar"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SpeedVar"));
    }

    private void DrawAlternateFireSettingsSection()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Alternate Fire Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altFireRateModifier"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altBulletQualityModifier"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altFireArcModifier"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altAngleVarModifier"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("altSpeedVarModifier"));
    }

    private void DrawAbilitySettingsSection()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Ability Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("initialFocus"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("focusLossInterval"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("focusReward"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("focusLoss"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("bombCount"));
    }
}
