using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPopUpPausePanel : MonoBehaviour
{
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _resumeBtn;

    public event Action OnClickedRestartBtn;
    public event Action <bool> OnClickedResumeBtn;

    private bool _flag = false;

    private void OnEnable()
    {
        _restartBtn.onClick.AddListener(OnClickRestartBtn);
        _resumeBtn.onClick.AddListener(OnClickResumeBtn);
    }

    private void OnDisable()
    {
        _restartBtn?.onClick.RemoveListener(OnClickRestartBtn);
    }

    private void OnClickRestartBtn()
    {
        OnClickedRestartBtn?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnClickResumeBtn()
    {
        OnClickedResumeBtn?.Invoke (_flag);
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }
}
