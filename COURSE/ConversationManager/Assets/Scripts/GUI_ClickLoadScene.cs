using UnityEngine;
using System.Collections;

public class GUI_ClickLoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		infoDataCenter.Clear() ;

		// Debug.Log( "OnMouseDown" ) ;
		Application.LoadLevel( "BackToMap" ) ;
	}
}
