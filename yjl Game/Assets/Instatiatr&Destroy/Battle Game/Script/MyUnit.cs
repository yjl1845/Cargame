using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnit : UnitS
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attack = 20;
        speed = 1.0f;

        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("My Unit");
    }

    void Damage()
    {
        target.GetComponent<Boss>().Hit(attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss"))
        {
            target = other;
            state = State.ATTACK;
        }
    }
}
