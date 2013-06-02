/**
 * @file CameraController_CameraField02.cs
 * @author NDark
 * @date 20130602 . file started.
 */
using UnityEngine;
using System.Collections;

public class CameraController_CameraField02 : MonoBehaviour 
{
	public Vector3 m_DistanceVec = new Vector3( 0 , 5 , -10 ) ;
	public Camera m_CameraPtr = null ;
	public GameObject m_MainCharacterPtr = null ;
	public Vector3 m_WorldUp = new Vector3( 0 , 1 , 0 ) ;
	public CameraFieldManager01 m_CameraFieldManagerPtr = null ;

	public void UpdateCameraPosNow()
	{
		TryUpdateCamera() ;
	}

	// Use this for initialization
	void Start () 
	{
		// 沒設定才要初始化
		if( null == m_CameraPtr )
			InitializeCameraPtr() ;
		
		// 沒設定才要初始化
		if( null == m_MainCharacterPtr )
			InitializeMainCharacterObjectPtr() ;
		
		if( null == m_CameraFieldManagerPtr )
			InitializeCameraFieldManagerPtr() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		DecideTheTargetPositionOfCamera() ;
		TryUpdateCamera() ;
	}
	
	private void InitializeCameraPtr()
	{
		m_CameraPtr = Camera.mainCamera ;
		
		if( null == m_CameraPtr )
		{
			Debug.LogError( "CameraController_CameraField02:InitializeCameraPtr() null == m_CameraPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField02:InitializeCameraPtr() end." ) ;
		}
	}
	
	private void InitializeMainCharacterObjectPtr()
	{
		
		m_MainCharacterPtr = GameObject.FindGameObjectWithTag( "Player" ) ;
		
		
		if( null == m_MainCharacterPtr )
		{
			Debug.LogError( "CameraController_CameraField02:InitializeMainCharacterObjectPtr() null == m_MainCharacterPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField02:InitializeMainCharacterObjectPtr() end." ) ;
		}
	}
	
	private void InitializeCameraFieldManagerPtr()
	{
		m_CameraFieldManagerPtr = this.gameObject.GetComponent<CameraFieldManager01>() ;
		if( null == m_CameraFieldManagerPtr )
		{
			Debug.LogError( "CameraController_CameraField02:DecideTheTargetPositionOfCamera() null == m_CameraFieldManagerPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField02:DecideTheTargetPositionOfCamera() end." ) ;
		}	
	}
	
	private void DecideTheTargetPositionOfCamera()
	{
		if( null != m_CameraFieldManagerPtr )
		{
			m_DistanceVec = m_CameraFieldManagerPtr.GetLightFieldVec( this.gameObject.transform.position ) ;
			m_DistanceVec *= 10.0f ;
		}
	}
	
	private void TryUpdateCamera() 
	{
		if( null == m_CameraPtr || null == m_MainCharacterPtr )
		{
			return ;
		}
		float interpolateSpeed = 0.1f ;
		Vector3 expectedTarget = m_MainCharacterPtr.transform.position - m_DistanceVec ;
		Vector3 actuallyMoveTarget = Vector3.Lerp( m_CameraPtr.transform.position , expectedTarget , interpolateSpeed* Time.deltaTime ) ;
		
		m_CameraPtr.transform.position = actuallyMoveTarget ;
		m_CameraPtr.transform.LookAt( m_MainCharacterPtr.transform.position , m_WorldUp ) ;	
	}
}
