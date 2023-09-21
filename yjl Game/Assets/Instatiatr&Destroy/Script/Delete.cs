using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private int random;

    private void Start()
    {
        random = Random.Range(1, 5);
        Destroy(gameObject, random);
    }
}
