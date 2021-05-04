using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platform3_logic : MonoBehaviour
{
    GameObject poolSys;
    List<GameObject> train;    


    private float time;
    public float pos;
    void Start()
    {
        poolSys = GameObject.Find("PoolingObj");
        train = poolSys.GetComponent<PoolingSystem>().train;
        time = Random.Range(4, 6);
        pos = poolSys.GetComponent<PoolingSystem>().pos_plat_3;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && this.gameObject.activeSelf)
        {
            if (this.gameObject.activeSelf)
            {
                pos = this.gameObject.transform.position.z;
            }

            time = Random.Range(4, 6);
            var tra = train.Find(item => item.activeSelf == false);
            var seq = DOTween.Sequence();
            tra.transform.position = new Vector3(10, 0.4f, pos);
            tra.SetActive(true);
            seq.Append(tra.transform.DOMoveX(-20, 10));
            seq.OnComplete(complete);

            void complete()
            {
                tra.SetActive(false);
            }
        }
    }
}

