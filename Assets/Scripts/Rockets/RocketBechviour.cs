using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RocketType { EnemyRocket,PlayerRocket}
public class RocketBechviour : MonoBehaviour
{
    public RocketType TypeOfRocket { get { return typeOfRocket; } }
    [SerializeField] RocketType typeOfRocket;
    
    [SerializeField,Range(0,10000)] protected float baseSpeed;
    [SerializeField] new Rigidbody rigidbody;
   
    protected virtual void Awake()
    {
        rigidbody.AddRelativeForce(Vector3.right * baseSpeed);
    }

}
