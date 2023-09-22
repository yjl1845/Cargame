using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : UnitS
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attack = 20;
        speed = -1.0f;

        animator.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Boss");
    }

    void Damage()
    {
        target.GetComponent<MyUnit>().Hit(attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            target = other;
            state = State.ATTACK;
        }
    }
}
