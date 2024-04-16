using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class ControllerManager : MonoBehaviour
{
    public void CheckIfPSController()
    {
        var DS4 = DualShockGamepad.current;
        
        if(DS4 != null)
        {
            DS4.SetLightBarColor(Color.cyan);
            Debug.Log("Dualshock 4 has found it!");
        }
        else
        {
            Debug.Log("No Dualshock 4 detected.");
        }

    }


}
