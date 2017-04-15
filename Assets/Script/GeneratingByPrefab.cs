using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingByPrefab : MonoBehaviour
{
    public GameObject PrefabObj;
    public float WaitBeforGebnerate;

    private Vector3 _curPos;
    private Transform _firsObjpos;
    private Vector3 _lastPos;
    
    public float CloneCount;

    void Awake()
    {
        LineOfObjectGenerator();
    }
    
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LineOfObjectGenerator()
    {
        _firsObjpos = transform.GetChild(0);
        _curPos = _firsObjpos.localPosition;
        for (int i = 0; i < CloneCount; i++)
        {
            _curPos += _firsObjpos.forward * (_firsObjpos.GetComponent<BoxCollider>().size.z * _firsObjpos.lossyScale.z);
            Instantiate(PrefabObj, _curPos, _firsObjpos.transform.rotation, transform);
            if (i == CloneCount - 1)
                _lastPos = _curPos + _firsObjpos.forward * ((_firsObjpos.GetComponent<BoxCollider>().size.z * _firsObjpos.lossyScale.z) / 2);
        }
    }

    //IEnumerator WaitBeforGenerate()
    //{
    //    yield return new WaitForSeconds(WaitBeforGebnerate);
    //}
    public Vector3 LastPos
    {
        get { return _lastPos; }
        set { _lastPos = value; }
    }
}
