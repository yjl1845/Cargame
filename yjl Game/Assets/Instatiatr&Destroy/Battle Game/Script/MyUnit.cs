using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MyUnit : UnitS
{
    public HPUI hpbar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attack = 50;
        speed = 1.0f;

        maxHP = health;

        hpbar = GetComponent<HPUI>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("My Unit");
    }

    public override void Hit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            state = State.DIE;
            target.GetComponent<Boss>().state = State.RUN;
        }
    }

    public void Damage(float damage)
    {
        target.GetComponent<Boss>().Hit(attack);
        target.GetComponent<Boss>().hpbar.CurrentHP(health, maxHP);

        Debug.Log(target.GetComponent<Boss>().health);
        //target.GetComponent<Boss>().Hit(attack);
        //
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
