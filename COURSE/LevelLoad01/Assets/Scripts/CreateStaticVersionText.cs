/*
@file CreateStaticVersionText.cs
@author NDark
@date 20130825 file started.
*/
using UnityEngine;

public class CreateStaticVersionText : MonoBehaviour 
{
	public string m_StaticVersionTextObjName = "StaticVersionText" ;
	public string m_PrefabName = "Common/Prefabs/StaticVersionText" ;
	// Use this for initialization
	void Start () 
	{
		GameObject staicObj = GameObject.Find( m_StaticVersionTextObjName ) ;
		if( null == staicObj )
		{
			Debug.Log( "CreateStaticVersionText() staicObj do not exist , create it." ) ;
			Object prefab = Resources.Load( m_PrefabName ) ;
			if( null == prefab )
			{
				Debug.LogError( "CreateStaticVersionText() null == prefab." ) ;
			}
			else
			{
				staicObj = (GameObject) GameObject.Instantiate( prefab ) ; 
			}
		}
		else
		{
			Debug.Log( "CreateStaticVersionText() staicObj do exist , do nothing." ) ;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
