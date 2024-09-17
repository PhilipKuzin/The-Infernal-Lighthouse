using DG.Tweening;
using TMPro;
using UnityEngine;

public class StartCountFunction : MonoBehaviour
{
    private TMP_Text _sign;

    private void OnDestroy()
    {
        DOTween.KillAll();
    }

    public void DoStartAnimation()
    {
        _sign = GetComponent<TMP_Text>();

        gameObject.SetActive(true);

        if (_sign != null )
        {
            _sign.DOFade(0f, 1.5f).OnComplete(() =>
            {
                if (gameObject != null)
                {
                    gameObject.SetActive(false);
                }
            });
        }

    }
}