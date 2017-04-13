using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LikeRotation : MonoBehaviour
{
    public float RotateSpeed;

    private Text Score;

    private int _curScore;

    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, RotateSpeed*Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        int.TryParse(Score.text,out _curScore);
        _curScore++;
        Score.text ="" + _curScore;
        gameObject.SetActive(false);
    }
}
