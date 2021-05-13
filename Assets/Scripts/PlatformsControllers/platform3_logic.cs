using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platform3_logic : MonoBehaviour
{
    GameObject poolSys;
    List<GameObject> train;    
    private float time;
    private float light_time = 1f;
    public float pos;
    GameObject red_light;
    GameObject green_light;


    void Start()
    {
        poolSys = GameObject.Find("PoolingObj").gameObject;

        train = poolSys.GetComponent<PoolingSystem>().train;
        time = Random.Range(4, 6);
        pos = poolSys.GetComponent<PoolingSystem>().pos_plat_3;
        red_light = this.transform.GetChild(1).gameObject;
        green_light = this.transform.GetChild(0).gameObject;
        red_light.SetActive(false);
    }


    void Update()
    {
        OnGreenLight();
        time -= Time.deltaTime;
        if (time <= 0 && this.gameObject.activeSelf)
        {
            if (this.gameObject.activeSelf)
            {
                pos = this.gameObject.transform.position.z;
            }

            time = Random.Range(4, 6);


            goTrain();
            onRed();
            light_time = 1f;
        }
    }

    void onGreen()
    {
        green_light.SetActive(true);
        red_light.SetActive(false);
    }

    void onRed()
    {
        green_light.SetActive(false);
        red_light.SetActive(true);
    }


    void goTrain()
    {

        var tra = train.Find(item => item.activeSelf == false);
        var seq = DOTween.Sequence();
        tra.transform.position = new Vector3(25, 0.4f, pos);
        tra.SetActive(true);
        seq.Append(tra.transform.DOMoveX(-20, 2));
        seq.OnComplete(complete);

        void complete()
        {
            tra.SetActive(false);
        }
    }

    void OnGreenLight()
    {
        light_time -= Time.deltaTime;
        if (light_time<=0)
        {
            onGreen();
        }


    }



}

