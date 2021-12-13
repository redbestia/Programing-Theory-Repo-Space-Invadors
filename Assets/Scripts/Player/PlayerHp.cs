using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    // ENCAPSULATION
    public int Hp
    {
        get => hp; 
        set
        {
            if (value <= 0)
            {
                OnPlayerDie.Invoke();
            }
            hp = value;
        } 
    }
    [SerializeField] private int hp;

    public UnityEvent OnPlayerDie;
    public UnityEvent<int> OnGetDamage;

    public void GetDamage(int damage)
    {
        Hp-= damage;
        OnGetDamage.Invoke(hp);
    }
}
