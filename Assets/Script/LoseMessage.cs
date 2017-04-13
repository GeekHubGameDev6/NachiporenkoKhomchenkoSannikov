using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMessage : MonoBehaviour
{
    public GameObject LoseMassageObj;

    public bool SetActive;

    public Text ScoreInMessage;
    public Text Score;
    void Update () {
		ActivedChild();
	}

    public void ActivedChild()
        {
            if (SetActive)
            {
                ScoreInMessage.text = Score.text;
                LoseMassageObj.SetActive(true);
                SetActive = false;
            }
        }
    }

