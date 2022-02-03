using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovment : MonoBehaviour
{

    [SerializeField] PlayerInput input;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField, Range(0.0f, 200.0f)] float speed = 0;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForHorzontalMove = 50;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForBackMove = 30;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForForwardMove = 100;


    private HorizontalSide lastHorizontalSide = HorizontalSide.Left;
    private VerdicalSide lastVerdicalSide = VerdicalSide.Front;
    private void Update()
    {
        HorizontalMove();
        VerdicalMove();
    }

    void VerdicalMove()
    {
        if (input.Is_W_Press && input.Is_S_Press)
        {
            if (lastVerdicalSide == VerdicalSide.Front)
            {
                SetMoveHorizontal(Vector3.back, percentOfMaxSpeedForBackMove);
            }
            else if (lastVerdicalSide == VerdicalSide.Back)
            {
                SetMoveHorizontal(Vector3.forward, percentOfMaxSpeedForForwardMove);
            }
        }
        else if (input.Is_W_Press)
        {
            SetMoveHorizontal(Vector3.forward, percentOfMaxSpeedForForwardMove);
            lastVerdicalSide = VerdicalSide.Front;
        }
        else if (input.Is_S_Press)
        {
            SetMoveHorizontal(Vector3.back, percentOfMaxSpeedForBackMove);
            lastVerdicalSide = VerdicalSide.Back;
        }
    }
    void HorizontalMove()
    {
        if (input.Is_A_Press && input.Is_D_Press)
        {
            if (lastHorizontalSide == HorizontalSide.Left)
            {
                SetMoveHorizontal(Vector3.right, percentOfMaxSpeedForHorzontalMove);
            }
            else if (lastHorizontalSide == HorizontalSide.Right)
            {
                SetMoveHorizontal(Vector3.left, percentOfMaxSpeedForHorzontalMove);
            }
        }
        else if (input.Is_A_Press)
        {
            SetMoveHorizontal(Vector3.left, percentOfMaxSpeedForHorzontalMove);
            lastHorizontalSide = HorizontalSide.Left;
        }
        else if (input.Is_D_Press)
        {
            SetMoveHorizontal(Vector3.right, percentOfMaxSpeedForHorzontalMove);
            lastHorizontalSide = HorizontalSide.Right;
        }
    }

    void SetMoveHorizontal(Vector3 vector3, float procentOfMaxSpeed)
    {
        //rigidbody.velocity = vector3 * speed * (procentOfMaxSpeed / 100);
        rigidbody.AddForce(vector3 * speed * (procentOfMaxSpeed / 100));
    }


}
