using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gamePlayCanvas;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
    }

    public void PlayAndReplay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnableGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
    }
}
