using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObstacles : MonoBehaviour
{
    public GameObject[] LetsPrefab;
    public GameObject Like;
    public GameObject CoinCountainer,ObstaclesCounteiner;
    public GeneratingByPrefab FloorContainer;

    public int MinDistBetweenObstaclebyZ;
    public int MaxDistBetweenObstaclebyZ;
    public int GenerateLinebyX;

    private Vector3 _position;
	// Use this for initialization
	void Start ()
	{
	    _position = Vector3.zero;
        StartCoroutine(WaitAsecond());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject RandomLet
    {
        get
        {
            GameObject selectedObj;
            int randomElement = Random.Range(0, LetsPrefab.Length);
            selectedObj = LetsPrefab[randomElement];
            return selectedObj;
        }
    }

    public void CreateObstacles()
    {
        RaycastHit hit;
        while (_position.z < FloorContainer.LastPos.z - 30f )
        {
            var randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
            var randomZpos = MinDistBetweenObstaclebyZ + Random.Range(0, MaxDistBetweenObstaclebyZ);
            GameObject let = RandomLet;
            _position = new Vector3(randomXpos,_position.y,_position.z + randomZpos);
            if(Physics.Raycast(_position,Vector3.down,out hit,500f))
                _position = new Vector3(_position.x,hit.point.y,_position.z);
            Instantiate(let, _position + let.transform.position, let.transform.rotation, ObstaclesCounteiner.transform);
            randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
            randomZpos = MinDistBetweenObstaclebyZ + Random.Range(0, MaxDistBetweenObstaclebyZ);
            _position = new Vector3(randomXpos, _position.y, _position.z + randomZpos);
            if (Physics.Raycast(_position, Vector3.down, out hit))
                _position = new Vector3(_position.x, hit.point.y, _position.z);
            var regretcoin = Random.Range(1, 2);
            if (regretcoin == 1)
                Instantiate(Like, _position + Like.transform.position, 
                    Like.transform.rotation, CoinCountainer.transform);
        }
    }

    IEnumerator WaitAsecond()
    {
        yield return new WaitForEndOfFrame();
        CreateObstacles();
    }
}
