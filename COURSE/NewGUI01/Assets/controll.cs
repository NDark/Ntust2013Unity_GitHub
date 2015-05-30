using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class controll : MonoBehaviour 
{

	public void MoveUp()
	{
		// Debug.Log( "MoveUp()" ) ;
		RectTransform rect = this.GetComponent<RectTransform>() ;
		if( null != rect )
		{
			Vector3 pos = rect.position ;
			pos.y += rect.sizeDelta.y ;
			rect.position = pos ;

		}


	}
	
	public void MoveRight()
	{
		Debug.Log( "MoveRight()" ) ;
		RectTransform rect = this.GetComponent<RectTransform>() ;
		if( null != rect )
		{
			Vector3 pos = rect.position ;
			pos.x += rect.sizeDelta.x ;
			rect.position = pos ;

			
			Vector3 scale = rect.localScale ;
			scale.x = 1 ;
			rect.localScale = scale ;
		}
	}

	
	public void MoveDown()
	{
		Debug.Log( "MoveDown()" ) ;
		RectTransform rect = this.GetComponent<RectTransform>() ;
		if( null != rect )
		{
			Vector3 pos = rect.position ;
			pos.y -= rect.sizeDelta.y ;
			rect.position = pos ;
		}
	}

	
	public void MoveLeft()
	{
		// Debug.Log( "MoveUp()" ) ;
		RectTransform rect = this.GetComponent<RectTransform>() ;
		if( null != rect )
		{
			Vector3 pos = rect.position ;
			pos.x -= rect.sizeDelta.x ;
			rect.position = pos ;
			
			Vector3 scale = rect.localScale ;
			scale.x = -1 ;
			rect.localScale = scale ;
		}
	}

	// Use this for initialization
	void Start () {
	//	MoveRight();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
