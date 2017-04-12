using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLets : MonoBehaviour
{
    public GameObject[] LetsPrefab;

    public int LetsLenght;
    public int MinDistBetweenLetbyZ;
    public int MaxDistBetweenLetbyZ;
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
        for (int i = 0; i < LetsLenght; i++)
        {
            int randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
            int randomZpos = MinDistBetweenLetbyZ + Random.Range(0, MaxDistBetweenLetbyZ);
            GameObject let = RandomLet;
            position = new Vector3(randomXpos,position.y,position.z + randomZpos);
            if(Physics.Raycast(position,Vector3.down,out hit))
                position = new Vector3(position.x,hit.point.y,position.z);
            Instantiate(let, position + let.transform.position, let.transform.rotation, transform);
        }
    }
        
}
