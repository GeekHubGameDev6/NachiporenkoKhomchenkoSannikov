using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMessage : MonoBehaviour
{
    public GameObject LoseMassageObj;

    public bool SetActive;

    public Text ScoreInMessage;
    private Text _score;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    void Update () {
		ActivedChild();
	}
    public void ActivedChild()
        {
            if (SetActive)
            {
                ScoreInMessage.text = _score.text;
                LoseMassageObj.SetActive(true);
                SetActive = false;
            }
        }
    }

