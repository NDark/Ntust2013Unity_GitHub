/**
 * @file FightSystem.cs
 * @author NDark
 * @date 20140405 file started.
 */
using UnityEngine;
using System.Collections.Generic;

public enum FightSystemState
{
	UnActive = 0 ,
	Initialize ,
	Ready ,
	BattleInitialize ,
	BattleStartAnimation ,
	RefreshOptions ,
	WaitCharacterLeft ,
	WaitCharacterRight ,
	JudgeVictory ,
	BattleEndAnimation ,
}

public class FightSystem : MonoBehaviour 
{
	private GameObject m_CharacterLeft = null ;
	private GameObject m_CharacterRight = null ;
	private GameObject m_DisplayCharacterLeft = null ;
	private GameObject m_DisplayCharacterRight = null ;

	private GameObject m_StatusBackground = null ;
	private List<string> m_StatusStringList = new List<string>() ;
	private List<GameObject> m_DisplayStatusList = new List<GameObject>() ;


	private GameObject m_OperationBackground = null ;
	private List<Operation> m_OperationOptionList = new List<Operation>() ;
	private List<GameObject> m_DispalyOperationList = new List<GameObject>() ;

	private List<SkillAnimation> m_SkillAnimationList = new List<SkillAnimation>() ;

	private FightSystemState m_FightSystemState = FightSystemState.UnActive ;

	// Use this for initialization
	void Start () 
	{
		RetrieveGameObject( ref m_DisplayCharacterLeft , "FightSystemCharacterLeftObject" ) ;
		RetrieveGameObject( ref m_DisplayCharacterRight , "FightSystemCharacterRightObject" ) ;
		RetrieveGameObject( ref m_StatusBackground , "FightSystemStatusBackground" ) ;

	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_FightSystemState )
		{
		case FightSystemState.UnActive :
			break ;
		case FightSystemState.Initialize :
			break ;
		case FightSystemState.Ready :
			break ;
		case FightSystemState.BattleInitialize :
			break ;
		case FightSystemState.BattleStartAnimation :
			break ;
		case FightSystemState.RefreshOptions :
			break ;
		case FightSystemState.WaitCharacterLeft :
			break ;
		case FightSystemState.WaitCharacterRight :
			break ;
		case FightSystemState.JudgeVictory :
			break ;
		case FightSystemState.BattleEndAnimation :
			break ;
		}
	}

	private void RetrieveGameObject( ref GameObject _Obj , string _ObjectName ) 
	{
		_Obj = GameObject.Find( _ObjectName ) ;
		if( null == _Obj )
		{
			Debug.LogError( "RetrieveGameObject():" + _ObjectName + "is not found." ) ;
		}
	}
}
