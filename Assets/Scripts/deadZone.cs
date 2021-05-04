using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "CAR_01(Clone)" && collision.gameObject.name != "Car_04(Clone)" && collision.gameObject.name != "train(Clone)")
        {
            collision.gameObject.SetActive(false);
        }
        
    }

}
