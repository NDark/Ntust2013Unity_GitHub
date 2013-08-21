/*
@file ExportSelectAsset02.cs
@author NDark
@date 20130821 file started.
*/
using UnityEngine;
using UnityEditor;

public class ExportSelectAsset02 : MonoBehaviour {
	

	[MenuItem ("Build/BuildWithExplicitAssetNames")]
	static void BuildWithExplicitAssetNames()
	{
		Debug.Log( "Selection.activeObject=" + Selection.activeObject.name ) ;
		
		for( int i = 0 ; i < Selection.objects.Length ; ++i )
		{
			Debug.Log( "Selection.objects[ i ]=" + Selection.objects[ i ] ) ;
		}
		
		string [] pathes ;
		RetrieveFilePath( Selection.objects , out pathes ) ;
		/*
		BuildPipeline.BuildAssetBundleExplicitAssetNames( 
			Selection.objects , 
			pathes ,
			"BuildWithExplicitAssetNames.unity3d" ) ;
		//*/
		Debug.Log( "BuildWithExplicitAssetNames() completed." ) ;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	static private void RetrieveFilePath( object[] _Objects , out string [] _Pathes )
	{
		string [] pathes = new string[1] ;
		
		
		
		_Pathes = pathes ;
	}
}
