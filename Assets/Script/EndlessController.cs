using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessController : MonoBehaviour
{
    public GeneratingByPrefab FloorContainer, LeftLensCountainer, RightLensCountainer;
    public AllObstacles AllObstacles;

    private Transform _player;
    private bool _check1;
    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _check1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_player.position, FloorContainer.LastPos) < 250)
            NewPartGeneration();
    }

    public void NewPartGeneration()
    {
        FloorContainer.LineOfObjectGenerator(FloorContainer.LastObj, 20);
        LeftLensCountainer.LineOfObjectGenerator(LeftLensCountainer.LastObj, 162);
        RightLensCountainer.LineOfObjectGenerator(RightLensCountainer.LastObj, 162);
        AllObstacles.CreateObstacles();
    }
}
