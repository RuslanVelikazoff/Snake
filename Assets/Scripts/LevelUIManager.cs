using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public Button exitLevelButton;

    public Text scoreText;

    public Button restartButton;
    public Button homeButton;

    private Snake player;

    private void Start()
    {
        player = FindObjectOfType<Snake>();

        ButtonFunc();
    }

    private void Update()
    {
        SetText();
    }

    private void ButtonFunc()
    {
        if (exitLevelButton != null)
        {
            exitLevelButton.onClick.RemoveAllListeners();
            exitLevelButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            });
        }

        if (homeButton != null)
        {
            homeButton.onClick.RemoveAllListeners();
            homeButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    private void SetText()
    {
        scoreText.text = "" + player.score;
    }
}
