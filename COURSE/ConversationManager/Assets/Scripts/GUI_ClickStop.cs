using UnityEngine;
using System.Collections;

public class GUI_ClickStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Time.timeScale = 0 ;
		/*
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		// Debug.Log( "OnMouseDown" ) ;
		// infoDataCenter.WriteProperty( aCategory , "OBJECT_NAME" , oName ) ;
		string [] names = GlobalSingleton.GetAgentManager().FetchAgentNames() ;
		foreach( string name in names )
		{
			string objName = infoDataCenter.ReadProperty( "CHARACTER_" + name , "OBJECT_NAME" ) ;
			GameObject obj = GameObject.Find( objName ) ;
			Debug.Log( "obj=" + obj ) ;
			Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>() ;
			if( null != rigidbody )
			{
				rigidbody.isKinematic = true ;
			}
		}
*/
	}
}
