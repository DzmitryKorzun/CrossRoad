using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonController : MonoBehaviour
{
    public GameObject target;
    public GameObject LevelGenerator;
    private LevelGenerator Lvl_G;

    int stepCounter;
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
        Lvl_G = LevelGenerator.GetComponent<LevelGenerator>();
        PersonController.SwipeEvent += CheckInput;
    }

    private void CheckInput(SwipeType t)
    {
        if (t == SwipeType.Right)
        {
            countDirectionLeftRight++;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 1, false);
            transform.DORotate(new Vector3(0, 270, 0), 0.2f);

        }
        if (t == SwipeType.Left)
        {
            countDirectionLeftRight--;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 1, false);
            transform.DORotate(new Vector3(0, 90, 0), 0.2f);
        }

        if (t == SwipeType.Down)
        {
            countForwardBack++;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 1, false);
            transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            Lvl_G.addNewPlatform();
            Lvl_G.destroyPlatform();
        }
        
        if (t == SwipeType.Up)
        {
            countForwardBack--;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 1, false);
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);
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


    private bool checkLet()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, target.transform.position - transform.position);

        Physics.Raycast(ray, out hit);

        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {

            return false;
        }
        else
        {
            return true;
        }




    }

}
