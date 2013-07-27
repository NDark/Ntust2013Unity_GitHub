using UnityEngine;
using UnityEditor;


public class ExportAssetBundles {
	
	
	[MenuItem ("Build/BuildWebplayerStreamed")]
	static void BuildStreamedSceneAssetBundle()
	{
		string []levels = {"Assets/Scenes/Test.unity"} ;
		BuildPipeline.BuildStreamedSceneAssetBundle( 
			levels, "BuildStreamedSceneAssetBundle.unity3d", BuildTarget.StandaloneWindows ); 
	}
	
	[MenuItem ("Build/BuildAsset")]
	static void ExportSelected()
	{
		Debug.Log( "ExportSelected()" + Selection.activeObject.name ) ;
		// Build the resource file from the active selection.
		BuildPipeline.BuildAssetBundle(
			Selection.activeObject, Selection.objects, "BuildAssetBundle.unity3d" ) ;
	}	
}