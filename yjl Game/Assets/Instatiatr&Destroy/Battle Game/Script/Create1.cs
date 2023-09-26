using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create1 : MonoBehaviour
{
    public GameObject[] perfeb;
    public Transform[] createPosition;

    public void CreateGeneric(int index)
    {
        Instantiate(perfeb[index], createPosition[index].position, perfeb[index].transform.rotation);
    }
}
