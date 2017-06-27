using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// karol@4experience.co
// custom build platform changer so we'll change project output in 1 click
public class PlatformChangerEditor : Editor
{

    [MenuItem("Build/Make Project DEVELOPMENT", false, 20)]
    public static void MakeProject_DEVELOPMENT_NONVR()
    {
        MakeProject(DeploymentPlatform.DEVELOPMENT);
    }

    private static void MakeProject(DeploymentPlatform platform)
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        if (platform == DeploymentPlatform.DEVELOPMENT)
        {

            // karol.ryt@gmail.com
            // tu można na spokojnie zmieniac to co sie dziac powinno w opcjonalnym 
            // setupie scen z postfixem w postaci liter.
            /*
			scenes [1].enabled = false;
			scenes [2].enabled = false;
			scenes [3].enabled = false;
			scenes [4].enabled = true;
			*/

            // jako przyklad usuwam wszystkie pozostale flagi platform ustawiajac nowa biezaca

            // PlayerSettings.virtualRealitySupported = false;
            //ScriptDefinesHelperEditor.RemoveDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.PLATFORM_GEARVR);
            ScriptDefinesHelperEditor.AddDefine(BuildTargetGroup.Standalone, ProjectBuildDefines.PLATFORM_DEVELOPMENT);
        }

        EditorBuildSettings.scenes = scenes;

        Debug.Log("PlatformChanger : Changed Platform to [" + platform + "]");
    }
}