using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : UnitS
{

    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        attack = 50;
        speed = -100.0f;

        maxHP = health;
        maxspeed = speed;

        animator.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Boss");
    }

    public void Damage()
    {
        target.GetComponent<MyUnit>().Hit(attack);
    }

    public override void Hit(float damage)
    {
        health -= damage;

        hpbar.CurrentHP(health, maxHP);

        if (health <= 0)
        {
            state = State.DIE;

            target.GetComponent<MyUnit>().state = State.RUN;
        }
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
