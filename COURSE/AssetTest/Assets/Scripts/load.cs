using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Debug.Log( "load" ) ;
		StartCoroutine(LoadBundle());
	}
	
	public object [] objs ;
    public IEnumerator LoadBundle()
	{
		Debug.Log( "LoadBundle" ) ;
        using( WWW download = 
			WWW.LoadFromCacheOrDownload( 
			"file:///D:/TeacherBackup/NDark/20130809/Ntust2013Unity/COURSE/AssetTest/BuildAssetBundleCube.unity3d" , 0 ) )
		{
			Debug.Log( "WWW LoadFromCacheOrDownload" ) ;
            yield return download;
			
			Debug.Log( "yield return download completed" ) ;
            AssetBundle assetBundle = download.assetBundle;
			
			if( null == assetBundle )
			{
				Debug.Log( "null == assetBundle" ) ;
				return false ;
			}
			// Application.LoadLevel( "Test" ) ;
			// objs = assetBundle.LoadAll() ;
			// Debug.Log( "objs.Length" + objs.Length ) ;
			
			Object prefab = assetBundle.Load("Cube") ;
			if( null == prefab )
			{
				Debug.Log( "null == prefab" ) ;
			}
			else
			{
				GameObject obj = (GameObject) GameObject.Instantiate( prefab ) ;
				obj.name = "NewCube" ;
			}
			//*/
        }
    }
		
	// Update is called once per frame
	void Update () {
	
	}
}
