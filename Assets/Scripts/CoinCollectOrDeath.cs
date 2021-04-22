using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollectOrDeath : MonoBehaviour
{
    public GameObject person;
    public Text coinText;
    public int coinCollect;
    public AudioClip coin_s;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        coinCollect = PlayerPrefs.GetInt("coins");
        coinText.text = coinCollect.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Coin(Clone)")
        {
            audio.PlayOneShot(coin_s);
            coinCollect++;
            collision.gameObject.SetActive(false);
            PlayerPrefs.SetInt("coins", coinCollect);
            coinText.text = coinCollect.ToString();            
        }

        if (collision.gameObject.name == "CAR_01(Clone)" || collision.gameObject.name == "Car_04(Clone)" || collision.gameObject.name == "train(Clone)")
        {
            Death();
        }


    }
    public void Death()
    {
        int currentStep = this.GetComponent<PersonController>().stepCounter;
        int record = PlayerPrefs.GetInt("record", 0);
        PlayerPrefs.SetInt("current", currentStep);
        if (record <= currentStep) PlayerPrefs.SetInt("record", currentStep);
        PersonController.SwipeEvent -= person.GetComponent<PersonController>().CheckInput;
        SceneManager.LoadScene(2);
    }
}
