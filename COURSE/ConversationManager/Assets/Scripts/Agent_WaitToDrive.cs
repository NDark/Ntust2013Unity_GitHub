/**
 * @file Agent_WaitToDrive.cs
 * @author NDark
 * @date 20140405 . file started.
 */
using UnityEngine;

public class Agent_WaitToDrive : AgentBase 
{
	private string oName = "CarObj" ;
	private string aName = "CarObj" ;
	private string aCategory = "CHARACTER_CarObj" ;

	private float m_CloseDistance = 0.01f ;
	private float m_BreakDistance = 0.06f ;
	private GameObject m_MainCharacter = null ;
	private GameObject m_Anchor22 = null ;

	private GameObject m_GameObject = null ;

	// Use this for initialization
	void Start () 
	{
		this.AgentName = aName ;
		
		AgentStart() ;
		
		// CarObj
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		infoDataCenter.WriteProperty( aCategory , "OBJECT_NAME" , oName ) ;
		infoDataCenter.WriteProperty( aCategory , "STATE" , "Condition" ) ;
		infoDataCenter.WriteProperty( aCategory , "ASSIGNMENT" , "WaitForMainCharacter" ) ;


	}
	
	// Update is called once per frame
	void Update () 
	{
		AgentUpdate() ;
	}
	
	protected override void DoCondition()
	{
		Conditon_DoWaitToDrive() ;
	}
	
	protected override void DoAction()
	{
		Action_DoWaitToDrive() ;
	}
	
	
	private void Conditon_DoWaitToDrive()
	{
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		if( null == m_GameObject )
		{
			string currentObjectName = infoDataCenter.ReadProperty( aCategory , "OBJECT_NAME" ) ;
			m_GameObject = GameObject.Find( currentObjectName ) ;
		}
		if( null == m_MainCharacter )
		{
			m_MainCharacter = GameObject.FindGameObjectWithTag( "Player" ) ;
		}
		if( null == m_Anchor22 )
		{
			m_Anchor22 = GameObject.Find( "Anchor22" ) ;
		}



		string assignmentStr = infoDataCenter.ReadProperty( aCategory , "ASSIGNMENT" ) ;

		if( "WaitForMainCharacter" == assignmentStr )
		{
			ShowYourself( false ) ;
			Vector3 mainCharObjPos = m_MainCharacter.transform.position ;
			Vector3 anchor22ObjPos = m_Anchor22.transform.position ;
			Vector3 distanceVec = mainCharObjPos - anchor22ObjPos ;
			distanceVec.z = 0 ;
			if( distanceVec.magnitude < m_CloseDistance )
			{
				// Debug.Log( "distanceVec < threashold" ) ;
				ShowYourself( true ) ;

				infoDataCenter.WriteProperty( aCategory , "ASSIGNMENT" , "GoToTarget" ) ;
				string targetPositionStr = string.Format( "{0},{1},{2}" , 
				                                  anchor22ObjPos.x , anchor22ObjPos.y , anchor22ObjPos.z ) ;
				infoDataCenter.WriteProperty( aCategory , "TARGET_POSITION" , targetPositionStr ) ;
				WriteAgentState( AgentState.Action ) ;
			}
		}
		else if( "Wait" == assignmentStr )
		{
		}
	}
	
	private void Action_DoWaitToDrive()
	{
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		if( null == m_GameObject ||
		    null == m_MainCharacter ||
		    null == m_Anchor22 )
		{
			Debug.Log( "null == m_GameObject") ;
			return;
		}
		
		string assignmentStr = infoDataCenter.ReadProperty( aCategory , "ASSIGNMENT" ) ;
		if( "WaitForMainCharacter" == assignmentStr )
		{
		}
		else if( "GoToTarget" == assignmentStr )
		{
			string targetPositionStr = infoDataCenter.ReadProperty( aCategory , "TARGET_POSITION" ) ;
			Vector3 targetPositon = Vector3FromFromStr( targetPositionStr ) ;

			Vector3 currentPosistion = m_GameObject.transform.position ;
			targetPositon.z = currentPosistion.z ;
			
			Vector3 distanceVec = targetPositon - currentPosistion ;
			float distanceToTarget = distanceVec.magnitude ;
			//			Debug.Log( "Action_DoGoToGladiatores()::targetPositionStr=" + targetPositionStr ) ;
			//			Debug.Log( "Action_DoGoToGladiatores()::currentPosistion=" + currentPosistion ) ;
			//			Debug.Log( "Action_DoGoToGladiatores()::distanceVec=" + distanceVec ) ;
			if( distanceToTarget > m_BreakDistance )
			{
				// keep going
				Rigidbody2D r2d = m_GameObject.rigidbody2D ;
				if( null != r2d )
				{
					distanceVec.Normalize() ;
					if( r2d.velocity.magnitude < 0.2f )
						r2d.AddForce( distanceVec * 0.1f ) ;
				}
			}
			else
			{
				Rigidbody2D r2d = m_GameObject.rigidbody2D ;
				r2d.velocity = Vector2.zero ;
				infoDataCenter.WriteProperty( aCategory , "ASSIGNMENT" , "Wait" ) ;
				WriteAgentState( AgentState.Condition ) ;
			}
		}
	}

	private void ShowYourself( bool _Set )
	{
		if( null != m_GameObject.renderer )
			m_GameObject.renderer.enabled = _Set ;
	}
	
}
