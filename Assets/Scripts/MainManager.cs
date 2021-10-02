using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class MainManager : MonoBehaviour
{
    public static MainManager instance; //THIS

    public TextMeshProUGUI hiScoreText;
    public InputField playerNameField;
    public string playerName { get; private set; }

    public int hiScore;
    public string hiPlayer;

    [SerializeField] public GameObject chosenShip { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this; //THIS
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RefreshHiScore();
    }

    private void Update()
    {
        //RefreshHiScore();
    }

    public void Launch(GameObject ship)
    {
        chosenShip = ship;
        playerName = playerNameField.text;
        SaveHiScore(false);
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Main");
    }

    [System.Serializable]
    class HiScore
    {
        public int score; //hi score
        public string name; //current name of the player
        public string hiPlayer; //name of the player with highest score
    }

    public void SaveHiScore(bool wipe)
    {
        HiScore toWrite = new HiScore();
        if (!wipe)
        {
            toWrite.score = hiScore;
            Debug.Log(hiScore);
            toWrite.name = playerName;
            Debug.Log(playerName);
            toWrite.hiPlayer = hiPlayer;
            Debug.Log(hiPlayer);
        }
        else
        {
            toWrite.score = 0;
            toWrite.name = "";
            toWrite.hiPlayer = "";
        }


        string path = Application.persistentDataPath + "/savefile.json";

        string json = JsonUtility.ToJson(toWrite);

        File.WriteAllText(path, json);

    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HiScore loadedScore = JsonUtility.FromJson<HiScore>(json);

            playerName = loadedScore.name;
            hiPlayer = loadedScore.hiPlayer;
            hiScore = loadedScore.score;

        }

    }

    public void RefreshHiScore()
    {
        LoadHiScore();
        hiScoreText.SetText("HiScore: " + hiScore + " by " + hiPlayer);
        playerNameField.text = playerName;
    }

}
