/**
 * @file MainCharacterController02.cs
 * @author NDark
 * @date 20130601
 */
using UnityEngine;
using System.Collections;

public class MainCharacterController02 : MonoBehaviour 
{
	public float m_MoveSpeed = 5.0f ;	
	
	public Vector3 m_MousePositionLast = Vector3.zero ;
	public GameObject m_MainCharacterObject = null ;
	Quaternion m_RotationToPositiveX = Quaternion.identity ;
	Quaternion m_RotationToMinusX = Quaternion.identity ;
	
	

	// Use this for initialization
	void Start () 
	{
		m_MousePositionLast = Input.mousePosition ;	
		InitializeMainCharacterObjectPtr() ;
		
		m_RotationToPositiveX.SetLookRotation( new Vector3( 1 , 0 , 0 ) , new Vector3( 0 , 1 , 0 ) ) ;
		m_RotationToMinusX.SetLookRotation( new Vector3( -1 , 0 , 0 ) , new Vector3( 0 , 1 , 0 ) ) ;
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool m_Update = false ;
		if( true == Input.GetKey( KeyCode.A )  )
		{
			this.gameObject.transform.Translate( -1 * m_MoveSpeed * Time.deltaTime , 0 , 0 , Space.World ) ;
			
			// face left
			this.gameObject.transform.rotation = m_RotationToMinusX ;
				
				
			m_Update = true ;
		}
		else if( true == Input.GetKey( KeyCode.D ) )
		{
			this.gameObject.transform.Translate( 1 * m_MoveSpeed * Time.deltaTime , 0 , 0 , Space.World ) ;
			
			// face right
			this.gameObject.transform.rotation = m_RotationToPositiveX ;
			
			m_Update = true ;
		}

		
		if( true == m_Update )
		{
			
		}
		
		m_MousePositionLast = Input.mousePosition ;
	}
	
	private void InitializeMainCharacterObjectPtr()
	{
		
		m_MainCharacterObject = this.gameObject ;

		if( null == m_MainCharacterObject )
		{
			Debug.LogError( "MainCharacterController01:InitializeMainCharacterObjectPtr() null == m_MainCharacterObject" ) ;
		}
		else
		{
			Debug.Log( "MainCharacterController01:InitializeMainCharacterObjectPtr() end." ) ;
		}
	}	
}
