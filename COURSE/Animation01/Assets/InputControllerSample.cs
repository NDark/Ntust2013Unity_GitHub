using UnityEngine;
using System.Collections;

public class InputControllerSample : MonoBehaviour 
{
	bool m_IsCrouch = false ;
	float m_Speed = 0 ;
	Animator m_Animator = null ;
	// Use this for initialization
	void Start () 
	{
		m_Animator = this.GetComponent<Animator>() ;
		if( null == m_Animator )
		{
			Debug.LogError( "null == m_Animator" ) ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_Animator )
		{
			return ;
		}
	
		float rotateSpeed = 50 ;
		if( Input.GetKey(KeyCode.LeftArrow) )
		{
			this.transform.Rotate( Vector3.up , -1 * rotateSpeed * Time.deltaTime ) ;
		}
		else if( Input.GetKey(KeyCode.RightArrow ) )
		{
			this.transform.Rotate( Vector3.up , rotateSpeed * Time.deltaTime ) ;
		}
			
		if( Input.GetKey(KeyCode.UpArrow) )
		{
			m_Speed += 0.1f ;
		}
		else
		{
			m_Speed -= 0.5f ;
		}
		if( m_Speed >= 5 ) 
		{	
			m_Speed = 5 ;
		}
		else if( m_Speed < 0 ) 
		{
			m_Speed = 0 ;
		}
		
		if( 0 != m_Speed )
		{
			this.transform.Translate( Vector3.forward * m_Speed * Time.deltaTime , Space.Self ) ;
		}
		
		
		m_IsCrouch = ( Input.GetKey(KeyCode.LeftShift) ) ;
		
	
		m_Animator.SetBool( "IsCrouch" , m_IsCrouch ) ;
		m_Animator.SetFloat( "Speed" , m_Speed ) ;
		
		if( true == m_IsCrouch )
		{
			m_Speed = 0 ;
		}		
	}
}
