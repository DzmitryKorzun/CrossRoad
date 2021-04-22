using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDeactivator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "carDec")
        {
            this.gameObject.SetActive(false);
        }
    }
}
