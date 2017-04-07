using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public bool LeftMoving, RightMoving,Moving;

    public float TurnSpeed,Speed;

    private CharacterController _charterMove;

    private Vector3 _forwardmove;
    // Use this for initialization
    void Start()
    {
        LeftMoving = false;
        RightMoving = false;
        Moving = true;
      //  StartCoroutine(ForwardMove());
        _charterMove = GetComponent<CharacterController>();
        _forwardmove = new Vector3(0,-1f,1);
    }

    // Update is called once per frame
    void Update()
    {
        _charterMove.Move(_forwardmove * Speed);
        if (LeftMoving)
        {
            _charterMove.Move(Vector3.left * TurnSpeed);
        }
        if (RightMoving)
        {
            _charterMove.Move(Vector3.right * TurnSpeed);
        }
    }

    public void BeginMoveLeft()
    {
        LeftMoving = !LeftMoving;

    }
    public void BeginMoveRight()
    {
        RightMoving = !RightMoving;
    }


}
