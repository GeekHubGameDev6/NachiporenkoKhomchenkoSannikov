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

    private Text _score;
    public Text WinScore;
    public Text LastPosInHightScore;


    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _braikingMove = false;
    }
	
	// Update is called once per frame
	void Update () {
		StopPlayerMove();
	}

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<AudioSource>().Play();
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
                WinScore.text = _score.text;
                WinMessage.transform.GetChild(0).gameObject.SetActive(true);
                if (Convert.ToInt32(_score.text) > Convert.ToInt32(LastPosInHightScore.text))
                {
                    HightScoreParent.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }

    }
}
