/**
 * @file CameraController_CameraField03.cs
 * @author NDark
 * @date 20130602 . file started.
 */
using UnityEngine;
using System.Collections;

public class CameraController_CameraField03 : MonoBehaviour 
{
	public GameObject m_CameraPose = null ;	
	public Camera m_CameraPtr = null ;
	public GameObject m_MainCharacterPtr = null ;
	public Vector3 m_WorldUp = new Vector3( 0 , 1 , 0 ) ;
	public CameraFieldManager02 m_CameraFieldManagerPtr = null ;

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
			Debug.LogError( "CameraController_CameraField03:InitializeCameraPtr() null == m_CameraPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField03:InitializeCameraPtr() end." ) ;
		}
	}
	
	private void InitializeMainCharacterObjectPtr()
	{
		
		m_MainCharacterPtr = GameObject.FindGameObjectWithTag( "Player" ) ;
		
		
		if( null == m_MainCharacterPtr )
		{
			Debug.LogError( "CameraController_CameraField03:InitializeMainCharacterObjectPtr() null == m_MainCharacterPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField03:InitializeMainCharacterObjectPtr() end." ) ;
		}
	}
	
	private void InitializeCameraFieldManagerPtr()
	{
		m_CameraFieldManagerPtr = this.gameObject.GetComponent<CameraFieldManager02>() ;
		if( null == m_CameraFieldManagerPtr )
		{
			Debug.LogError( "CameraController_CameraField03:InitializeCameraFieldManagerPtr() null == m_CameraFieldManagerPtr" ) ;
		}
		else
		{
			Debug.Log( "CameraController_CameraField03:InitializeCameraFieldManagerPtr() end." ) ;
		}	
	}
	
	private void DecideTheTargetPositionOfCamera()
	{
		if( null != m_CameraFieldManagerPtr )
		{
			m_CameraPose = m_CameraFieldManagerPtr.GetLightFieldPoseGameObject( this.gameObject.transform.position ) ;
			
		}
	}
	
	private void TryUpdateCamera() 
	{
		if( null == m_CameraPtr || null == m_MainCharacterPtr )
		{
			return ;
		}
		
		float interpolateSpeed = 5.0f ;
		
		Vector3 actuallyMoveTarget = Vector3.Lerp( m_CameraPtr.transform.position , 
			m_CameraPose.transform.position , interpolateSpeed* Time.deltaTime ) ;
		Quaternion actuallyRotation = Quaternion.Lerp( m_CameraPtr.transform.rotation ,
			m_CameraPose.transform.rotation , interpolateSpeed* Time.deltaTime ) ;
		m_CameraPtr.transform.position = actuallyMoveTarget ;
		m_CameraPtr.transform.rotation = actuallyRotation ;
	}
}
