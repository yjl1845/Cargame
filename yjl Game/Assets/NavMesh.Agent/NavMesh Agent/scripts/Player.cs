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
        Debug.Log("�浹");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("�浹 ��");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("�浹 ��");
    }
}
