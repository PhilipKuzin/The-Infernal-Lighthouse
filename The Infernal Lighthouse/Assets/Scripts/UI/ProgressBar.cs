using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller;
    [SerializeField] private TMP_Text _healthCounter;

    public void SetValue (float valueNormalized)
    {
        _imageFiller.fillAmount = valueNormalized;

        int valueInPercent = Mathf.RoundToInt(valueNormalized * 100f);
        _healthCounter.text = $"{valueInPercent}";
    }
}
