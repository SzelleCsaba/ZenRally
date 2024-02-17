using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData[] sd;
    void Awake()
    {
        sd = new ScoreData[4];
        for(int i = 0; i < 4; i++)
        {
            var json = PlayerPrefs.GetString($"scores{i}", "{}");
            sd[i] = JsonUtility.FromJson<ScoreData>(json);
        }
    }

    public IEnumerable<Score> GetHighScores(int i)
    {
        return sd[i].scores.OrderBy(x => x.time);
    }

    public void AddScore(Score score, int i)
    {
        sd[i].scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        for(int i = 0; i < 4; i++)
        {
            var json = JsonUtility.ToJson(sd[i]);
            PlayerPrefs.SetString($"scores{i}", json);
        }
    }
}
