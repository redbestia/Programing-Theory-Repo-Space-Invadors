using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : PlayerInput
{

    [SerializeField] PlayerInput input;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField, Range(0.0f, 100.0f)] float speed = 0;
    private void Update()
    {
        if(input.Is_A_Press)
        {
            rigidbody.velocity = Vector3.left * speed;
        }
        else if(input.Is_D_Press)
        {
            rigidbody.velocity = Vector3.right * speed;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
