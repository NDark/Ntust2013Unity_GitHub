/*
@file OnGUI_SetScore02.cs
@author NDark
@file 20130825 file started.
*/
using UnityEngine;

public class OnGUI_SetScore02 : MonoBehaviour 
{
	public ScoreTextDisplay02 m_ScoreScript = null ;

	// Use this for initialization
	void Start () 
	{
		m_ScoreScript = this.gameObject.GetComponent<ScoreTextDisplay02>() ;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Rect m_TextFieldRect = new Rect( 200 , 350 , 100 , 25 ) ;
	public Rect m_ButtonRect = new Rect( 300 , 350 , 100 , 25 ) ;	
	public string m_TextFieldString = "" ;
	void OnGUI()
	{

		m_TextFieldString = GUI.TextField( m_TextFieldRect , m_TextFieldString ) ;
		if( true == GUI.Button( m_ButtonRect , "SetCore" ) )
		{
			if( null != m_ScoreScript )
			{
				int score = 0 ;
				if( true == int.TryParse( m_TextFieldString , out score )  )
				{
					m_ScoreScript.SetScore( score ) ;
				}
			}
			
		}
	}
}
