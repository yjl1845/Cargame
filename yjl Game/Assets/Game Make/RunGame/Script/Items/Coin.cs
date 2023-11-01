using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item, IItem
{
    public void Update()
    {
            transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);
    }

    public void Use()
    {
        Debug.Log("Coin");
    }
}
