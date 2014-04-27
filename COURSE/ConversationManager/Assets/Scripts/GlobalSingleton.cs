/**
 * @file GlobalSingleton.cs
 * @author NDark
 * @date 20140323 . file started.
 * @date 20140406 by NDark . add class method GetFightSystem()
@date 20140427 by NDark
. add class method GetSkillSettingTable()
. add class member m_SkillSettingTable

 */
using UnityEngine;
using System.Collections.Generic;


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

	// 技能的設定,是由關卡讀取進來,技能資料會從此取得設定
	static public Dictionary<string,Skill> GetSkillSettingTable()
	{
		if( null == m_SkillSettingTable )
		{
			m_SkillSettingTable = new Dictionary<string, Skill>() ;
		}
		return m_SkillSettingTable ;
	}
	static private Dictionary<string /* unitDataTemplateName */,Skill > m_SkillSettingTable = null ;


	// 物件的設定,是由關卡讀取近來,物件資料會指向此
	static public Dictionary<string,UnitDataSetting> GetUnitDataSettingTable()
	{
		if( null == m_UnitDataSettingTable )
		{
			m_UnitDataSettingTable = new Dictionary<string, UnitDataSetting>() ;
		}
		return m_UnitDataSettingTable ;
	}
	static private Dictionary<string /* unitDataTemplateName */,UnitDataSetting> m_UnitDataSettingTable = null ;

	// 物件的資料,注意過場可能需要洗掉,也可能需澳留下來,不要重複
	static public Dictionary<string,UnitDataStruct> GetUnitDataStructTable()
	{
		if( null == m_UnitDataStructTable )
		{
			m_UnitDataStructTable = new Dictionary<string, UnitDataStruct>() ;
		}
		return m_UnitDataStructTable ;
	}
	static private Dictionary<string,UnitDataStruct> m_UnitDataStructTable = null ;

}
