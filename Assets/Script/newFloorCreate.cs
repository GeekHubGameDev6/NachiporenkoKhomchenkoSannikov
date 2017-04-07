using System.Collections;using System.Collections.Generic;using UnityEngine;

public class newFloorCreate : MonoBehaviour
{
    public GameObject PrefabFloor;

	// Use this for initialization
	void Start ()
	{
	    for (int i = 1; i < 20; i++)
	    {
	        Instantiate(PrefabFloor, new Vector3(0, transform.position.y - 3.4695f * i, transform.position.z + 19.69f*i),
	            transform.rotation);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
