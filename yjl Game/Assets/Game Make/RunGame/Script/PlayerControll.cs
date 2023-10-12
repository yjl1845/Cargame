using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    // Update is called once per frame
    void Update()
    {
        // ĳ���� �̵� �Լ�
        Move();

        // ĳ���� �̵� ����
        Status();
    }

    public void Move()
    {
        // ���� ����Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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

        // ������ ����Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
}
