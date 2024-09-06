using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> OnPointerMove;
    public event Action<Vector3> OnMouseClicked;
    public event Action<bool> OnEscapeClicked;

    private const int LeftMouseBtn = 0;

    private bool _wasEscPressed = false;

    public void Tick()
    {
        ProcessClick();
        ProcessPointerMove();
        ProcessEscape();
    }

    private void ProcessPointerMove()
    {
        OnPointerMove?.Invoke(Input.mousePosition);
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(LeftMouseBtn))
            OnMouseClicked?.Invoke(Input.mousePosition);
    }

    private void ProcessEscape ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _wasEscPressed = !_wasEscPressed;
            OnEscapeClicked?.Invoke(_wasEscPressed);
        }
            
    }
 
}
