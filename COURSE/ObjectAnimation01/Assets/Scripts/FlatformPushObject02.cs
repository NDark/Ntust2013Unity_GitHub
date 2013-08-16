using UnityEngine;
using System.Collections;

public class FlatformPushObject02 : MonoBehaviour 
{
	public bool IsGround = false ;
	public float m_MoveSpeed = 5.0f ;
	public GameObject m_ActivePlatform = null ;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( false == IsGround )
		{
			this.transform.Translate( Vector3.up * -0.1f ) ;
		}		
		
		if( true == Input.GetKey( KeyCode.A )  )
		{
			this.transform.Translate( new Vector3( -1 * m_MoveSpeed * Time.deltaTime , 0 , 0 ) ) ;
		}
		else if( true == Input.GetKey( KeyCode.D ) )
		{
			this.transform.Translate( new Vector3( 1 * m_MoveSpeed * Time.deltaTime , 0 , 0 ) ) ;			
		}
		else if( true == Input.GetKey( KeyCode.S ) )
		{
			this.transform.Translate( new Vector3( 0 , 0 , -1 * m_MoveSpeed * Time.deltaTime ) ) ;			
		}
		else if( true == Input.GetKey( KeyCode.W ) )
		{
			this.transform.Translate( new Vector3( 0 , 0 , 1 * m_MoveSpeed * Time.deltaTime ) ) ;			
		}		
		
		DetectPlatform() ;
	}
	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log( other.gameObject.name ) ;
		m_ActivePlatform = other.gameObject ;
		IsGround = true ;
	}
	
	void DetectPlatform()
	{
		if( true == IsGround )
		{
			Ray ray = new Ray( this.transform.position , this.transform.up * -1 ) ;
			RaycastHit hitInfo ;
			if( true == Physics.Raycast( ray , out hitInfo ) )
			{
				Debug.Log( hitInfo.collider.gameObject.name ) ;
				if( hitInfo.collider.gameObject != m_ActivePlatform )
				{
					IsGround = false ;
				}
			}
		}
	}
}
