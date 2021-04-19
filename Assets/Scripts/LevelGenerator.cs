
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int counter = 0;


    public GameObject[] let = new GameObject[10];
    public GameObject[] type_platforms = new GameObject[5];
    public List<GameObject> platforms;

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
            if (i < 5) typePlatform = 0;    
            Instantiate(type_platforms[typePlatform], new Vector3(0, 0.01f, counter), Quaternion.identity);
            platforms.Add(type_platforms[typePlatform]);
            letGenerator(typePlatform, counter);
            counter++;
        }

    }

    void Update()
    {


    }

    private void letGenerator(int typePlatform, int numStep)
    {
        if (typePlatform == 0)
        {
            int numLet = Random.Range(1, 3);
            for (int i = 0; i<numLet; i++)
            {
                int tLet = Random.Range(1, 4);
                int let_pos = Random.Range(-4, 4);
                Instantiate(let[tLet], new Vector3(let_pos, 0.01f, numStep), Quaternion.Euler(-90,0,0));
            }
        }
    }

    public void destroyPlatform()
    {
        Destroy(platforms[0]);
        platforms.RemoveAt(0);
    }

    public void addNewPlatform()
    {
        typePlatform = Random.Range(0, 3);
        Instantiate(type_platforms[typePlatform], new Vector3(0, 0.01f, counter), Quaternion.identity);
        platforms.Add(type_platforms[typePlatform]);
        letGenerator(typePlatform, counter);
        counter++;
    }
   




}
