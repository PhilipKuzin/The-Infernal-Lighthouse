using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> OnPointerMove;
    public event Action<Vector3> OnClicked;

    private const int LeftMouseBtn = 0;

    public void Tick()
    {
        ProcessClick();
        ProcessPointerMove();
    }

    private void ProcessPointerMove()
    {
        OnPointerMove?.Invoke(Input.mousePosition);
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(LeftMouseBtn))
            OnClicked?.Invoke(Input.mousePosition);
    }
}
