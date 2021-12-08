using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFromEnemyTaker : MonoBehaviour
{
    [SerializeField] PlayerHp playerHp;

    public bool IsItPlayer { get; }
    [SerializeField] private bool isItPlayer = false;


    public void TakeDamage(int damage)
    {
        playerHp.GetDamage(damage);
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.transform.GetComponent<Enemy>() != null)
    //    {
            
    //    }

    //}
}
