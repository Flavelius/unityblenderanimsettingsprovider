using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Client
{
    public class BlenderAnimImportSettingsProvider : SettingsProvider
    {
        public BlenderAnimImportSettingsProvider(string path, SettingsScope scopes = SettingsScope.Project, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
        }

        BlenderAnimImportSettings importSettings;
        Editor scriptEditor;

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            importSettings = BlenderAnimImportSettings.GetOrCreateSettings();
            scriptEditor = Editor.CreateEditor(importSettings, typeof(BlenderAnimImportSettingsEditor));
        }

        public override void OnDeactivate()
        {
            Object.DestroyImmediate(scriptEditor, false);
        }

        public override void OnGUI(string searchContext)
        {
            scriptEditor.OnInspectorGUI();
        }

        // Register the SettingsProvider
        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new BlenderAnimImportSettingsProvider("Project/Blender Animation Import")
            {
                // Automatically extract all keywords from the Styles.
                keywords = new[] {"Blender", "Import", "Animation", "Actions", "FBX"}
            };
            return provider;
        }
    }
}