using UnityEngine;
using System.Collections;

public class NineBlockPuzzle : MonoBehaviour 
{
	public GameObject[] m_Positions = null ;
	public GameObject[] m_Objects = null ;
	int currentIndex = 0 ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{
			Vector3 pos = m_Positions[ currentIndex ].transform.position ;
			pos.z = m_Objects[ currentIndex ].transform.position.z ;
			m_Objects[ currentIndex ].transform.position = pos ;

			currentIndex++ ;
		}
	}
}



