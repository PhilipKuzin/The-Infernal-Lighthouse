using TMPro;
using UnityEngine;

public class UIWidgetTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.OnTimerStopped += ShowTimerResults;
    }

    private void OnDisable()
    {
        _timer.OnTimerStopped -= ShowTimerResults;
    }

    public void ShowTimerResults()
    {
        _currentScore.text = _timer.CurrentTime;
        _bestScore.text = _timer.BestTime;
    }

}
