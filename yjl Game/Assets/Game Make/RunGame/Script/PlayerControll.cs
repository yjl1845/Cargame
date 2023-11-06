using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1,
}

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float positionX = 3.5f;
    [SerializeField] RoadLine roadLine;

    [SerializeField] ObjectSound objectSound = new ObjectSound();
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent playerevent;

    private void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    // Update is called once per frame
    void Update()
    {
        // 캐릭터 이동 함수
        Move();

        // 캐릭터 이동 상태
        Status();
    }

    public void Move()
    {
        // 왼쪽 방향키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            AudioManager1.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }

            else
            {
                roadLine--;
            }
        }

        // 오른쪽 방향키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0)
        {
            AudioManager1.instance.Sound(objectSound.audioClip[0]);

            if (roadLine >= RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }

            else
            {
                roadLine++;
            }
        }
    }

    public void Status()
    {
        switch(roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                transform.position = Vector3.zero;
                break;
            case RoadLine.RIGHT:
                transform.position = new(+positionX, 0, 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if (item != null)
        {
            item.Use();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Obstacle"))
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        playerevent.Invoke();
        animator.Play("Death");
    }

    private void WaitForSecondsRealtime(float v)
    {
        throw new NotImplementedException();
    }
}
