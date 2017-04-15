using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingByPrefab : MonoBehaviour
{
    public GameObject PrefabObj;

    public Vector3 DistanceBetweenObj;
    private Vector3 _curPos;
    private Transform _firsObjpos;
    private Vector3 _lastPos;
    
    public float CloneCount;


    
	// Use this for initialization
	void Start ()
	{
	    _firsObjpos = transform.GetChild(0 );
	    _curPos = _firsObjpos.position;
	    for (int i = 0; i < CloneCount; i++)
	    {
	        _curPos += _firsObjpos.forward * (_firsObjpos.GetComponent<BoxCollider>().size.z * _firsObjpos.localScale.z);  
	        Instantiate(PrefabObj, _curPos, PrefabObj.transform.rotation, transform);
	        if (i == CloneCount - 1)
	            _lastPos = _curPos + _firsObjpos.forward * ((_firsObjpos.GetComponent<BoxCollider>().size.z * _firsObjpos.localScale.z)/2);
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
