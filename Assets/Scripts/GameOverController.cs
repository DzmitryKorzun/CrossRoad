using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text currentRun;
    public Text Record;
    public Text coinTxt;
    public Text TxtButton;
    private void Start()
    {
        currentRun.text += PlayerPrefs.GetInt("current").ToString();
        Record.text += PlayerPrefs.GetInt("record").ToString();
        coinTxt.text = PlayerPrefs.GetInt("coins").ToString();
        if (PlayerPrefs.GetInt("sound", 0) == 0)
        {
            TxtButton.text = "Включены";
        }
        else
        {
            TxtButton.text = "Выключены";
        }
    }

    public void newGame()
    {
        
        SceneManager.LoadSceneAsync(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void soundSet()
    {
        if (PlayerPrefs.GetInt("sound", 0) == 0)
        {
            PlayerPrefs.SetInt("sound", 1);
            TxtButton.text = "Включены";
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
            TxtButton.text = "Выключены";
        }
    }

}
