using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RocketType { EnemyRocket,PlayerRocket}
public class RocketBechviour : MonoBehaviour
{
    
    public RocketType TypeOfRocket { get { return typeOfRocket; } }
    [SerializeField] RocketType typeOfRocket;

    [SerializeField] private int damage = 1;
    [SerializeField,Range(0,10000)] protected float baseSpeed;
    [SerializeField] new Rigidbody rigidbody;
   
    protected virtual void Start()
    {
        rigidbody.AddRelativeForce(Vector3.forward * baseSpeed);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (typeOfRocket == RocketType.PlayerRocket)
        {
            if (other.transform.GetComponent<Enemy>() != null)
            {
                other.transform.GetComponent<Enemy>().GetDamage(damage);

                Destroy(gameObject);
                return;
            }
        }
        if (typeOfRocket == RocketType.EnemyRocket)
        {
            if (other.transform.GetComponent<DamageFromEnemyTaker>() != null)
            {
                if (other.transform.GetComponent<DamageFromEnemyTaker>().IsItPlayer == false)
                {
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    other.transform.GetComponent<DamageFromEnemyTaker>().TakeDamage(damage);
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
