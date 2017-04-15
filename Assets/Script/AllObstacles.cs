using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObstacles : MonoBehaviour
{
    public GameObject[] LetsPrefab;
    public GameObject Like;
    public GameObject CoinCountainer,ObstaclesCounteiner;

    public int ObstaclesLenght;
    public int MinDistBetweenObstaclebyZ;
    public int MaxDistBetweenObstaclebyZ;
    public int GenerateLinebyX;

	// Use this for initialization
	void Start () {
		CreateLets();
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

    public void CreateLets()
    {
        Vector3 position = Vector3.zero;
        RaycastHit hit;
        for (int i = 0; i < ObstaclesLenght; i++)
        {
            int randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
            int randomZpos = MinDistBetweenObstaclebyZ + Random.Range(0, MaxDistBetweenObstaclebyZ);
            GameObject let = RandomLet;
            position = new Vector3(randomXpos,position.y,position.z + randomZpos);
            if(Physics.Raycast(position,Vector3.down,out hit))
                position = new Vector3(position.x,hit.point.y,position.z);
            Instantiate(let, position + let.transform.position, let.transform.rotation, ObstaclesCounteiner.transform);
            randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
            randomZpos = MinDistBetweenObstaclebyZ + Random.Range(0, MaxDistBetweenObstaclebyZ);
            position = new Vector3(randomXpos, position.y, position.z + randomZpos);
            if (Physics.Raycast(position, Vector3.down, out hit))
                position = new Vector3(position.x, hit.point.y, position.z);
            Instantiate(Like, position + Like.transform.position, Like.transform.rotation, CoinCountainer.transform);
        }
    }
        
}
