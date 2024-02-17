using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;
    public GameObject baseObject;
    
    void Start()
    {
        /*
        scoreManager.AddScore(new Score("ez", "egy", "score"), 2);
        scoreManager.AddScore(new Score("ezz", "egy", "scoree"), 2);
        scoreManager.AddScore(new Score("ezzz", "egy", "scoreee"), 2);
        scoreManager.AddScore(new Score("ezzzz", "egy", "scoreeee"), 2);
        scoreManager.AddScore(new Score("ezzz", "egy", "scoreeeeee"), 2);
        scoreManager.AddScore(new Score("ezzzz", "egy", "scoreeeeeeee"), 2);
        scoreManager.AddScore(new Score("edfgdfz", "egdfgdfgy", "scordfgdfge"), 2);
        scoreManager.AddScore(new Score("ezsdfgdfz", "egdfgdfgy", "scordfgdfgee"), 2);
        scoreManager.AddScore(new Score("ezdfbvdfzz", "edfgdfggy", "scordfgdfgeee"), 2);
        scoreManager.AddScore(new Score("ezdfgdfgzzz", "egdfgdfgy", "scodfdfgdfreeee"), 2);
        scoreManager.AddScore(new Score("ezdfgdfdgzz", "egydfgdf", "scoreeedfveee"), 2);
        scoreManager.AddScore(new Score("ezdfgvdfgzzz", "edfvdfvgy", "scoreevdfvdfeeeeee"), 2);
*/
        RefreshLeaderboard();
    }

    public void RefreshLeaderboard()
    {
        for (var i = baseObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(baseObject.transform.GetChild(i).gameObject);
        }

        var scores = scoreManager.GetHighScores(MainMenuScript.LeaderboardNumber).ToArray();
        int j = Math.Min(scores.Length, 10);
        for (int i = 0; i < j; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.pname.text = scores[i].name;
            row.time.text = scores[i].time;
            row.car.text = scores[i].car;
        }
    }
}
