using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    void Awake()
    {
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }


    public GameObject setting_panel;
    public GameObject recTxt;
    public GameObject coinTxt;
    public Text TxtButton;
    void Start()
    {
 



        recTxt.GetComponent<Text>().text = "Рекорд: "+PlayerPrefs.GetInt("record").ToString();
        coinTxt.GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();

        if (PlayerPrefs.GetInt("sound", 0) == 1)
        {
            TxtButton.text = "Включены";

        }
        else
        {
            TxtButton.text = "Выключены";
        }

        Debug.Log(PlayerPrefs.GetInt("sound", 0) + "");


    }


    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void panelClose()
    {
        setting_panel.SetActive(false);
    }

    public void panelOpen()
    {
        setting_panel.SetActive(true);
    }

    public void resetRec()
    {
        PlayerPrefs.SetInt("record", 0);
        recTxt.GetComponent<Text>().text = "Рекорд: " + PlayerPrefs.GetInt("record").ToString();
    }

    public void applaySound()
    {
        if (PlayerPrefs.GetInt("sound",0)==0)
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
