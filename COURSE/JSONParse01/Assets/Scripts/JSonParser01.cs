/*
 * @file JSonParser01.cs
 * @author NDark
 * @date 20130623 . file started.
 */
using UnityEngine;
using System.Collections;


public class JSonParser01 : MonoBehaviour 
{
	public string m_LevelFilePath = "Common/Data/Level007" ;

	// Use this for initialization
	void Start () 
	{
		LoadLevelFile( m_LevelFilePath ) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void LoadLevelFile( string _LevelFilePath )
	{
		Debug.Log( "JSonParser01:LoadLevelFile() start." ) ;	
		TextAsset textAsset = (TextAsset) Resources.Load( _LevelFilePath ) ;
		if( null != textAsset )
		{
			JSONObject jsObj = new JSONObject( textAsset.text );
			ParseLevel( jsObj ) ;
			Debug.Log( "JSonParser01:LoadLevelFile() ParseLevel()." ) ;	
		}
		Debug.Log( "JSonParser01:LoadLevelFile() end." ) ;
	}
	
	private void ParseLevel( JSONObject _JsonObj )
	{
		if( null == _JsonObj )
			return ;

		JSONObject nameNode = _JsonObj.GetField( "name" ) ;
		if( null != nameNode )
		{
			Debug.Log( "JSonParser01::ParseLevel() nameNode.str" + nameNode.str ) ;
		}
		
		JSONObject unitsArray = _JsonObj.GetField( "units" ) ;
		if( null != unitsArray && 
			unitsArray.type == JSONObject.Type.ARRAY )
		{
			
		}		
		
		Debug.Log( "JSonParser01:ParseLevel() end." ) ;
	}
}
