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

    private Text _score;

    private int _curScore;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, RotateSpeed*Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        GetComponent<AudioSource>().Play();
        int.TryParse(_score.text,out _curScore);
        _curScore++;
        _score.text ="" + _curScore;
        GetComponent<Renderer>().enabled = false;
        //gameObject.SetActive(false);
    }
}
