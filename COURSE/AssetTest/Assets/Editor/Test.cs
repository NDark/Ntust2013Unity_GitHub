using UnityEngine;
using UnityEditor;


public class ExportAssetBundles {
	
	
	[MenuItem ("Build/BuildWebplayerStreamed")]
	static void MyBuild()
	{
		string []levels = {"Assets/Scenes/Test.unity"} ;
		BuildPipeline.BuildStreamedSceneAssetBundle( levels, "Streamed-Level1.unity3d", BuildTarget.StandaloneWindows ); 
	}
}