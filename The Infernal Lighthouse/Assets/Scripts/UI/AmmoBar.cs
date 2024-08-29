using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller;

    public void StartReloadProcess(float duration)
    {
        _imageFiller.fillAmount = 1f;

        DOTween.Sequence()
            .Append(transform.DOScale(0.8f, 0.1f))
            .Append(transform.DOScale(1.5f, 0.3f))
            .Append(transform.DOScale(1f, 0.2f));

        StartCoroutine(FillAmmoBar(duration));
    }

    private IEnumerator FillAmmoBar(float duration)
    {
        Debug.Log(" Œ–”“»Õ¿ «¿œ”—“»À¿—‹");
        float elapsed = 0f;

        while (elapsed < duration)
        {
            
            elapsed += Time.deltaTime;
            _imageFiller.fillAmount -= (Time.deltaTime / duration);
            yield return null;
        }

        _imageFiller.fillAmount = 0f;
    }

    public void ResetAmmoBar()
    {
        _imageFiller.fillAmount = 0f;
    }
}
