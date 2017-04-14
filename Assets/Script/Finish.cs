using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public bool _braikingMove;

    private PlayerControler _player;

    public GameObject WinMessage;
    public GameObject HightScoreParent;

    public Text Score;
    public Text WinScore;
    public Text LastPosInHightScore;


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
                WinScore.text = Score.text;
                WinMessage.transform.GetChild(0).gameObject.SetActive(true);
                if (Convert.ToInt32(Score.text) > Convert.ToInt32(LastPosInHightScore.text))
                {
                    HightScoreParent.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }

    }
}
