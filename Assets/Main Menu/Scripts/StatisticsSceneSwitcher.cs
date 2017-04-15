using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatisticsSceneSwitcher : MonoBehaviour {

	public AudioSource menuMusic;

	void Start ()
	{
		menuMusic.time = Globals.menuThemeOffset;
	}

	public void ChangeScene(string name)
	{
		Globals.menuThemeOffset = menuMusic.time;
		SceneManager.LoadScene(name);
	}

}
