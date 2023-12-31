using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stego : MonoBehaviour
{
    Animator anim;
    Rigidbody rigid;

    public Vector3 direction;
    public float speed = 1.0f;
    public float rotateSpeed = 0.1f;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

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
        //     Debug.Log("스테고 걷기");
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

        // Input.GetAxis : -1 ~ 1사이의 값을 반환하는 함수
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(direction.x, 0, direction.z);

        // v = v0 + vt
        // Time.deltatime : 전 프레임이 완료되기까지 걸린 시간

        // direction.Normalize();
        // transform.Translate(direction * speed * Time.deltaTime);

        direction = new Vector3(direction.x, 0, direction.z).normalized;
        transform.TransformDirection( direction * speed * Time.deltaTime);
        anim.SetBool("Is Walk", direction != Vector3.zero);

        if (!(direction.x == 0 && direction.y == 0))
        {
            // 이동과 회전을 함께 처리
            transform.position += dir * speed * Time.deltaTime;
            // 회전하는 부분. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
            Debug.Log("스테고 공격");
        }

        #endregion
    }
}
