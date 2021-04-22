using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    public int counter = -5;

    public GameObject let_barelObj;
    public GameObject let_stoneObj;
    public GameObject let_treeObj;
    public GameObject platform_1_Obj;
    public GameObject platform_2_Obj;
    public GameObject platform_3_Obj;
    public GameObject border;
    public GameObject car_1_Obj;
    public GameObject car_2_Obj;
    public GameObject train_Obj;
    public GameObject coins_Obj;

    public GameObject let_barelObj_container;
    public GameObject let_stoneObj_container;
    public GameObject let_treeObj_container;
    public GameObject platform_1_container;
    public GameObject platform_2_container;
    public GameObject platform_3_container;
    public GameObject car_1_container;
    public GameObject car_2_container;
    public GameObject train_container;
    public GameObject coins_container;

    public List<GameObject> let_barel;
    public List<GameObject> let_stone;
    public List<GameObject> let_tree;
    public List<GameObject> platform_1;
    public List<GameObject> platform_2;
    public List<GameObject> platform_3;
    public List<GameObject> car_1;
    public List<GameObject> car_2;
    public List<GameObject> train;
    public List<GameObject> coins;

    public int pos_plat_2;
    public int pos_plat_3;

    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            AddBarelObj();
            AddStoneObj();
            AddTreeObj();
            AddPlatform_1_Obj();
            AddPlatform_2_Obj();
            AddPlatform_3_Obj();
            AddCar_1();
            AddCar_2();
            AddTrain();
            AddCoins();
        }

        for (int i = 0; i < 50; i++)
        {
            AddCar_1();
            AddCar_2();
        }


        Instantiate(border, new Vector3(-4.5f, 0.01f, 0), Quaternion.identity);
        Instantiate(border, new Vector3(4.5f, 0.01f, 0), Quaternion.identity);
        firstGeneration();
    }

    private void AddBarelObj()
    {
        var tmp = Instantiate(let_barelObj);
        tmp.transform.SetParent(let_barelObj_container.transform);
        let_barel.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddStoneObj()
    {
        var tmp = Instantiate(let_stoneObj);
        tmp.transform.SetParent(let_stoneObj_container.transform);
        let_stone.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddTreeObj()
    {
        var tmp = Instantiate(let_treeObj);
        tmp.transform.SetParent(let_treeObj_container.transform);
        let_tree.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddPlatform_1_Obj()
    {
        var tmp = Instantiate(platform_1_Obj);
        tmp.transform.SetParent(platform_1_container.transform);
        platform_1.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddPlatform_2_Obj()
    {
        var tmp = Instantiate(platform_2_Obj);
        tmp.transform.SetParent(platform_2_container.transform);
        platform_2.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddPlatform_3_Obj()
    {
        var tmp = Instantiate(platform_3_Obj);
        tmp.transform.SetParent(platform_3_container.transform);
        platform_3.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddCar_1()
    {
        var tmp = Instantiate(car_1_Obj);
        tmp.transform.SetParent(car_1_container.transform);
        car_1.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddCar_2()
    {
        var tmp = Instantiate(car_2_Obj);
        tmp.transform.SetParent(car_2_container.transform);
        car_2.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddTrain()
    {
        var tmp = Instantiate(train_Obj);
        tmp.transform.SetParent(train_container.transform);
        train.Add(tmp);
        tmp.SetActive(false);
    }
    private void AddCoins()
    {
        var tmp = Instantiate(coins_Obj);
        tmp.transform.SetParent(coins_container.transform);
        coins.Add(tmp);
        tmp.SetActive(false);
    }
    private void firstGeneration()
    {
        for (int i = 0; i < 15; i++)
        {
            platform_1[i].SetActive(true);
            platform_1[i].transform.position = new Vector3(0, 0.002f, counter);
            if (counter > 0) letGenerator(counter);
            counter++;
        }
    }

    public void lvl_generator()
    {
        int randTypePlatform = Random.Range(1, 4);
        addPlatform(randTypePlatform);
    }
    private void addPlatform(int typePlatform)
    {
        switch (typePlatform)
        {
            case 1:

                var plat = platform_1.Find(item => item.activeSelf == false);
                plat.transform.position = new Vector3(0, 0.002f, counter);
                plat.SetActive(true);
                letGenerator(counter);
                coinGenerator(counter);
                counter++;
                break;

            case 2:

                var plat2 = platform_2.Find(item => item.activeSelf == false);
                plat2.transform.position = new Vector3(0, 0.002f, counter);
                plat2.SetActive(true);
                pos_plat_2 = counter;
                coinGenerator(counter);
                counter++;
                break;

            case 3:

                var plat3 = platform_3.Find(item => item.activeSelf == false);
                plat3.transform.position = new Vector3(0, 0.002f, counter);
                plat3.SetActive(true);
                pos_plat_3 = counter;
                coinGenerator(counter);
                counter++;
                break;

        }
    }

    private void letGenerator(int numStep)
    {
        int numLet = Random.Range(5, 8);

        for (int i = 0; i < numLet; i++)
        {
            int tLet = Random.Range(1, 4);
            int let_pos = Random.Range(-10, 10);

            switch (tLet)
            {
                case 1:
                    var let_bar = let_barel.Find(item => item.activeSelf == false);
                    if (let_bar != null)
                    {
                        let_bar.transform.position = new Vector3(let_pos, 0.002f, counter);
                        let_bar.SetActive(true);
                    }

                    break;
                case 2:
                    var let_st = let_stone.Find(item => item.activeSelf == false);
                    if (let_st != null)
                    {
                        let_st.transform.position = new Vector3(let_pos, 0.002f, counter);
                        let_st.SetActive(true);
                    }

                    break;
                case 3:
                    var let_tr = let_tree.Find(item => item.activeSelf == false);
                    if (let_tr != null)
                    {
                        let_tr.transform.position = new Vector3(let_pos, 0.002f, counter);
                        let_tr.SetActive(true);
                    }

                    break;
            }
        }

    }
    private void coinGenerator(int numStep)
    {
        int randYesNo = Random.Range(1, 10);
        int let_pos = Random.Range(-4, 4);

        if (randYesNo == 1)
        {
            var tmp = coins.Find(item => item.activeSelf == false);
            tmp.transform.position = new Vector3(let_pos, 0.002f, counter);
            tmp.SetActive(true);
        }

    }

}
