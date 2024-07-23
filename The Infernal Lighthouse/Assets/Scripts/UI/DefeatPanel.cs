using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Button _restartBtn;

    public event Action OnClickRestartBtn;

    private void OnEnable()
    {
        _restartBtn.onClick.AddListener(OnClickBtn);
    }

    private void OnDisable()
    {
        _restartBtn?.onClick.RemoveListener(OnClickBtn);
    }

    public void ShowPanel() => gameObject.SetActive(true);

    public void HidePanel() => gameObject.SetActive(false);

    private void OnClickBtn()
    {
        OnClickRestartBtn?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
