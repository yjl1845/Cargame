using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RoadManage : MonoBehaviour
{
    [SerializeField] int count = 0;
    [SerializeField] int maxcount = 2;

    [SerializeField] List<GameObject> roads;

    [SerializeField] float offset = 40f;

    public static Action roadCallback;

    // Start is called before the first frame update
    void Start()
    {
        roads.Capacity = 10;

        roadCallback = NewPosition;
        roadCallback += Increase;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject firstRoad = roads[0];

        roads.Remove(firstRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        firstRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(firstRoad);

        // 하위 오브젝트에 있는 CoinManager 클래스에 NewPosition() 함수를 호출한다.
        // firstRoad.transform.GetComponentInChildren<CoinManager>().NewPosition();
    }

    public void Increase()
    {
        if (count < maxcount)
        {
            GameManager.instance.speed += Util.IncreaseValue(count++);
            Debug.Log("증가");
        }
    }
}
