using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsController : MonoBehaviour {

	public Text bronzeCupList;
	public Text silverCupList;
	public Text goldenCupList;

	void Start () {
		SetScoreForCup ("BrontheLeaderboard", bronzeCupList);
		SetScoreForCup ("SilverLeaderBoard", silverCupList);
		SetScoreForCup ("GoldCup", goldenCupList);

	}

	private void SetScoreForCup(string cupName, Text cupText)
	{
		if (PlayerPrefs.HasKey(cupName)) {
			cupText.text = "";
			var playerlist = JsonUtility.FromJson<BrontheLeaderboard>(PlayerPrefs.GetString(cupName));
			for (int i = 0; i < playerlist.PlayerNames.Count; i++) {
				var name = playerlist.PlayerNames[i]; // Name
				var score = "" + PlayerPrefs.GetInt(name); // Score
				cupText.text += (i + 1) + ".\t" + name + ":\t" + score + "\n";
			}
		}
	}
}
