using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{

    public Action<Vector3> OnInput;

    [SerializeField] private Joystick _joystick;



    private void Update()
    {
        InputProcess();
    }

    private void InputProcess()
    {
        
        
        OnInput?.Invoke(joystickDirection);

    }
    

    private Vector3 joystickDirection
    {
        get { return new Vector3(_joystick.Direction.x*0.1f,0,0); }
    }



    
}
