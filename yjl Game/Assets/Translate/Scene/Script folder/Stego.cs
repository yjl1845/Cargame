using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stego : MonoBehaviour
{

    public Vector3 direction;
    public float speed = 1.0f;

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

        // v = v0 + vt
        // Time.deltatime : 전 프레임이 완료되기까지 걸린 시간

        direction.Normalize();

        transform.Translate(direction*speed*Time.deltaTime);

        #endregion
    }
}
