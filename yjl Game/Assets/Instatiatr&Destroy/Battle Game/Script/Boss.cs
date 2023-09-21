using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private int BossHp = 50;

    private void OnParticleCollision(GameObject other)
    {
        if(BossHp < 1)
        {
            anim.SetBool("Die",true);
            Destroy(other);
        }
        else
        {
            anim.SetBool("Die", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
