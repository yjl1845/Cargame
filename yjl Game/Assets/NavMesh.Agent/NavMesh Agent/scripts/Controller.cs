using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{

    public int count;
    public Transform[] point;
    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // 특정한 시간에 함수 호출하는 것
        InvokeRepeating("Move", 1, 5f);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
