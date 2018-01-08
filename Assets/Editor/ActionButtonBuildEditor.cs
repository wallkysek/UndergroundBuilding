
using UnityEditor;

[CustomEditor(typeof(ActionButtonBuild))]
public class ActionButtonBuildEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ActionButtonBuild t = (ActionButtonBuild)target;
    }
}