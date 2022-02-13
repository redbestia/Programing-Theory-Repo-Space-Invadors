using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPointerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    private void Update()
    {
        transform.LookAt(new Vector3(input.CursorPosition.x, transform.position.y, input.CursorPosition.z)); 
    }


}
