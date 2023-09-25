using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : UnitS
{

    public HPUI hpbar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attack = 20;
        speed = -1.0f;

        maxHP = health;

        hpbar = GetComponent<HPUI>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController) Resources.Load("Boss");
    }

    public void Damage()
    {
        target.GetComponent<MyUnit>().Hit(attack);
        target.GetComponent<MyUnit>().hpbar.CurrentHP(health, maxHP);

        Debug.Log(target.GetComponent<MyUnit>().health);
        //target.GetComponent<MyUnit>().Hit(attack);
        //hpbar.CurrentHP(health, maxHP);
    }

    public override void Hit(float damage)
    {
        health -= damage;

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
