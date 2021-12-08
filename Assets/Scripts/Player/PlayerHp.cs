using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
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
    public UnityEvent OnGetDamage;

    public void GetDamage(int damage)
    {
        Hp-= damage;
        OnGetDamage.Invoke();
    }
}
