/*
@file UnitDataStruct.cs
@author NDark
@date 20140420 . file started.

*/
using UnityEngine;
using System.Collections.Generic;


public class UnitDataStruct 
{
	public UnitDataSetting m_UnitDataSetting = new UnitDataSetting() ;

	public void SetUnitType( UnitType _Set )
	{
		this.m_UnitDataSetting.SetUnitType( _Set ) ;
	}
	public UnitType GetUnitType()
	{
		return this.m_UnitDataSetting.GetUnitType() ;
	}

	public void ImportStandardParameter( Dictionary< string , StandardParameter > _ParameterMap )
	{
		this.m_UnitDataSetting.ImportStandardParameter( _ParameterMap ) ;
	}

	public void ImportSkills( Dictionary< string , Skill > _Skills )
	{
		this.m_UnitDataSetting.ImportSkills( _Skills ) ;
	}

	public GameObject m_ThisGameObject = null ;
	public Vector3 GetCurrentPos() 
	{
		return m_ThisGameObject.transform.position ;
	}
	
	public bool IsVisible()
	{
		return m_ThisGameObject.renderer.enabled ;
	}
	
	public UnitState GetUnitState()
	{
		return m_UnitState ;
	}
	private UnitState m_UnitState = UnitState.UnActive ;

	public Dictionary< string , StandardParameter > GetStandardParameterTable()
	{
		return m_UnitDataSetting.standardParameters ;
	}

	public Dictionary< string , Skill > GetSkillTable()
	{
		return m_UnitDataSetting.m_Skills ;
	}

	public void Import( UnitDataStruct _Src ) 
	{
		m_UnitDataSetting.Import( _Src.m_UnitDataSetting ) ;
		m_UnitState = _Src.m_UnitState ;
		
	}
}
