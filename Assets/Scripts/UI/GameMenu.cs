using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject GameOverContainer;
    [SerializeField] private TextMeshProUGUI scoreValue;

    private void Start()
    {
        GameOverContainer.SetActive(false);
    }

    public void GameOver(int score)
    {
        GameOverContainer.SetActive(true);
        scoreValue.SetText(score.ToString());
    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
