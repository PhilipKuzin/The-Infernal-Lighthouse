using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}