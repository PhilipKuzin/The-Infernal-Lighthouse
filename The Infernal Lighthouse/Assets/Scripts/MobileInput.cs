using System;
using UnityEngine;
using Zenject;

public class MobileInput : IInput, ITickable
{
    public event Action<Vector3> OnPointerMove;
    public event Action<Vector3> OnClicked;

    private FixedJoystick _joystick;

    [Inject]
    private void Construct (FixedJoystick joystick)
    {
        _joystick = joystick;
    }
    public void Tick()
    {
        ProcessClick();
        ProcessJoystickMove();
    }

    private void ProcessJoystickMove()
    {
       
    }

    private void ProcessClick()
    {
        throw new NotImplementedException();
    }
}
