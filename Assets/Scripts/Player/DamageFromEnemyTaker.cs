using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFromEnemyTaker : MonoBehaviour
{
    [SerializeField] PlayerHp playerHp;

    // ENCAPSULATION
    public bool IsDamagedByBullets { get => isDamagedByBullets; }
    [SerializeField] private bool isDamagedByBullets = false;


    public void TakeDamage(int damage)
    {
        playerHp.GetDamage(damage);
    }

}
