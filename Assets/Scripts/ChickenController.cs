using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ChickenController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform chickenTransform;
    int countForwardBack=0;
    int countDirection = 0;



    void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData e)
    {
        if (Mathf.Abs(e.delta.x)> Mathf.Abs(e.delta.y))
        {
            if (e.delta.x>0)
            {
                countDirection++;
                transform.DOMove(new Vector3(countDirection, 0, countForwardBack), 0.5f, true);
            }
            else
            {
                countDirection--;
                transform.DOMove(new Vector3(countDirection, 0, countForwardBack), 0.5f, true);
            }
        }
        else
        {
            if (e.delta.y > 0)
            {
                countForwardBack++;
                chickenTransform.DOMove(new Vector3(countDirection, 0, countForwardBack), 0.5f, true);
            }
            else
            {
                countForwardBack--;
                chickenTransform.DOMove(new Vector3(countDirection, 0, countForwardBack), 0.5f, true);
            }
        }
    }

    public void OnDrag(PointerEventData e)
    {
        
    }


    void Update()
    {
     
    }
}
