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
        Debug.Log("Œ“–¿¡Œ“¿À");
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
        Debug.Log("’¿…ƒ œ¿Õ≈À Œ“–¿¡Œ“¿À");
        if (_mainPanel != null && _controlPanel != null)
        {
            _mainPanel.SetActive(true);
            _controlPanel.SetActive(false);

            flag = !flag;
        }
    }
}
