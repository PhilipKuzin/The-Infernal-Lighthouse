using TMPro;
using UnityEngine;

public class UIWidgetLifeBar : MonoBehaviour
{
    [SerializeField] private LifeBar _lifeBar;

  
    public void ChangeHealthView(float health)
    {
        _lifeBar.SetValue(health);

    }

    public void ResetView(float health)
    {
        _lifeBar.SetValue(health);

    }
}
