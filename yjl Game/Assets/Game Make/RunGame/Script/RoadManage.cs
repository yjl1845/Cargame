using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadManage : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float offset = 40f;

    public static Action roadCallback;

    // Start is called before the first frame update
    void Start()
    {
        roadCallback = NewPosition;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject firstRoad = roads[0];

        roads.Remove(firstRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        firstRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(firstRoad);
    }
}
