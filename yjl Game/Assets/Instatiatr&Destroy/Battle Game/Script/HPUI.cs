using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] Slider HpBar;

    public void CurrentHP(float hp, float maxHp)
    {
        // 90 / max(100) -> 0.9
        HpBar.value = hp / maxHp;
    }
}
