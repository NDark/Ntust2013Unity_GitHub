using UnityEngine;
using System.Collections;

public class GUI_ClickLoadScene : MonoBehaviour 
{
	public string m_LevelName = "" ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if( 0 == m_LevelName.Length )
			return ;

		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		infoDataCenter.Clear() ;

		// Debug.Log( "OnMouseDown" ) ;
		Application.LoadLevel( m_LevelName ) ;
	}
}
