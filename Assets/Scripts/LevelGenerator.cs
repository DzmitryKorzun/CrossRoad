
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int counter = 0;


    public GameObject[] let = new GameObject[10];
    public GameObject[] platforms = new GameObject[5];

    int platform_posX;
    int typePlatform;

    void Start()
    {
        Instantiate(let[0]);
        let[0].transform.position = new Vector3(4.5f, 0.03f, 0);
        Instantiate(let[0]);
        let[0].transform.position = new Vector3(-4.5f, 0.03f, 0);
        for (int i = 0; i < 10; i++)
        {
            typePlatform = Random.Range(0, 3);

            Instantiate(platforms[typePlatform]);
            platforms[0].transform.position = new Vector3(0, 0.01f, i);
        }

    }

    void Update()
    {


    }




}
