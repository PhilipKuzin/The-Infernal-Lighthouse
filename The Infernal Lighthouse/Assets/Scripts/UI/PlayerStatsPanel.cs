using TMPro;
using UnityEngine;

public class PlayerStatsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthCounter;

    public void ChangeHealthView(int health)
    {
        _healthCounter.text = health.ToString();
        //Debug.Log("����� ��������");
    }

    public void ResetView(int health)
    {
        _healthCounter.text = health.ToString();
    }
}
