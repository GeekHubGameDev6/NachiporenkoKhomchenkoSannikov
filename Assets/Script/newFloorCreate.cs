using System.Collections;using System.Collections.Generic;using UnityEngine;

public class newFloorCreate : MonoBehaviour
{
    public GameObject PrefabFloor;

	// Use this for initialization
	void Start ()
	{
	    for (int i = 1; i < 134; i++)
	    {
	        Instantiate(PrefabFloor, new Vector3(transform.position.x, transform.position.y - 0.89f * i,
                transform.position.z + 5.052f*i), transform.rotation,transform.parent);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
