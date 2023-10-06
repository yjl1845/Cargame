using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 55;
    public Vector3 direction;

    private void Start()
    {
        direction = transform.position;
        // 첫 번째 매개변수 : 실행시키고 싶은 함수
        // 두 번째 매개변수 : 몇 초 후에 실행되는 시간
        // 세 번째 매개변수 : 몇 초 마다 반복되는 시간
        InvokeRepeating("NewPosition", 5, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void NewPosition()
    {
        transform.position = direction;
        transform.Find("Canvas").gameObject.SetActive(false);
    }

}
