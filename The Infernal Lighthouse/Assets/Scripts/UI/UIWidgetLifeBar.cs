using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidgetLifeBar : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
  
    public void ChangeHealthView(float health)
    {
        _progressBar.SetValue(health);
    }

    public void ResetView(float health)
    {
        _progressBar.SetValue(health);
    }
}
