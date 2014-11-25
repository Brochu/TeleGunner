using UnityEngine;
using System.Collections;

public class SOGunData : ScriptableObject
{
    public string gunName = "Gun name here";
    public float damage = 1.0f;
    public float rateOfFire = 1.0f;

#if UNITY_EDITOR
    const string editorMenuName = "GunData";
    [UnityEditor.MenuItem("GameObject/Create Scriptable Object/Create " + editorMenuName, false, 0),
        UnityEditor.MenuItem("Assets/Create/Create Scriptable Object/" + editorMenuName, false, 101)]
    public static void CreateAsset()
    {
        ScriptableObject s = ScriptableObject.CreateInstance(typeof(SOGunData));

        string path = UnityEditor.AssetDatabase.GetAssetPath(UnityEditor.Selection.activeInstanceID);
        if (System.IO.Path.GetExtension(path) != "") path = System.IO.Path.GetDirectoryName(path);
        if (path == "") path = "Assets";

        string name = path + "/" + editorMenuName + ".asset";
        int id = 0;
        while (UnityEditor.AssetDatabase.LoadAssetAtPath(name, typeof(SOGunData)) != null)
        {
            id += 1;
            name = path + "/" + editorMenuName + id + ".asset";
        }

        UnityEditor.AssetDatabase.CreateAsset(s, name);
        UnityEditor.AssetDatabase.SaveAssets();

        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = s;
    }
#endif
}
