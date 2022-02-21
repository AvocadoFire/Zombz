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
        player = FindObjectOfType<PlayerController>();
        startUI.SetActive(!isStarted);
        player.gameObject.SetActive(isStarted);
        loseUI.SetActive(false);

        if (!isStarted)
        {
            Time.timeScale = 0;        
            isStarted = true;
        }
        else
        {
            Time.timeScale = 1;
        }




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
