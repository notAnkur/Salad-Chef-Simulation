using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] GameObject LoadingOverlay;
    public void StartSinglePlayer()
    {
        LoadingOverlay.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    public void StartCouchCoop()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
