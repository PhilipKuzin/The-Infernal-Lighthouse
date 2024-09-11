using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> OnPointerMove;
    public event Action<Vector3> OnMouseClicked;
    public event IInput.BoolEventHandler OnEscapeClicked;

    private const int LeftMouseBtn = 0;

    private bool _wasEscPressed = true;

    public void Tick()
    {
        ProcessClick();
        ProcessPointerMove();
        ProcessEscape();
    }

    public void ResetEscFlag()
    {
        _wasEscPressed = true;
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

    private void ProcessEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnEscapeClicked?.Invoke(ref _wasEscPressed); 
    }
}
