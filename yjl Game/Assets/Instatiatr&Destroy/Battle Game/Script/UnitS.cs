using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public enum State
{
    RUN,
    ATTACK,
    DIE
}

[RequireComponent(typeof(Animator))]

public abstract class UnitS : MonoBehaviour
{
    protected float maxHP;
    protected float maxspeed;
    public float health;
    protected float attack;
    protected float speed;

    protected HPUI hpbar;
    protected Collider target;
    protected Animator animator;

    public State state;

    private void Awake()
    {
        hpbar = GetComponent<HPUI>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.RUN: Move();
                break;
            case State.ATTACK: Attack();
                break;
            case State.DIE: Die();
                break;
        }
    }

    public virtual void Move()
    {
        speed = maxspeed;
        animator.SetBool("Attack", false);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public virtual void Attack()
    {
        speed = 0.0f;
        animator.SetBool("Attack", true);
    }

    public virtual void Die()
    {
        animator.Play("Die");
        Destroy(gameObject);
    }

    public abstract void Hit(float damage);
}