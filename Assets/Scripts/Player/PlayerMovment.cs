using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] GameObject cursorPointer;
    [SerializeField] PlayerInput input;
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField, Range(0.0f, 200.0f)] float speed = 0;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForHorzontalMove = 50;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForBackMove = 30;
    [SerializeField, Range(0.0f, 200.0f)] float percentOfMaxSpeedForForwardMove = 100;
    [SerializeField] float rotationSpeed = 50;

    private Option lastHorizontalSide = Option.Defult;
    private Option lastVerdicalSide = Option.Defult;
    private Option lastRotateSide = Option.Defult;

    private void FixedUpdate()
    {
        HorizontalMove();
        VerdicalMove();
    }

    private void Update()
    {
        
        RotateToCursor();
        //RotateByKey();

        Debug.Log(cursorPointer.transform.localRotation.eulerAngles.y);
    }

    void VerdicalMove()
    {
        Option side = ChooseLastUsedOption(input.Is_S_Press, input.Is_W_Press, ref lastVerdicalSide);
        if (side == Option.Option1) 
        {
            MovePlayer(Vector3.back, percentOfMaxSpeedForBackMove);
            return;
        }
        if (side == Option.Option2)
        {
            MovePlayer(Vector3.forward, percentOfMaxSpeedForForwardMove);
            return;
        }
    }

    void HorizontalMove()
    {
        Option side = ChooseLastUsedOption(input.Is_A_Press, input.Is_D_Press, ref lastHorizontalSide);
        if(side == Option.Option1)
        {
            MovePlayer(Vector3.left, percentOfMaxSpeedForHorzontalMove);
            return;
        }
        if(side == Option.Option2)
        {
            MovePlayer(Vector3.right, percentOfMaxSpeedForHorzontalMove);
            return;
        }
    }

    Option ChooseLastUsedOption(bool option1, bool option2,ref Option lastUsedOption)
    {
        if (option1 && option2)
        {
            if (lastUsedOption == Option.Option1)
            {
                return Option.Option2;
            }
            if (lastUsedOption == Option.Option2)
            {
                return Option.Option1;
            }
        }
        if (option1)
        {
            lastUsedOption = Option.Option1;
            return Option.Option1;
        }
        if (option2)
        {
            lastUsedOption = Option.Option2;
            return Option.Option2;
        }
        return Option.Defult;
    }

    void MovePlayer(Vector3 vector3, float procentOfMaxSpeed)
    {
        //rigidbody.velocity = vector3 * speed * (procentOfMaxSpeed / 100);
        //rigidbody.AddForce(vector3 * speed * (procentOfMaxSpeed / 100));
        rigidbody.AddRelativeForce(vector3 * speed * (procentOfMaxSpeed / 100));
    }

    void RotateToCursor()
    {
        // Vector3 vectorFromPlayerToCursor = input.CursorPosition - transform.position;
        //transform.LookAt(input.CursorPosition);
        if (cursorPointer.transform.localRotation.eulerAngles.y >= 359 || 
            cursorPointer.transform.localRotation.eulerAngles.y <= 1)
        {
            rigidbody.angularVelocity = Vector3.zero;
            return;
        }
        if (cursorPointer.transform.localRotation.eulerAngles.y > 180 && 
            cursorPointer.transform.localRotation.eulerAngles.y < 359)
        {
            RotateLeft();
            
            return;
        }
        if (cursorPointer.transform.localRotation.eulerAngles.y < 180 &&
            cursorPointer.transform.localRotation.eulerAngles.y >1)
        {
            RotateRight();

            return;
        }
       
    }
    

    void RotateByKey()
    {
        Option side = ChooseLastUsedOption(Input.GetKey(KeyCode.Q), Input.GetKey(KeyCode.E), ref lastRotateSide);
        if (side == Option.Option1)
        {
            RotateLeft();
            return;
        }
        if (side == Option.Option2)
        {
            RotateRight();
            return;
        }
        if (side == Option.Defult)
        {
            rigidbody.angularVelocity = Vector3.zero;
            return;
        }
    }

    void RotateLeft()
    {
        Debug.Log("Rotation Left");
        rigidbody.angularVelocity = (new Vector3(0, -rotationSpeed, 0));
    }

    void RotateRight()
    {
        Debug.Log("Rotation Right");
        rigidbody.angularVelocity = (new Vector3(0, rotationSpeed, 0));
    }
}
