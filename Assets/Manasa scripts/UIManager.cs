using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;    

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private TextMeshProUGUI scoreText;   // Drag ScoreText here

    private int score = 0;
    private bool gameStarted = false;
    private bool gameOver = false;

    void Start()
    {
        playBtn.onClick.AddListener(Play);
        quitBtn.onClick.AddListener(Quit);
        UpdateScoreUI();
    }

    void Update()
    {
        // Increase score when left mouse button is clicked
        if (gameStarted && !gameOver)
        {
            if (Input.GetMouseButtonDown(0))   // 0 = Left Click
            {
                score++;
                UpdateScoreUI();
            }
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score : " + score;
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}