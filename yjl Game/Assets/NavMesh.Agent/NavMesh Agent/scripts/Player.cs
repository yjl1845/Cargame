using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("충돌 중");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("충돌 끝");
    }
}
