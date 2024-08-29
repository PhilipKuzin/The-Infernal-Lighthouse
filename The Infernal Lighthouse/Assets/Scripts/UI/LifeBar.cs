using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller;
    [SerializeField] private TMP_Text _healthCounter;
    [SerializeField] private GameObject _counterBackground;

    public void SetValue(float valueNormalized)
    {
        ScaleBackgroundCounter(valueNormalized);

        _imageFiller.fillAmount = valueNormalized;

        int valueInPercent = Mathf.RoundToInt(valueNormalized * 100f);
        _healthCounter.text = $"{valueInPercent}";
    }

    private void ScaleBackgroundCounter(float valueNormalized)
    {
        if (valueNormalized == 1)
            return;

        DOTween.Sequence()
            .Append(_counterBackground.transform.DOScale(0.8f, 0.1f))
            .Append(_counterBackground.transform.DOScale(1.5f, 0.3f))
            .Append(_counterBackground.transform.DOScale(1f, 0.2f));
    }
}
