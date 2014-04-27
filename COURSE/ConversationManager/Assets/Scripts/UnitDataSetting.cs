/*
@file UnitDataSetting.cs
@author NDark
@date 20140420 . file started.
@date 20140427 by NDark . modify skill to skilllabel of m_SkillLabels

*/
using UnityEngine;
using System.Collections.Generic;


public enum UnitState
{
	UnActive = 0 ,
	Initialized ,
	Borning ,
	Active ,
	Idle ,
	Dying ,
	Dead ,
} ;

public enum UnitType
{
	UnDefine = 0 ,
	StaticObject ,
	Unit ,
	Player ,
} ;

public class UnitDataSetting 
{
	public void SetUnitType( UnitType _Set )
	{
		m_UnitType = _Set ;
	}
	public UnitType GetUnitType()
	{
		return m_UnitType ;
	}
	private UnitType m_UnitType = UnitType.UnDefine ;
	
	public string ProfileTextureName
	{
		get { return m_ProfileTextureName ; }
		set 
		{ 
			string set = value ;
			if( set != m_ProfileTextureName )
			{
				//reload?
				m_ProfileTextureName = set ;
			}
		}
	}
	private string m_ProfileTextureName = "" ;
	
	public Texture ProfileTexture
	{
		get { return m_ProfileTexture ; }
		set 
		{
			if( null != m_ProfileTexture )
			{
				
			}
			m_ProfileTexture = value ;
		}
	}
	private Texture m_ProfileTexture = null ;
	
	
	public void AssignSkillLabel( string _SkillLabelKey , SkillLabel _SkillLabelObj )
	{
		if( true == m_SkillLabels.ContainsKey( _SkillLabelKey )  )
		{
			m_SkillLabels[ _SkillLabelKey ] = _SkillLabelObj ;
		}
		else
		{
			m_SkillLabels.Add( _SkillLabelKey , _SkillLabelObj ) ;
		}
	}
	
	public void ImportSkillLabels( Dictionary< string , SkillLabel > _SkillLabels )
	{
		Dictionary< string , SkillLabel >.Enumerator i = _SkillLabels.GetEnumerator() ;
		
		while( i.MoveNext() )
		{
			// Debug.Log( "i.Current.Key=" + i.Current.Key ) ;
			AssignSkillLabel( i.Current.Key , i.Current.Value ) ;
		}
	}
	public Dictionary< string , SkillLabel > m_SkillLabels = new Dictionary<string, SkillLabel>() ;
	
	
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

	public void Import( UnitDataSetting _Src ) 
	{
		ImportSkillLabels( _Src.m_SkillLabels ) ;
		m_ProfileTexture = _Src.m_ProfileTexture ;
		m_ProfileTextureName = _Src.m_ProfileTextureName ;
		m_UnitType = _Src.m_UnitType ;
		ImportStandardParameter( _Src.standardParameters ) ;
	
	}

}
