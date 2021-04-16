using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] let = new GameObject[10];
    public GameObject[] platforms = new GameObject[5];
    

    void Start()
    {
        Instantiate(let[0]);
        let[0].transform.position = new Vector3(4.5f, 0.01f, 0);
        Instantiate(let[0]);
        let[0].transform.position = new Vector3(-4.5f, 0.01f, 0);
    }

    void Update()
    {
        
    }
}
