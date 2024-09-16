using System;
using UnityEngine;
using Zenject;

public class Controls : MonoBehaviour, IDisposable
{
    [SerializeField] private GameObject _controlPanel;
    [SerializeField] private GameObject _mainPanel;

    private IInput _input;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
        _input.OnEscapeClicked += HideControlsPanel;
    }

    public void Dispose()
    {
        _input.OnEscapeClicked -= HideControlsPanel;
    }

    public void ShowControlsPanel ()
    {
        _mainPanel.SetActive(false);
        _controlPanel.SetActive (true);
    }

    private void HideControlsPanel(ref bool flag)
    {
        if (_mainPanel != null && _controlPanel != null)
        {
            _mainPanel.SetActive(true);
            _controlPanel.SetActive(false);

            flag = !flag;
        }
    }
}
