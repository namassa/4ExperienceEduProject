using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// karol@4experience.co
// helper tool to set propoer script defines for runtime
public class ScriptDefinesHelperEditor : Editor
{
    //
    public static void AddDefine(BuildTargetGroup group, ProjectBuildDefines define)
    {
        List<string> defines = GetCurrentDefineList(group);

        if (defines.Contains(define.ToString()))
        {
            Debug.Log("ScriptDefinesHelperEditor : DUPLICATE [" + define + "]");
        }
        else
        {
            Debug.Log("ScriptDefinesHelperEditor : Add [" + define + "]");
            defines.Add(define.ToString());

            ApplyDefines(group, defines);
        }
    }

    //
    public static void RemoveDefine(BuildTargetGroup group, ProjectBuildDefines define)
    {
        List<string> defines = GetCurrentDefineList(group);

        if (defines.Contains(define.ToString()))
        {
            Debug.Log("ScriptDefinesHelperEditor : Remove [" + define + "]");

            defines.Remove(define.ToString());

            ApplyDefines(group, defines);
        }
        else
        {
            Debug.Log("ScriptDefinesHelperEditor : No Symbol To Remove [" + define + "]");
        }
    }

    //
    public static bool ContainsDefine(BuildTargetGroup group, ProjectBuildDefines define)
    {
        List<string> defines = GetCurrentDefineList(group);

        return defines.Contains(define.ToString());
    }

    //
    private static List<string> GetCurrentDefineList(BuildTargetGroup group)
    {
        List<string> defineList = new List<string>();

        string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
        string word = string.Empty;

        for (int i = 0; i < defines.Length; i++)
        {
            if (defines[i] == ';')
            {
                if (!string.IsNullOrEmpty(word))
                {
                    defineList.Add(word);
                    word = string.Empty;
                }
            }
            else
            {
                word += defines[i];
            }
        }

        if (!string.IsNullOrEmpty(word))
            defineList.Add(word);

        return defineList;
    }

    //
    private static void ApplyDefines(BuildTargetGroup group, List<string> defines)
    {
        string defineSymbols = string.Empty;
        for (int i = 0; i < defines.Count; i++)
        {
            defineSymbols += defines[i] + ";";
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(group, defineSymbols);
    }
}
