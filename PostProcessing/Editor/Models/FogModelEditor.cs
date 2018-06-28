using UnityEngine.PostProcessing;

namespace UnityEditor.PostProcessing
{
    using Settings = FogModel.Settings;

    [PostProcessingModelEditor(typeof(FogModel))]
    public class FogModelEditor : PostProcessingModelEditor
    {
        SerializedProperty m_ExcludeSkybox;

        SerializedProperty m_UseCustomFogSettings;
        SerializedProperty m_Color;
        SerializedProperty m_Density;
        SerializedProperty m_StartDistance;
        SerializedProperty m_EndDistance;
        SerializedProperty m_Mode;


        public override void OnEnable()
        {
            m_ExcludeSkybox = FindSetting((Settings x) => x.excludeSkybox);

            m_UseCustomFogSettings = FindSetting((Settings x) => x.useCustomFogSettings);
            m_Color = FindSetting((Settings x) => x.color);
            m_Density = FindSetting((Settings x) => x.density);
            m_StartDistance = FindSetting((Settings x) => x.startDistance);
            m_EndDistance = FindSetting((Settings x) => x.endDistance);
            m_Mode = FindSetting((Settings x) => x.mode);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This effect adds fog compatibility to the deferred rendering path; enabling it with the forward rendering path won't have any effect. Actual fog settings should be set in the Lighting panel.", MessageType.Info);
            EditorGUILayout.PropertyField(m_ExcludeSkybox);
            EditorGUILayout.PropertyField(m_UseCustomFogSettings);

            if (m_UseCustomFogSettings.boolValue)
            {
                EditorGUILayout.PropertyField(m_Color);
                EditorGUILayout.PropertyField(m_Density);
                EditorGUILayout.PropertyField(m_StartDistance);
                EditorGUILayout.PropertyField(m_EndDistance);
                EditorGUILayout.PropertyField(m_Mode);
            }
            EditorGUI.indentLevel--;
        }
    }
}
