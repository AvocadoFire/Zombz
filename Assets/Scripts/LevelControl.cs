using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	[SerializeField] GameObject loseUI;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject instructionsUI;
    PlayerController player;

    static bool isStarted;

    private void Start()
    {   
        print(isStarted);
        
        player = FindObjectOfType<PlayerController>();
        if (!isStarted)
        {
            Time.timeScale = 0;
            loseUI.SetActive(false);
            startUI.SetActive(true);
            player.gameObject.SetActive(false);
        }
        isStarted = true;
        print(isStarted);

    }
    public void Loser()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0;
        player.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
    }

    //public void Instructions()
    //{
    //    instructionsUI.SetActive(true);
    //    Time.timeScale = 0;
    //    player.gameObject.SetActive(false);
    //}

    //public void Back()
    //{
    //    instructionsUI.SetActive(false);
    //    startUI.SetActive(true);
    //}



}
