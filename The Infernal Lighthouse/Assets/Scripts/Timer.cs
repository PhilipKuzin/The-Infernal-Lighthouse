using UnityEngine;
using TMPro;
using System.Collections;
using Zenject;
using System;
using DG.Tweening;

public class Timer : MonoBehaviour, IPauseHandler
{
    private const int SecondsInMinute = 60;

    public event Action OnTimerStopped;
    public String CurrentTime => _currentTimerView.text;
    public String BestTime { get; private set; }

    private TMP_Text _currentTimerView;

    private Level _level;
    private GameResultSaver _gameResultSaver;
    private Coroutine _timerCoroutine;

    private int _sec = -1;
    private int _min;
    private int _delta = 1;
    private int _bestTime = 0;

    private bool _isPaused;

    private void Start()
    {
        _currentTimerView = GetComponent<TMP_Text>();
        _bestTime = _gameResultSaver.GetBestScore(); 
        BestTime = FormatTime(_bestTime); 
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
    private void Construct(PauseManager _pauseManager, Level level, GameResultSaver gameResultSaver)
    {
        _pauseManager.Register(this);

        _level = level;
        _gameResultSaver = gameResultSaver;
        _level.OnLevelStarted += StartTimer;
        _level.OnLevelLost += StopTimer;
        _level.OnLevelLost += ResultTimerData;
    }

    private void StartTimer()
    {
        if (transform != null)
        {
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

        if (resultTime > _bestTime) 
        {
            _bestTime = resultTime;
            BestTime = FormatTime(_bestTime);
            _gameResultSaver.SaveBestScore(_bestTime); 
        }
    }

    private string FormatTime(int timeInSeconds)
    {
        int minutes = timeInSeconds / SecondsInMinute;
        int seconds = timeInSeconds % SecondsInMinute;
        return $"{minutes:D2}:{seconds:D2}";
    }

    private void StopTimer()
    {
        ResultTimerData();
        CoroutineRunner.StopRoutine(_timerCoroutine);
        OnTimerStopped?.Invoke();
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
            _currentTimerView.text = _min.ToString("D2") + ":" + _sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
