using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool _braikingMove;
    private PlayerControler _player;


    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        _braikingMove = false;
    }
	
	// Update is called once per frame
	void Update () {
		StopPlayerMove();
	}

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            _braikingMove = true;
        }
    }

    private void StopPlayerMove()
    {
        if (_braikingMove)
        {
            _player.Speed = Mathf.Lerp(_player.Speed, 0, 5*Time.deltaTime);
            if (_player.Speed < 0.01f)
            {
                _braikingMove = false;
                _player.Speed = 0;
            }
        }

    }
}
