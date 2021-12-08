using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    [SerializeField] private float reloadRocketTime;
    [SerializeField] private RocketLuncher rocketLuncher;

    private void Update()
    {
        rocketLuncher.Spwan(new Vector3(0,180));
    }
}
