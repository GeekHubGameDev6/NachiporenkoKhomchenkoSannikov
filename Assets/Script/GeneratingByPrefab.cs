using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingByPrefab : MonoBehaviour
{
    public GameObject PrefabObj;

    public Vector3 DistanceBetweenObj;
    private Vector3 _curPos;
    private Vector3 _firsObjpos;
    private Vector3 _lastPos;
    
    public float CloneCount;


    
	// Use this for initialization
	void Start ()
	{
	    _firsObjpos = transform.GetChild(0).position;
	    for (int i = 0; i < CloneCount; i++)
	    {
	        _curPos = new Vector3(DistanceBetweenObj.x, _firsObjpos.y + DistanceBetweenObj.y * i,
                _firsObjpos.z + DistanceBetweenObj.z * i);
	        Instantiate(PrefabObj, _curPos, PrefabObj.transform.rotation, transform);
	        if (i == CloneCount - 1)
	            _lastPos = _curPos;
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 LastPos
    {
        get { return _lastPos; }
        set { _lastPos = value; }
    }
}
