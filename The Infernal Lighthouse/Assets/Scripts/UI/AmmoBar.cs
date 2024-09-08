using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using TMPro;

public class AmmoBar : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Image _imageFiller;
    [SerializeField] private TMP_Text _ammoAmount;

    private PauseManager _pauseManager;

    private bool _isPaused;

    [Inject]
    private void Construct(PauseManager pauseManager)
    {
        _pauseManager = pauseManager;
        _isPaused = _pauseManager.IsPaused;

        _pauseManager.Register(this);
    }

    public void ChangeAmmoAmount(int ammoAmount)
    {
        _ammoAmount.text = $"{ammoAmount}";
    }

    public void StartReloadProcess(float duration)
    {
        CoroutineRunner.StartRoutine(FillAmmoBar(duration));
    }

    public void ResetAmmoBar()
    {
        _imageFiller.fillAmount = 0f;
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    private IEnumerator FillAmmoBar(float duration)
    {
        _imageFiller.fillAmount = 1f;

        DOTween.Sequence()
            .Append(transform.DOScale(0.8f, 0.1f))
            .Append(transform.DOScale(1.5f, 0.3f))
            .Append(transform.DOScale(1f, 0.2f));

        float elapsed = 0f;

        while (elapsed < duration)
        {
            while (_isPaused)
            {
                yield return null;
            }

            elapsed += Time.deltaTime;
            _imageFiller.fillAmount -= (Time.deltaTime / duration);
            yield return null;
        }

        if (elapsed == duration)
            _imageFiller.fillAmount = 0f;
    }
}
