using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance; //THIS

    public Button startButton;
    public TextMeshProUGUI hiScore;

    public List<GameObject> shipPrefabs = new List<GameObject>();

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

    public void Launch(GameObject ship)
    {
        chosenShip = ship;
        SceneManager.LoadScene("Main");
    }
}
