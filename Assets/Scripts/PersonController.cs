using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonController : MonoBehaviour
{
    int countForwardBack = 0;
    int countDirectionLeftRight = 0;

    bool isDragging;
    Vector2 tabPoint, swipeDelta;
    float minDelta = 150;

    public enum SwipeType
    {
        Left, Right, Up, Down
    }

    public delegate void OnSwipeInput(SwipeType t);
    public static event OnSwipeInput SwipeEvent;

    private void Start()
    {
        PersonController.SwipeEvent += CheckInput;
    }

    private void CheckInput(SwipeType t)
    {
        Debug.Log("Свайп");
            if (t == SwipeType.Up)
            {
                countDirectionLeftRight++;
                transform.DOMove(new Vector3(countDirectionLeftRight, 0, countForwardBack), 0.5f, true);
            }
            if (t == SwipeType.Down)
            {
                countDirectionLeftRight--;
                transform.DOMove(new Vector3(countDirectionLeftRight, 0, countForwardBack), 0.5f, true);
            }

            if (t == SwipeType.Left)
            {
                countForwardBack++;
                transform.DOMove(new Vector3(countDirectionLeftRight, 0, countForwardBack), 0.5f, true);
            }
            if (t == SwipeType.Right)
            {
                countForwardBack--;
                transform.DOMove(new Vector3(countDirectionLeftRight, 0, countForwardBack), 0.5f, true);
            }
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                tabPoint = Input.touches[0].position;

            }
            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                resetSwipe();
            }
        }
        CalculateSwipe();
    }




    void CalculateSwipe()
    {
        swipeDelta = Vector2.zero;
        if (isDragging && Input.touchCount > 0)
        {
            swipeDelta = Input.touches[0].position - tabPoint;
        }

        if (swipeDelta.magnitude > minDelta)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(swipeDelta.x)>Mathf.Abs(swipeDelta.y))
                {
                    SwipeEvent(swipeDelta.x < 0 ? SwipeType.Left : SwipeType.Right);
                }
                else
                {
                    SwipeEvent(swipeDelta.y < 0 ? SwipeType.Up : SwipeType.Down);
                }
            }
            resetSwipe();
        }
    }



    void resetSwipe()
    {
        isDragging = false;
        tabPoint = swipeDelta = Vector2.zero;
    }
}
