using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// karol@4experience.co
// helper tool to set propoer script defines for development
public class LogDevelopmentModeEditor : Editor {


	// LOG ENGINE
	[MenuItem("Build/Log/Enable Engine Log",false,60)]
	public static void EnableEngineLog() {
		ScriptDefinesHelperEditor.AddDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_ENGINE);
	}

	[MenuItem("Build/Log/Enable Engine Log",true)]
	public static bool ValidateEnabledEngineLog() {
		if (ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_ENGINE))
			return false;
		else
			return true;
	}

	[MenuItem("Build/Log/Disable Engine Log",false,61)]
	public static void DisableEngineLog() {
		ScriptDefinesHelperEditor.RemoveDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_ENGINE);
	}

	[MenuItem("Build/Log/Disable Engine Log",true)]
	public static bool ValidateDisabledEngineLog() {
		if (!ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_ENGINE))
			return false;
		else
			return true;
	}

	// LOG GAMEPLAY
	[MenuItem("Build/Log/Enable Gameplay Log",false,62)]
	public static void EnableGameplayLog() {
		ScriptDefinesHelperEditor.AddDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_GAMEPLAY);
	}

	[MenuItem("Build/Log/Enable Gameplay Log",true)]
	public static bool ValidateEnabledGameplayLog() {
		if (ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_GAMEPLAY))
			return false;
		else
			return true;
	}

	[MenuItem("Build/Log/Disable Gameplay Log",false,63)]
	public static void DisableGameplayLog() {
		ScriptDefinesHelperEditor.RemoveDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_GAMEPLAY);
	}

	[MenuItem("Build/Log/Disable Gameplay Log",true)]
	public static bool ValidateDisabledGameplayLog() {
		if (!ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.LOG_GAMEPLAY))
			return false;
		else
			return true;
	}

	// DEBUG_TOOLS
	[MenuItem("Build/Debug/Disable Debug Tools",false,61)]
	public static void DisableDebugTools() {
		ScriptDefinesHelperEditor.RemoveDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.DEBUG_TOOLS);
	}

	[MenuItem("Build/Debug/Disable Debug Tools",true)]
	public static bool ValidateDisabledDebugTools() {
		if (!ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.DEBUG_TOOLS))
			return false;
		else
			return true;
	}

	[MenuItem("Build/Debug/Enable Debug Tools",false,62)]
	public static void EnableDebugTools() {
		ScriptDefinesHelperEditor.AddDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.DEBUG_TOOLS);
	}

	[MenuItem("Build/Debug/Enable Debug Tools",true)]
	public static bool ValidateEnabledDebugTools() {
		if (ScriptDefinesHelperEditor.ContainsDefine (BuildTargetGroup.Standalone, ProjectBuildDefines.DEBUG_TOOLS))
			return false;
		else
			return true;
	}

}
