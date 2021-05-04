using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PersonController : MonoBehaviour
{
    public GameObject LevelGenerator;
    public GameObject camera;
    public GameObject poolSysObj;
    public GameObject stepCountText;
    private Text ScoreText;
    public int coinNum;
    public AudioClip din;
    AudioSource audio;



    private PoolingSystem poolingSystem;

    public int stepCounter = 0;
    int countForwardBack = 0;
    int countDirectionLeftRight = 0;
    int stepsBackCounter = 0;

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


            
            
        audio = GetComponent<AudioSource>();
        poolingSystem = poolSysObj.GetComponent<PoolingSystem>();
        PersonController.SwipeEvent += CheckInput;
        ScoreText = stepCountText.GetComponent<Text>();
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            audio.mute = false;
        }
        else
        {
            audio.mute = true;
        }
    }    

    public void CheckInput(SwipeType t)
    {
        if (t == SwipeType.Right && countDirectionLeftRight<4 && checkLetright())
        {
            audio.PlayOneShot(din);
            
           
            countDirectionLeftRight++;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 0.2f, false);
            camera.transform.DOMove(new Vector3(countDirectionLeftRight, camera.transform.position.y, camera.transform.position.z), 0.1f);
            transform.DORotate(new Vector3(0, 270, 0), 0.2f);

        }
        if (t == SwipeType.Left && countDirectionLeftRight >-4 && checkLetleft())
        {
            audio.PlayOneShot(din);
            
            countDirectionLeftRight--;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 0.2f, false);
            camera.transform.DOMove(new Vector3(countDirectionLeftRight, camera.transform.position.y, camera.transform.position.z), 0.1f);
            transform.DORotate(new Vector3(0, 90, 0), 0.2f);
        }

        if (t == SwipeType.Down && checkLetUp()) //Персонаж идет вперед
        {

            audio.PlayOneShot(din);
            countForwardBack++;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 0.2f, false);
            transform.DORotate(new Vector3(0, 180, 0), 0.2f);

            if (stepsBackCounter == 0)
            {
                poolingSystem.lvl_generator();
                stepCounter++;
                ScoreText.text = stepCounter.ToString();
            }                           
            else stepsBackCounter--;

        }
        
        if (t == SwipeType.Up && checkLetdown()) //Персонаж идет назад
        {
            audio.PlayOneShot(din);
            countForwardBack--;
            transform.DOJump(new Vector3(countDirectionLeftRight, 0, countForwardBack), 1, 1, 0.2f, false);
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);
            stepsBackCounter++;
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


    private bool checkLetUp()
    {
        RaycastHit hit;
        Ray ray_up = new Ray(new Vector3(transform.position.x, transform.position.y+ 0.3f, transform.position.z + 0.3f), Vector3.forward);
        if (Physics.Raycast(ray_up, out hit, 0.70f) && hit.collider.tag == "Let") return false;
        return true;
    }
    private bool checkLetdown()
    {
        RaycastHit hit;
        Ray ray_down = new Ray(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z - 0.3f), Vector3.back);
        if (Physics.Raycast(ray_down, out hit, 0.70f) && hit.collider.tag == "Let") return false;
        return true;
    }

    private bool checkLetleft()
    {
        RaycastHit hit;
        Ray ray_left = new Ray(new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, transform.position.z), Vector3.left);
        if (Physics.Raycast(ray_left, out hit, 0.70f) && hit.collider.tag == "Let") return false;
        return true;
    }

    private bool checkLetright()
    {
        RaycastHit hit;
        Ray ray_right = new Ray(new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, transform.position.z), Vector3.right);
        if (Physics.Raycast(ray_right, out hit, 0.70f) && hit.collider.tag == "Let") return false;
        return true;
    }




}
