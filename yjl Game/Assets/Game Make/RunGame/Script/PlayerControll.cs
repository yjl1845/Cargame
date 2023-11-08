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
    [SerializeField] CharacterController CharacterController;
    [SerializeField] Vector3 direction;
    [SerializeField] float JumpPower = 20f;

    [SerializeField] GameObject Gameoverscene;

    [SerializeField] float positionX = 3.5f;
    [SerializeField] RoadLine roadLine;

    [SerializeField] ObjectSound objectSound = new ObjectSound();
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent playerevent;

    WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

    private void Start()
    {
        roadLine = RoadLine.MIDDLE;

        direction = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 캐릭터 이동 함수
        Move();

        // 캐릭터 이동 상태
        Status();

        Jump();
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

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y <= 0.1f)
            {
                direction.y = 20;
                transform.position = new Vector3(transform.position.x,direction.y,0);
            }
        }
        
        direction.y -= 50f * Time.deltaTime;
        transform.position = direction;
    }

    public void Status()
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new Vector3(-positionX, transform.position.y, 0);
                break;
            case RoadLine.MIDDLE:
                transform.position = new Vector3(0, transform.position.y, 0);
                break;
            case RoadLine.RIGHT:
                transform.position = new Vector3(+positionX, transform.position.y, 0);
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

    public void OnGameOverUI()
    {
        GameManager.instance.GameoverPanel();
    }

    private void WaitForSecondsRealtime(float v)
    {
        throw new NotImplementedException();
    }
}
