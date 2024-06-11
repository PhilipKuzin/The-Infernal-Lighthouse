using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementHandler : IDisposable
{
    private IInput _input;

    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnClicked;


    public MovementHandler(IInput input)
    {
        _input = input;

        _input.OnPointerMove += Move;
        _input.OnClicked += Click;

    }

    public void Click(Vector3 position)
    {
        Debug.Log($"Click at position {position}");
        OnClicked?.Invoke(position);
    }

    public void Move(Vector3 position)
    {
        Debug.Log("Move is in progress");
        OnMove?.Invoke(position);
    }

    public void Dispose()
    {
        _input.OnPointerMove -= Move;
        _input.OnClicked -= Click;
    }
}
