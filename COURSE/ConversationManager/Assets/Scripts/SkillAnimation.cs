/**
 * @file SkillAnimation.cs
 * @author NDark
 * @date 20140405 file started.
 */
using UnityEngine;

public class SkillAnimation : MonoBehaviour 
{
	public SkillVariable m_SkillVariable = null ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_SkillVariable )
		{
			if( false == m_SkillVariable.HasArmor() )
			{
				Debug.Log( "false == m_SkillVariable.HasArmor()" ) ;
				GameObject.Destroy(this.gameObject);
			}
			else if( false == m_SkillVariable.HasAttactProperty() )
			{
				Debug.Log( "false == m_SkillVariable.HasAttactProperty()" ) ;
				GameObject.Destroy(this.gameObject);
			}
		}
	}
}
