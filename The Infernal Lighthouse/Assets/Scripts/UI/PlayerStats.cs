using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthCounter;

    public void ChangeHealthView(int health)
    {
        _healthCounter.text = health.ToString();
        //Debug.Log("Статы изменены");
    }

    public void ResetView(int health)
    {
        _healthCounter.text = health.ToString();
    }
}
