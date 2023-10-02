using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MyUnit : UnitS
{

    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        attack = 10;
        speed = 100.0f;

        maxHP = health;
        maxspeed = speed;

        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("My Unit");
    }

    public override void Hit(float damage)
    {
        health -= damage;

        hpbar.CurrentHP(health, maxHP);

        if (health <= 0)
        {
            state = State.DIE;
            target.GetComponent<Boss>().state = State.RUN;
        }
    }

    public void Damage(float damage)
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
