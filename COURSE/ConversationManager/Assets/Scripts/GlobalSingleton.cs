/**
 * @file GlobalSingleton.cs
 * @author NDark
 * @date 20140323 . file started.
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
}
