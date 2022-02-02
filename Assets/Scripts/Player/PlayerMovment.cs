using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovment : MonoBehaviour
{

    [SerializeField] PlayerInput input;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField, Range(0.0f, 100.0f)] float speed = 0;
    [SerializeField, Range(0.0f, 100.0f)] float percentOfMaxSpeedForHorzontalMove;


    private HorizontalSide lastHorizontalSide = HorizontalSide.Left;
    private void Update()
    {
        HorizontalMove();
    }

    void HorizontalMove()
    {
        if (input.Is_A_Press && input.Is_D_Press)
        {
            if (lastHorizontalSide == HorizontalSide.Left)
            {
                SetMoveHorizontal(Vector3.right);
            }
            else if (lastHorizontalSide == HorizontalSide.Right)
            {
                SetMoveHorizontal(Vector3.left);
            }
        }
        else if (input.Is_A_Press)
        {
            SetMoveHorizontal(Vector3.left);
            lastHorizontalSide = HorizontalSide.Left;
        }
        else if (input.Is_D_Press)
        {
            SetMoveHorizontal(Vector3.right);
            lastHorizontalSide = HorizontalSide.Right;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
    
    void SetMoveHorizontal(Vector3 vector3)
    {
        rigidbody.velocity = vector3 * speed * (percentOfMaxSpeedForHorzontalMove / 100);
    }
}
