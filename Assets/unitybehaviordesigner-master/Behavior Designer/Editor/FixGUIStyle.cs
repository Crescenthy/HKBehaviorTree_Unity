using UnityEngine;
using UnityEditor;
using System.Reflection;

using BehaviorDesigner.Editor;


/// <summary>
/// 修复BehaviorDesigner编辑器的GUIStyle问题
/// </summary>
public class FixGUIStyle
{

    [MenuItem("Tools/Behavior Designer/修复界面GUIStyle #b", false, 0)]
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void ShowWindow()
    {

        var guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.UpperCenter;
        guiStyle.fontSize = 12;
        guiStyle.wordWrap = true;
        guiStyle.normal.textColor = Color.white;
        guiStyle.active.textColor = Color.white;
        guiStyle.hover.textColor = Color.white;
        guiStyle.focused.textColor = Color.white;
        
        Texture2D tex2D = new Texture2D(1, 1, TextureFormat.RGB24, false);
        tex2D.SetPixel(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
        tex2D.hideFlags = HideFlags.HideAndDontSave;
        tex2D.Apply();
        guiStyle.normal.background = tex2D;
        guiStyle.margin = new RectOffset(0,0,0,0);
        guiStyle.padding = new RectOffset(0,0,1,0);
  

        // 反射动态修改私有静态成员，修改GUIStyle
        var t = typeof(BehaviorDesignerUtility);
        var graphBackgroundGUIStyle = t.GetField("graphBackgroundGUIStyle", BindingFlags.Static | BindingFlags.NonPublic);
        graphBackgroundGUIStyle.SetValue(null, guiStyle);


        var taskCommentGUIStyle = t.GetField("taskCommentGUIStyle", BindingFlags.Static | BindingFlags.NonPublic);
        taskCommentGUIStyle.SetValue(null, guiStyle);


        var selectedBackgroundGUIStyle = t.GetField("selectedBackgroundGUIStyle", BindingFlags.Static | BindingFlags.NonPublic);
        selectedBackgroundGUIStyle.SetValue(null, guiStyle);


        var preferencesPaneGUIStyle = t.GetField("preferencesPaneGUIStyle", BindingFlags.Static | BindingFlags.NonPublic);
        preferencesPaneGUIStyle.SetValue(null, guiStyle);
        

    }
}
