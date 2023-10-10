using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ObjectPoolManager.instance.GetQueue(Camera.main.ScreenPointToRay(Input.mousePosition).origin);
        }
    }
}
