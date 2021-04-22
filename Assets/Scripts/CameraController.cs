using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Update()
    {
        if (player.transform.position.z - 2 > transform.position.z)
        {
            speed = 5f;
        }
        else
        {
            speed = 0.2f;
        }
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (player.transform.position.z <= transform.position.z)
        {
            player.GetComponent<CoinCollectOrDeath>().Death();
        }

    }

}



