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
		for( int i = 0 ; i < Selection.objects.Length ; ++i )
		{
			Debug.Log( Selection.objects[ i ] ) ;
		}
		// Build the resource file from the active selection.
		BuildPipeline.BuildAssetBundle(
			Selection.activeObject, 
			Selection.objects, 
			"BuildAssetBundle"+Selection.activeObject.name+".unity3d" ) ;
	}	
}