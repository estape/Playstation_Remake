using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class ControllerManager : MonoBehaviour
{
    public void CheckIfPSController()
    {
        var DS4 = DualShock4GamepadHID.current;
        var DS3 = DualShock3GamepadHID.current;
        
        if(DS4 != null)
        {
            DS4.SetLightBarColor(Color.cyan);
            Debug.Log("Dualshock 4 has found it!");
        }
        else if(DS3 != null)
        {
            Debug.Log("Dualshock 3 has found it!");
        }

    }


}
