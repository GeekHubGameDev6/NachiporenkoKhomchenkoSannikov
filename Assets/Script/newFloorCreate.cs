using System.Collections;using System.Collections.Generic;using UnityEngine;

public class newFloorCreate : MonoBehaviour
{
    public GameObject PrefabFloor;

    public Vector3 DistanceBetweenObj;

    public int CloneCount;

    public bool FinishGenerator;
    public GameObject PrefabFinish;

    private Vector3 _lastClone;

	// Use this for initialization
	void Start ()
	{
	    for (int i = 1; i < CloneCount; i++)
	    {
	        Instantiate(PrefabFloor, new Vector3(DistanceBetweenObj.x,transform.position.y +
                DistanceBetweenObj.y * i,transform.position.z+
                DistanceBetweenObj.z*i), transform.rotation,transform.parent);
	        _lastClone = new Vector3(DistanceBetweenObj.x, transform.position.y +
	                                                       DistanceBetweenObj.y*i, transform.position.z +
	                                                                               DistanceBetweenObj.z*i);
        }
	    if (FinishGenerator)
	    {
	        Instantiate(PrefabFinish,
	            _lastClone + new Vector3(0f, +DistanceBetweenObj.y/2,
	                PrefabFloor.transform.localScale.z/2 + PrefabFinish.transform.localScale.z /2
	            ), PrefabFinish.transform.rotation);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
