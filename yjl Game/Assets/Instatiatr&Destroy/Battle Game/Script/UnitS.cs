using System.Collections;
using System.Collections.Generic;
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

    protected float health;
    protected float attack;
    protected float speed;

    protected Collider target;
    protected Animator animator;

    protected State state;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void Hit(float damage)
    {
        health -= damage;

        if (health < 0);
        {
            state = State.DIE;
        }
    }
}
