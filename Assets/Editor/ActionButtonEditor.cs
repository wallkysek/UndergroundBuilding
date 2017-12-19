
using UnityEditor;

[CustomEditor(typeof(ActionButton))]
public class ActionButtonEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ActionButton t = (ActionButton)target;
    }
}