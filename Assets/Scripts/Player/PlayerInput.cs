using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // ENCAPSULATION
    public bool IsLeftArrowPressed { get => isLeftArrowPressed;}
    private  bool isLeftArrowPressed = false;
    public  bool IsRightArrowPress { get => isRightArrowPress; }
    private  bool isRightArrowPress = false;
    public  bool IsUpArrowPress { get => isUpArrowPress; }
    private  bool isUpArrowPress = false;
    public bool Is_W_Press { get => is_W_Press; }
    private bool is_W_Press = false;
    public  bool Is_A_Press { get => is_A_Press; }
    private  bool is_A_Press = false;
    public bool Is_S_Press { get => is_S_Press; }
    private bool is_S_Press = false;
    public  bool Is_D_Press { get => is_D_Press; }
    private  bool is_D_Press = false;
   


    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            isLeftArrowPressed = true;
        }
        else
        {
            isLeftArrowPressed = false;
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            isRightArrowPress = true;
        }
        else
        {
            isRightArrowPress = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            isUpArrowPress = true;
        }
        else
        {
            isUpArrowPress = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            is_W_Press = true;
        }
        else
        {
            is_W_Press = false;
        }

        if (Input.GetKey(KeyCode.A) )
        {
            is_A_Press = true;
        }
        else
        {
            is_A_Press = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            is_S_Press = true;
        }
        else
        {
            is_S_Press = false;
        }

        if (Input.GetKey(KeyCode.D) )
        {
            is_D_Press = true;
        }
        else
        {
            is_D_Press = false;
        }
    }
}
