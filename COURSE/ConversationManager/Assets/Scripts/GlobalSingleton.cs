/**
 * @file GlobalSingleton.cs
 * @author NDark
 * @date 20140323 . file started.
 * @date 20140406 by NDark . add class method GetFightSystem()
 */
using UnityEngine;

public static class GlobalSingleton
{
	public static AgentManager GetAgentManager()
	{
		if( null == m_AgentManger )
		{
			GameObject gs = GameObject.Find( "GlobalSingleton" ) ;
			if( null != gs )
			{
				m_AgentManger = gs.GetComponent<AgentManager>() ;
			}
		}
		if( null == m_AgentManger )
		{
			Debug.LogError( "GlobalSingleton::GetAgentManager(), null == m_AgentManger" ) ;
		}
		return m_AgentManger ;
	}
	private static AgentManager m_AgentManger = null ;

	public static InfoDataCenter GetInfoDataCenter()
	{
		if( null == m_InfoDataCenter )
		{
			m_InfoDataCenter = new InfoDataCenter() ;
		}
		if( null == m_InfoDataCenter )
		{
			Debug.LogError( "GlobalSingleton::GetAgentManager(), null == m_InfoDataCenter" ) ;
		}
		return m_InfoDataCenter ;
	}
	private static InfoDataCenter m_InfoDataCenter = null ;

	public static FightSystem GetFightSystem()
	{
		if( null == m_FightSystem )
		{
			GameObject gs = GameObject.Find( "GlobalSingleton" ) ;
			if( null != gs )
			{
				m_FightSystem = gs.GetComponent<FightSystem>() ;
			}
		}
		if( null == m_FightSystem )
		{
			Debug.LogError( "GlobalSingleton::GetFightSystem(), null == m_FightSystem" ) ;
		}
		return m_FightSystem ;
	}
	private static FightSystem m_FightSystem = null ;
}
