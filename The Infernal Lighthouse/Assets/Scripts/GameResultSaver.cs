using UnityEngine;

public class GameResultSaver
{
    private const string BestScoreKey = "BestScore";

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, int.MaxValue); 
    }

    public void SaveBestScore(int score)
    {
        int currentBestScore = GetBestScore();

        if (score > currentBestScore) 
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}