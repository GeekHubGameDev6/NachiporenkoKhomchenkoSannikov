using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTouch : MonoBehaviour
{
    private PlayerControler _player;
    private LoseMessage _attaceScript;

	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        _attaceScript = GameObject.FindGameObjectWithTag("MessageDie").GetComponent<LoseMessage>();
	}

	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        var audio = GetComponent<AudioSource>();
		audio.volume = 0.25f;
		audio.Play ();

        _player.Speed = 0;
        _attaceScript.SetActive = true;
    }
}
