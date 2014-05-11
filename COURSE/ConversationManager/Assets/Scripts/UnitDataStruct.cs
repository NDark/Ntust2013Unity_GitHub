/*
@file UnitDataStruct.cs
@author NDark
@date 20140420 . file started.
@date 20140511 by NDark . add class member m_DefenseProperty

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
	
	public EnegyProperty DefenseProperty
	{
		get { return m_DefenseProperty ; }
		set { m_DefenseProperty = value ; }
	}
	private EnegyProperty m_DefenseProperty = new EnegyProperty() ;


	// 這個是 UnitDataStruct 本身的 StandardParameter (變數), 而不是 m_UnitDataSetting 內的資料
	// 注意
	public Dictionary< string , StandardParameter > standardParameters = new Dictionary< string , StandardParameter >() ;
	public StandardParameter [] Debug_standardParameters = null ;
	
	public void ImportStandardParameter( Dictionary< string , StandardParameter > _ParameterMap )
	{
		Dictionary< string , StandardParameter >.Enumerator i = _ParameterMap.GetEnumerator() ;
		while( i.MoveNext() )
		{
			AssignStandardParameter( i.Current.Key , i.Current.Value ) ;
		}
	}
	
	public void AssignStandardParameter( string _Key , 
	                                    StandardParameter _Parameter )
	{
		standardParameters[ _Key ] = new StandardParameter( _Parameter ) ;
	}



	public void ImportSkillLabels( Dictionary< string , SkillLabel > _SkillLabels )
	{
		this.m_UnitDataSetting.ImportSkillLabels( _SkillLabels ) ;
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
		return standardParameters ;
	}

	public Dictionary< string , SkillLabel > GetSkillLabelTable()
	{
		return m_UnitDataSetting.m_SkillLabels ;
	}

	public void Import( UnitDataSetting _SettingSrc ) 
	{
		m_UnitDataSetting = _SettingSrc ;// 共用
		ImportStandardParameter( _SettingSrc.standardParameters ) ;// 自己複製一份
	}

	public void Import( UnitDataStruct _Src ) 
	{
		m_UnitDataSetting = _Src.m_UnitDataSetting ;// 共用
		ImportStandardParameter( _Src.m_UnitDataSetting.standardParameters ) ;// 自己複製一份
		m_UnitState = _Src.m_UnitState ;
		
	}
}
