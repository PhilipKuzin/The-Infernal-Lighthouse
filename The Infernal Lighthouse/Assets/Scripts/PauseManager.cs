using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : IPauseHandler
{
    private readonly List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();

    public bool IsPaused { get; private set; }

    public void Register (IPauseHandler handler)
    {
        _pauseHandlers.Add(handler);
    }

    public void UnRegister(IPauseHandler handler)
    {
        _pauseHandlers.Remove(handler);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;

        foreach(var handler in _pauseHandlers)
        {
            handler.SetPaused(isPaused);
        }
    }

    
}
