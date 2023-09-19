using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Zombie : MonoBehaviour
{
    public int count;
    public Transform[] point;
    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // Ư���� �ð��� �Լ� ȣ���ϴ� ��
        InvokeRepeating("Move", 5, 5f);
    }

    public void Move()
    {
        if (navMeshAgent.velocity == Vector3.zero)
        {
            if (point.Length <= count)
            {
                count = 0;
            }
        }
        navMeshAgent.SetDestination(point[count++].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //navMeshAgent.SetDestination();
        }
    }
}
