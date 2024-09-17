using UnityEngine;
using TMPro;
using System.Collections;
using Zenject;
using System;
using DG.Tweening;

public class UIWidgetTimer : MonoBehaviour, IPauseHandler
{
    private const int SecondsInMinute = 60;
    public String CurrentTime => _timerView.text;
    public String BestTime; // must to edit

    private TMP_Text _timerView;
    private Level _level;
    private Coroutine _timerCoroutine;

    private int _sec = -1;
    private int _min;
    private int _delta = 1;
    private int _bestTime;

    private bool _isPaused;

    private void Start()
    {
        _timerView = GetComponentInChildren<TMP_Text>();
    }

    private void OnDisable()
    {
        _level.OnLevelStarted -= StartTimer;
        _level.OnLevelLost -= StopTimer;
        _level.OnLevelLost -= ResultTimerData;
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    [Inject]
    private void Construct(PauseManager _pauseManager, Level level)
    {
        _pauseManager.Register(this);

        _level = level;
        _level.OnLevelStarted += StartTimer;
        _level.OnLevelLost += StopTimer;
        _level.OnLevelLost += ResultTimerData;
    }

    private void StartTimer()
    {
        if (transform != null)
        {
            Debug.Log("ÂÛÇÂÀËÎÑÜ");
            _timerCoroutine = CoroutineRunner.StartRoutine(ITimer());

            DOTween.Sequence()
              .Append(transform.DOScale(0.8f, 0.1f))
              .Append(transform.DOScale(1.5f, 0.3f))
              .Append(transform.DOScale(1f, 0.2f));
        } 

    }

    private void ResultTimerData()
    {
        int resultTime = _min * SecondsInMinute + _sec;

        if (resultTime < _bestTime || _bestTime == 0)
            _bestTime = resultTime;
    }

    private void StopTimer()
    {
        CoroutineRunner.StopRoutine(_timerCoroutine);
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            if (_isPaused)
            {
                yield return null;
                continue;
            }

            if (_sec == 59)
            {
                _sec = -1;
                _min++;
            }
            _sec += _delta;
            _timerView.text = _min.ToString("D2") + ":" + _sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
