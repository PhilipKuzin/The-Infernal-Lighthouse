using System;
using UnityEngine;

public class MovementHandler : IDisposable
{
    private IInput _input;

    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnClicked;

    public MovementHandler(IInput input)
    {
        _input = input;
        _input.OnPointerMove += Move;
        _input.OnMouseClicked += Click;
    }

    public void Click(Vector3 position)
    {
        OnClicked?.Invoke(position);
    }

    public void Move(Vector3 position)
    {
        OnMove?.Invoke(position);
    }

    public void Dispose()
    {
        _input.OnPointerMove -= Move;
        _input.OnMouseClicked -= Click;
    }
}
