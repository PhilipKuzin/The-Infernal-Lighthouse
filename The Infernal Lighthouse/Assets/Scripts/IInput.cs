﻿using System;
using UnityEngine;

public interface IInput
{
    delegate void BoolEventHandler(ref bool value);

    event Action<Vector3> OnPointerMove;
    event Action<Vector3> OnMouseClicked;
    //event Action<bool> OnEscapeClicked;

    public event BoolEventHandler OnEscapeClicked;
}