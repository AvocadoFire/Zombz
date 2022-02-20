using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	[SerializeField] GameObject loseUI;

    private void Start()
    {
        loseUI.SetActive(false);
    }
    public void Loser()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
