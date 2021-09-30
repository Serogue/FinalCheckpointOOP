using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //THIS

    float xRange = 7f;
    float yRange = 4.5f; //screen boundaries

    public Vector2 playerPos { get; private set; }

    private PlayerController m_Player; //having fun with properties
    public PlayerController player
    {
        get
        {
            if (m_Player != null)
            {
                return m_Player;
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (m_Player == null)
            {
                m_Player = value;
            }
            if (m_Player != null && gameOver)
            {
                m_Player = null;
            }
        }
    }

    public Slider healthBar;
    bool gameOver = false;

    public TextMeshProUGUI scoreText;
    [SerializeField]int curScore = 0;
    

    private void Awake() //THIS
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update() //handle the input
    {
        scoreText.text = "Score: " + curScore;
        if (m_Player != null)
        {

            healthBar.value = m_Player.currentHull / m_Player.maxHull;
            if (m_Player.currentHull <= 0)
            {
                //gameOver = true;
                //Destroy(m_Player.gameObject);
                //player = null;
            }
            
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Player.Fire();
            }
        }
    }

    private void FixedUpdate()
    {
        if (m_Player != null)
        {
            HandlePlayer();
        }

    }

    private void HandlePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerPos = m_Player.transform.position;

        Vector2 newPos = new Vector2((horizontalInput * m_Player.speed * Time.deltaTime), (verticalInput * m_Player.speed * Time.deltaTime)) + playerPos;

        if (newPos.x < -xRange || newPos.x > xRange)
        {
            newPos.x = playerPos.x;
        }
        if (newPos.y < -yRange || newPos.y > yRange)
        {
            newPos.y = playerPos.y;

        }

        m_Player.transform.position = newPos;
    }

    public void AddScore(int scoresToAdd)
    {
        if (scoresToAdd >= 0)
        {
            curScore += scoresToAdd;
        }

    }

}
