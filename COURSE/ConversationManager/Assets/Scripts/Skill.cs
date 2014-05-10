/**
@file Skill.cs
@author NDark
@date 20140405 file started.
@date 20140427 by NDark . add class SkillLabel
@date 20140510 by NDark 
. rename Skill to SkillSetting
. add class EnegyProperty
. add class SkillProperty
. add class SkillVariable

 */
using UnityEngine;
using System.Collections.Generic;

// 能量屬性
public class EnegyProperty 
{
	
	public void Parse( string _Str )
	{
	
	}

	public void Assign( EnegyProperty _Src ) 
	{
		
	}
	
	public void Clear() 
	{
		
	}
		
	public void Import( EnegyProperty _Src ) 
	{
	
	}
	
	public int GetProperty( string _Key ) 
	{
		int ret = 0 ;
		return ret ;
	}
	
	public int AddProperty( string _Key , int _Value ) 
	{
		int result = 0 ;
		return result ;	
	}	
		
	private Dictionary<string,int> m_PropertyTable = new Dictionary<string, int>() ;
}

// 技能屬性
public class SkillProperty
{
	public EnegyProperty DefenseProperty
	{
		get { return m_DefenseProperty ; }
		set { m_DefenseProperty.Assign( value ) ; }
	}	
	protected EnegyProperty m_DefenseProperty = new EnegyProperty() ;
	
	public EnegyProperty AttackProperty
	{
		get { return m_AttackProperty ; }
		set { m_AttackProperty.Assign( value ) ; }
	}	
	protected EnegyProperty m_AttackProperty = new EnegyProperty() ;	
}

// 設定
public class SkillSetting : SkillProperty
{
	public string Label
	{
		get { return m_Label ; }
		set { m_Label = value ; }
	}
	private string m_Label = "" ;
	
	public string Type
	{
		get { return m_Type ; }
		set { m_Type = value ; }
	}
	private string m_Type = "" ;	
	
	
	public string Target
	{
		get { return m_Target ; }
		set { m_Target = value ; }
	}
	private string m_Target = "" ;
	

	public string FyingSpeed
	{
		get { return m_FyingSpeed ; }
		set { m_FyingSpeed = value ; }
	}
	private string m_FyingSpeed = "" ;	

	public string AnimationPrefab
	{
		get { return m_AnimationPrefab ; }
		set { m_AnimationPrefab = value ; }
	}
	private string m_AnimationPrefab = "" ;	
	
	public string DisplayString
	{
		get { return m_DisplayString ; }
		set { m_DisplayString = value ; }
	}
	private string m_DisplayString = "" ;
	
}

// 攜帶中技能變數
public class SkillVariable
{
	public SkillSetting m_SkillSetting = null ;
	public SkillProperty m_SkillPropertyNow = new SkillProperty() ;
}



public class SkillLabel
{
	public string Label
	{
		get { return m_Label ; }
		set { m_Label = value ; }
	}
	private string m_Label = "" ;

	public string Value
	{
		get { return m_Value ; }
		set { m_Value = value ; }
	}
	private string m_Value = "" ;
}
