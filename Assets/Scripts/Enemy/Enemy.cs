using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Hp
    {
        get => hp; 
        set
        {
            if (value > 0)
            {
                hp = value;
            }
            else
            {
                GameMangaer.Instance.AddOneToScore();
                Destroy(gameObject);
            }
        }
    }
    [SerializeField] private int hp = 2;

    [SerializeField] private int colisionDamage = 1;
    [SerializeField,Range(0.0f,5000.0f)] private float speed = 1300;
    [SerializeField] protected new Rigidbody rigidbody;

    

    protected virtual void Start()
    {
        rigidbody.AddRelativeForce(Vector3.forward * speed);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<DamageFromEnemyTaker>() != null)
        {
            collision.transform.GetComponent<DamageFromEnemyTaker>().TakeDamage(colisionDamage);
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        Hp -= damage;
    }
}
