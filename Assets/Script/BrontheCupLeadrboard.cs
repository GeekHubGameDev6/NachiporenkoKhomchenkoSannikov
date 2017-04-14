using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BrontheCupLeadrboard : MonoBehaviour
{
    public Transform ScoreHolder;
    public Transform PlayerNameHolder;
    public Text CurentScore;

    private string _playerName;
    private string CurPlayer;
    private string _json;

    private BrontheLeaderboard _playerlist;

    // Use this for initialization
    void Start()
    {
        DownloadLeaderboard();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DownloadLeaderboard()
    {
        if (!PlayerPrefs.HasKey("BrontheLeaderboard"))
        {
            _playerlist = new BrontheLeaderboard { PlayerNames = new List<string>() };
            var a = JsonUtility.ToJson(_playerlist);
            PlayerPrefs.SetString("BrontheLeaderboard", a);
            Debug.Log("New Leaderboard Created");
        }
        _playerlist = JsonUtility.FromJson<BrontheLeaderboard>(PlayerPrefs.GetString("BrontheLeaderboard"));
        for (int i = 0; i < _playerlist.PlayerNames.Count; i++)
        {
            PlayerNameHolder.GetChild(i).GetComponent<Text>().text =
                _playerlist.PlayerNames[i];
            ScoreHolder.GetChild(i).GetComponent<Text>().text = "" +
                PlayerPrefs.GetInt(_playerlist.PlayerNames[i]);
        }

    }

    public string CurentPlayerName
    {
        get
        {
            if (string.IsNullOrEmpty(CurPlayer))
            {
                CurPlayer = "";
            }
            return CurPlayer;
        }
        set { CurPlayer = value; }
    }

    public void NewHightScore()
    {
        _playerlist = JsonUtility.FromJson<BrontheLeaderboard>(PlayerPrefs.GetString("BrontheLeaderboard"));
        var playerCount = _playerlist.PlayerNames.Count;
        Debug.Log("CurentCount " + playerCount);
        string newScore = CurentScore.text;
        bool moved = false;
        int playerPos = playerCount;

        for (int i = playerCount; i > 0; i--)
        {
            Debug.Log(Convert.ToInt32(CurentScore.text) + "  >?  " 
                + Convert.ToInt32(ScoreHolder.GetChild(i - 1).GetComponent<Text>().text) + " i = " + i);
            if (Convert.ToInt32(CurentScore.text) >
                Convert.ToInt32(ScoreHolder.GetChild(i - 1).GetComponent<Text>().text))
            {
                playerPos = i;
                moved = true;
            }
        }
        if (moved == false)
        {
            _playerlist.PlayerNames.Add(CurentPlayerName);
            Debug.Log("Lower Top");
        }
        if (moved)
        {
            _playerlist.PlayerNames.Insert(playerPos-1, CurentPlayerName);
            Debug.Log("Better top");
        }
        if (_playerlist.PlayerNames.Count == 11)
        {
            PlayerPrefs.DeleteKey(_playerlist.PlayerNames.Last());
            _playerlist.PlayerNames.RemoveAt(10);
        }
        PlayerPrefs.SetInt(CurentPlayerName, Convert.ToInt32(newScore));
        _json = JsonUtility.ToJson(_playerlist);
        PlayerPrefs.SetString("BrontheLeaderboard", _json);
        DownloadLeaderboard();

    }

    public class BrontheLeaderboard
    {
        [SerializeField]
        public List<string> PlayerNames;

    }
}
