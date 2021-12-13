using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLuncher : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] float reaoladTime = 0.3f;
    float lastTimeShot = 0;

    public void Spwan(Vector3 rotation)
    {
        if (lastTimeShot > Time.time) return;
        
        Instantiate(rocketPrefab, transform.position, Quaternion.Euler(rotation));
        lastTimeShot = Time.time + reaoladTime;
    }
}
