using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stego : MonoBehaviour
{

    public Vector3 direction;
    public float speed = 1.0f;
    public float rotateSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Input.GetKeyDown
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     Debug.Log("���װ� �ȱ�");
        // }
        // 
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     transform.position += new Vector3(-1,0,0);
        // }
        // 
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     transform.position += new Vector3(1, 0, 0);
        // }
        // 
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     transform.position += new Vector3(0, 0, 1);
        // }
        // 
        // if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     transform.position += new Vector3(0, 0, -1);
        // }
        #endregion

        #region

        // Input.GetAxis : -1 ~ 1������ ���� ��ȯ�ϴ� �Լ�
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(direction.x, 0, direction.z);

        // v = v0 + vt
        // Time.deltatime : �� �������� �Ϸ�Ǳ���� �ɸ� �ð�

        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);

        if (!(direction.x == 0 && direction.y == 0))
        {
            // �̵��� ȸ���� �Բ� ó��
            transform.position += dir * speed * Time.deltaTime;
            // ȸ���ϴ� �κ�. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);

            #endregion
        }
    }
}
