using System.Collections;
using UnityEngine;
using Zenject;

public class StartCountController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private StartCountFunction[] numberAnimations;
    private PauseManager _pauseManager;

    private float delayBetweenNumbers = 1f;
    private bool _isPaused;

    private void Start()
    {
        CoroutineRunner.StartRoutine(PlayNumberAnimations());
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    [Inject]
    private void Construct(PauseManager pauseManager)
    {
        _pauseManager = pauseManager;
        _pauseManager.Register(this);
    }

    private IEnumerator PlayNumberAnimations()
    {
        foreach (var numberAnimation in numberAnimations)
        {

            while (_isPaused)
                yield return null;

            numberAnimation.DoStartAnimation();
            yield return new WaitForSeconds(delayBetweenNumbers);
        }
        // здесь стартовать уровень
    }

}