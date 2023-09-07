using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0,500)]
    [SerializeField] protected float speed = 500.0f;

    protected Vector3 direction;
    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction*speed*Time.deltaTime);
    }
}
