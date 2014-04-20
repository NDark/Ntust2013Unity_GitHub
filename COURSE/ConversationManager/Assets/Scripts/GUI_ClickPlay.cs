using UnityEngine;
using System.Collections;

public class GUI_ClickPlay : MonoBehaviour 
{
	float m_StartPhyTime = 0.0f ;

	// Use this for initialization
	void Start () 
	{
		m_StartPhyTime = Time.fixedDeltaTime ;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Time.timeScale = 1 ;
		Time.fixedDeltaTime = m_StartPhyTime * Time.timeScale;
		/*
		Debug.Log( "OnMouseDown" ) ;
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
				rigidbody.isKinematic = false ;
			}
		}
		*/
	}
}
