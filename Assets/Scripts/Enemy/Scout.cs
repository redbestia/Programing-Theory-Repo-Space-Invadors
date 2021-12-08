using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Enemy
{
    [SerializeField] private float sideSpeed = 1000;
    [SerializeField] private float sideMoveRange = 10;

    private int sideChenger;
    private Vector3 lastPositionChange;

    protected override void Start()
    {
        base.Start();

        /// Prevent falling in into side barriers
        if (transform.position.x<0)
        {
            transform.position += Vector3.right * sideMoveRange;
        }
        else
        {
            transform.position += Vector3.left * sideMoveRange;
        }


        lastPositionChange = transform.position;
        int sideNumer =  Random.Range(0, 2);
        if(sideNumer == 0)
        {
            sideChenger = 1;
        }
        else
        {
            sideChenger = -1;
        }
        rigidbody.AddRelativeForce(Vector3.right * sideChenger * sideSpeed);

    }

    private void Update()
    {
        if((transform.position.x > (lastPositionChange + Vector3.right * sideMoveRange).x) && sideChenger ==-1 
            || transform.position.x < (lastPositionChange - Vector3.right * sideMoveRange).x && sideChenger == 1)
        {
            lastPositionChange = transform.position;
            sideChenger *= -1;
            rigidbody.AddRelativeForce(Vector3.right * sideChenger * sideSpeed*2);
        }
    }
}
