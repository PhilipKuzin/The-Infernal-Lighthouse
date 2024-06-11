using System;
using UnityEngine;

public interface IInput
{
    event Action<Vector3> OnPointerMove;
    event Action<Vector3> OnClicked;
}