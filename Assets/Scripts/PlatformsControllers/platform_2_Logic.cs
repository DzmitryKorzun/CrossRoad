using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platform_2_Logic : MonoBehaviour
{
    GameObject poolSys;
    List<GameObject> car_1;
    List<GameObject> car_2;
    private float time;
    int type_car;
    int pos;
    int last_pos;
    void Start()
    {
        poolSys = GameObject.Find("PoolingObj");
        car_1 = poolSys.GetComponent<PoolingSystem>().car_1;
        car_2 = poolSys.GetComponent<PoolingSystem>().car_2;
        time = Random.Range(4, 6);
        type_car = Random.Range(1, 3);
        pos = poolSys.GetComponent<PoolingSystem>().pos_plat_2;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && this.gameObject.activeSelf)
        {
            if (this.gameObject.activeSelf) pos = poolSys.GetComponent<PoolingSystem>().pos_plat_2;
            time = Random.Range(2, 6);
            if (type_car == 1)
            {
                var car = car_1.Find(item => item.activeSelf == false);
                var seq = DOTween.Sequence();
                car.transform.position = new Vector3(10, 0.4f, pos);
                car.SetActive(true);
                seq.Append(car.transform.DOMoveX(-20, 10));
                seq.OnComplete(complete);

                void complete()
                {
                    car.SetActive(false);
                }
            }
            else
            {
                var seq = DOTween.Sequence();
                var car = car_2.Find(item => item.activeSelf == false);
                car.transform.position = new Vector3(-10, 0.4f, pos);
                car.SetActive(true);
                seq.Append(car.transform.DOMoveX(20, 10));
                seq.OnComplete(complete);
                void complete()
                {
                    car.SetActive(false);
                }
            }          
        }
    }

}
