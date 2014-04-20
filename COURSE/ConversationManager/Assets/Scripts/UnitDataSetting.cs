/*
@file UnitDataSetting.cs
@author NDark
@date 20140420 . file started.

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
	
	
	public void AssignSkill( string _SkillName, Skill _Skill )
	{
		if( true == m_Skills.ContainsKey( _SkillName )  )
		{
			m_Skills[ _SkillName ] = _Skill ;
		}
		else
		{
			m_Skills.Add( _SkillName , _Skill ) ;
		}
	}
	
	public void ImportSkills( Dictionary< string , Skill > _Skills )
	{
		Dictionary< string , Skill >.Enumerator i = _Skills.GetEnumerator() ;
		
		while( i.MoveNext() )
		{
			// Debug.Log( "i.Current.Key=" + i.Current.Key ) ;
			AssignSkill( i.Current.Key , i.Current.Value ) ;
		}
	}
	public Dictionary< string , Skill > m_Skills = new Dictionary<string, Skill>() ;
	
	
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
		Dictionary< string , Skill >.Enumerator skill = _Src.m_Skills.GetEnumerator() ;
		while( skill.MoveNext() )
		{
			/* @todo skill new ? */
			m_Skills.Add( skill.Current.Key , skill.Current.Value ) ;
		}
		m_ProfileTexture = _Src.m_ProfileTexture ;
		m_ProfileTextureName = _Src.m_ProfileTextureName ;
		m_UnitType = _Src.m_UnitType ;
		ImportStandardParameter( _Src.standardParameters ) ;
	
	}

}
