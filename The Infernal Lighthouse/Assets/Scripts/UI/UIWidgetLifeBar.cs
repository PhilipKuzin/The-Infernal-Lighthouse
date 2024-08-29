using TMPro;
using UnityEngine;

public class UIWidgetLifeBar : MonoBehaviour
{
    [SerializeField] private LifeBar _progressBar;

  
    public void ChangeHealthView(float health)
    {
        _progressBar.SetValue(health);

    }

    public void ResetView(float health)
    {
        _progressBar.SetValue(health);

    }
}
