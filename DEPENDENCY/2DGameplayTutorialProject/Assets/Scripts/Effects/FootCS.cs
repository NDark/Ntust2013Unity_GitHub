using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(SphereCollider), typeof(Rigidbody)) ]
public class FootCS : MonoBehaviour 
{
	public float baseFootAudioVolume = 1.0f;
	public float soundEffectPitchRandomness = 0.05f;
	
	void OnTriggerEnter ( Collider other ) 
	{
		CollisionParticleEffectCS collisionParticleEffect = other.GetComponent<CollisionParticleEffectCS>();
		
		if (collisionParticleEffect) 
		{
			Instantiate(collisionParticleEffect.effect, transform.position, transform.rotation);
		}
		
		CollisionSoundEffectCS collisionSoundEffect = other.GetComponent<CollisionSoundEffectCS>();
	
		if (collisionSoundEffect) {
			audio.clip = collisionSoundEffect.audioClip;
			audio.volume = collisionSoundEffect.volumeModifier * baseFootAudioVolume;
			audio.pitch = Random.Range(1.0f - soundEffectPitchRandomness, 1.0f + soundEffectPitchRandomness);
			audio.Play();		
		}
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void Reset() {
		rigidbody.isKinematic = true;
		collider.isTrigger = true;
	}	
}
