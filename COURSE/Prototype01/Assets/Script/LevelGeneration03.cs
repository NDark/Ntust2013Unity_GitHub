/*
 * @file LevelGeneration03.cs
 * @author NDark
 * @date 20130616 . file created.
 */
using UnityEngine;
using System.Collections;

public class LevelGeneration03 : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		InitializeLevel() ;	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	private void InitializeLevel()
	{
		Debug.Log( "LevelGeneration03:InitializeLevel() start." ) ;
		
		
		InitializeBackgroundScene() ;
		
		
		Debug.Log( "LevelGeneration03:InitializeLevel() end." ) ;
	}
	
	private void InitializeBackgroundScene()
	{
		Object prefabObj = Resources.Load( "Common/Prefabs/SceneBackground001" ) ;
		if( null != prefabObj )
		{
			GameObject sceneObj = (GameObject) GameObject.Instantiate( prefabObj ) ;
			if( null != sceneObj )
			{
				sceneObj.name = "SceneBackground001" ;
				Debug.Log( "LevelGeneration03:InitializeBackgroundScene() succeed." ) ;
			}
		}
	}
}
