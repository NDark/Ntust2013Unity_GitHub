/*
 * @file LevelGeneration07.cs
 * @author NDark
 * @date 20130622 . file created.
 */
using UnityEngine;
using System.Collections;
using System.Xml ;

public class LevelGeneration07 : MonoBehaviour 
{
	public string m_LevelFilePath = "Common/Data/Level009" ;

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
		Debug.Log( "LevelGeneration07:InitializeLevel() start." ) ;
		
		LoadLevelFile( m_LevelFilePath ) ;
		Debug.Log( "LevelGeneration07:InitializeLevel() LoadLevelFile() done." ) ;
		
		Debug.Log( "LevelGeneration07:InitializeLevel() end." ) ;
	}
	
	private void LoadLevelFile( string _LevelFilePath )
	{
		XmlDocument doc = new XmlDocument() ;
		TextAsset textAsset = (TextAsset) Resources.Load( _LevelFilePath ) ;
		if( null != textAsset )
		{
			doc.LoadXml( textAsset.text ) ;	
			ParseLevel( doc ) ;
		}
		Debug.Log( "LevelGeneration07:LoadLevelFile() end." ) ;
	}
	
	private void ParseLevel( XmlDocument _Doc )
	{
		Debug.Log( "LevelGeneration07:ParseLevel() start." ) ;
		XmlNode rootNode = _Doc.FirstChild ;
		if( null == rootNode || false == rootNode.HasChildNodes )
		{
			Debug.LogError( "LevelGeneration07:ParseLevel() null == rootNode || false == rootNode.HasChildNodes." ) ;
			return ;
		}

		if( true == rootNode.HasChildNodes )
		{
			string unitName = "" ;
			string prefabName = "" ;
			string componentName = "" ;
			Vector3 unitPos = Vector3.zero ;
			Quaternion unitOrientation = Quaternion.identity ;
			for( int i = 0 ; i < rootNode.ChildNodes.Count ; ++i )
			{
				if( "Unit" == rootNode.ChildNodes[ i ].Name )
				{
					if( true == XMLParseUtilityPartial03.ParseUnitObject( rootNode.ChildNodes[ i ] ,
															  ref unitName , 
															  ref prefabName , 
															  ref unitPos , 
															  ref unitOrientation ) )
					{
						GameObject addObj = InstaniateObject( unitName , 
							prefabName , unitPos , unitOrientation ) ;
						if( null != addObj )
						{
							Debug.Log( "LevelGeneration07:ParseLevel() addObj." ) ;
						}																		
					}
				}
				else if( "Component" == rootNode.ChildNodes[ i ].Name )
				{
					if( true == XMLParseUtilityPartial03.ParseComponent( rootNode.ChildNodes[ i ] ,
															  ref unitName , 
															  ref componentName
															   ) )
					{
						Debug.Log( "LevelGeneration07:ParseLevel() add component:" + unitName + " " + componentName ) ;
						GameObject addObj = GameObject.Find( unitName ) ;
						if( null != addObj )
						{
							addObj.AddComponent<LevelGeneration07>() ;
						}
						else
						{
							Debug.LogError( "LevelGeneration07:ParseLevel() null == addObj" ) ;
						}
					}					
				}
			}
		}
		Debug.Log( "LevelGeneration07:ParseLevel() end." ) ;
	}
	
	private GameObject InstaniateObject( string _ObjName , 
										 string _PrefabName , 
										 Vector3 _Pos , 
										 Quaternion _Rotation ) 
	{
		GameObject ret = null ;
		Object chessPawnPrefab = Resources.Load( _PrefabName ) ;
		if( null != chessPawnPrefab )
		{
			GameObject chessPawnObj = (GameObject) GameObject.Instantiate( chessPawnPrefab ) ;
			if( null != chessPawnObj )
			{
				chessPawnObj.transform.position = _Pos  ;
				chessPawnObj.transform.rotation = _Rotation ;
				chessPawnObj.name = _ObjName ;
				ret = chessPawnObj ;
			}
		}
		return ret;
	}	
}
