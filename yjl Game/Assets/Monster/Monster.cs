using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public Stat()
    {
        Debug.Log("Stat ����");
    }
}

public class Monster : MonoBehaviour
{
    Stat stat;

    // Awake : ��ũ��Ʈ�� ����� �� �� �� ���� ȣ��Ǹ�, ��ũ��Ʈ��
    //         ��Ȱ��ȭ�Ǿ ����Ǵ� �̺�Ʈ �Լ��Դϴ�.
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // OnEnable : ���� ������Ʈ�� Ȱ��ȭ�� ������ ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Start : ��ũ��Ʈ�� ����� �� �� �� ���� ȣ��Ǹ�, ��ũ��Ʈ��
    //         ��Ȱ��ȭ ������ �� ������� �ʴ� �̺�Ʈ �Լ��Դϴ�.  
    void Start()
    {
        stat = new Stat();
        Debug.Log("Start");
    }

    // FixedUpdate : Timestep ������ ���� ���� ������ �ֱ��
    //               ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    // Update : �� �����Ӹ��� ȣ��Ǵ� �̺�Ʈ �Լ��̸�, ����̽��� �����̳�
    //          ����ȭ ��Ȳ�� ���� ������ ����Ʈ�� ��ȭ�ϹǷ� �Լ� ȣ�� �ð��� ��� �޶����ϴ�.
    private void Update()
    {
        Debug.Log("Update");
    }


    // Update : Update �Լ��� ȣ��� �Ŀ� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.   
    private void LateUpdate()
    {
        Debug.Log("Late Update");
    }

    // OnDisable : ���� ������Ʈ�� ��Ȱ��ȭ�Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // OnDestroy : ���� ������Ʈ�� �ı��Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�.
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}