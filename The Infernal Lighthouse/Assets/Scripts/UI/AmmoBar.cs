using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image _imageFiller;

    public void StartReloadProcess(float duration)
    {
        _imageFiller.fillAmount = 1f;
        Debug.Log("���� ��� ������� �����������");
        StartCoroutine(FillAmmoBar(duration));
    }

    private IEnumerator FillAmmoBar(float duration)
    {
        Debug.Log("�������� �����������");
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
