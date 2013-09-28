/*
@file AlterParticleSystem01.cs
@author NDark
@date 20130928 file started.
*/
using UnityEngine;
using System.Collections;

public class AlterParticleSystem01 : MonoBehaviour 
{
	public bool m_AlterParticle = false ;

	// Use this for initialization
	void Start () 
	{

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ParticleSystem ps = this.gameObject.GetComponentInChildren<ParticleSystem>() ;
		if( null == ps )
		{
			return ;
		}
		if( true == m_AlterParticle )
		{
			AlterParticle( ps ) ;
		}
	}
	
	private void AlterParticle( ParticleSystem _ParticleSystem )
	{
		ParticleSystem.Particle [] parray = new ParticleSystem.Particle[ _ParticleSystem.particleCount ] ; 
		int num = _ParticleSystem.GetParticles( parray ) ;
		Debug.Log( "num" + num );
		for( int i = 0 ; i < num ; ++i )
		{
			parray[i].position = Vector3.zero ;
			parray[i].color = Color.red ;
			// Debug.Log( "parray[i].position=" + parray[i].position ) ;
		}
		_ParticleSystem.SetParticles( parray , parray.Length ) ;
	}
}
