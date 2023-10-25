using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject rotatePab;
    [SerializeField] float rotateSpeed = 300.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    protected void OnEnable()
    {
        transform.rotation = Quaternion.Euler(rotatePab.transform.rotation.eulerAngles.x, rotatePab.transform.rotation.eulerAngles.y, rotatePab.transform.rotation.eulerAngles.z);
    }

    public void Awake()
    {
        rotatePab = GameObject.Find("Rotation prefep");
    }
}
