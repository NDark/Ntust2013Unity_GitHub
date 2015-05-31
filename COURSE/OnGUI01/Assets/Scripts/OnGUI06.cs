using UnityEngine;
using System.Collections;

public class OnGUI06 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public string m_TextString = "(Click Button Please)" ;
	public int m_Iteration = 0 ;
	void OnGUI()
	{
		Func() ;
	}

	private void Func() 
	{
		Rect button1Rect = new Rect( 100, 100 , 300 , 50 ) ;
		if( true == GUI.Button( button1Rect , m_TextString ) )
		{ 
			m_Iteration += 1 ;
			m_TextString = "Oh yeah!!" ;
		}
		
		Rect text2Rect = new Rect( 250, 250 , 100 , 50 ) ;
		GUI.Label( text2Rect , m_Iteration.ToString() ) ;

	}
}


















