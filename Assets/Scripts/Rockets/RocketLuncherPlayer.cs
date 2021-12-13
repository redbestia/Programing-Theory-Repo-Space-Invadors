using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RocketLuncherPlayer : RocketLuncher
{

    [SerializeField] PlayerInput input;

    private void Update()
    {
            if (input.IsLeftArrowPressed)
            {
                Spwan(new Vector3(0, -45, -0));
            }
            else if (input.IsUpArrowPress)
            {
                Spwan(Vector3.zero);
            }
            else if (input.IsRightArrowPress)
            {
                Spwan(new Vector3(0, 45, 0));
            }


    }

}
