/**
 * @file AnimationCollisionOnEnter.cs
 * @author NDark
 * @date 20140406 file started.
 */
using UnityEngine;

public class AnimationCollisionOnEnter : MonoBehaviour 
{
	public GameObject m_TargetPlayer = null ;
	public string m_ParentName = "" ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		// Debug.Log( "other" + other.name  ) ;
		if( other.name != m_ParentName )
		{
			if( null != m_TargetPlayer && 
			   other.name == m_TargetPlayer.name )
			{
				UnitDataParam unitData = m_TargetPlayer.GetComponent<UnitDataParam>() ;
				if( true == unitData.standardParameters.ContainsKey( "HP" ) )
				{
					float hpNow = unitData.standardParameters[ "HP" ].now ;
					--hpNow ;
					hpNow = unitData.standardParameters[ "HP" ].now = hpNow ;

					FightSystem fs = GlobalSingleton.GetFightSystem() ;
					string str = string.Format( "{0} 對 {1} 造成了 1 點傷害" , m_ParentName , m_TargetPlayer.name ) ;
					fs.AddStatus( str ) ;
					str = string.Format( "{0} 剩下 {1} 點生命值" , m_TargetPlayer.name , hpNow ) ;
					fs.AddStatus( str ) ;
				}
			}

			GameObject.Destroy(this.gameObject);
		}

	}
}
