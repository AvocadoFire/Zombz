using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	[SerializeField] GameObject loseUI;
    [SerializeField] GameObject startUI;

    private void Start()
    {
        Time.timeScale = 0;
        loseUI.SetActive(false);
        startUI.SetActive(true);
    }
    public void Loser()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        Time.timeScale = 1;
    }
}
