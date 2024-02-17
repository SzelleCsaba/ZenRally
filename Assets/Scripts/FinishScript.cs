using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject FinishMenu;

    public TMP_InputField input;

    public static bool InFinishScreen = false;

    //for finishing menu debugging
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FinishGame();
        }
    }*/

    public void FinishGame()
    {
        input.Select();
        input.ActivateInputField();

        InFinishScreen = true;

        TimingScript timer = GameObject.Find("Timer").GetComponent<TimingScript>();
        timer.countTime = false;
        FinishMenu.SetActive(true);
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        TextMeshProUGUI minText = GameObject.Find("FinishMinutes").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI secText = GameObject.Find("FinishSeconds").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI millisecText = GameObject.Find("FinishMillisecs").GetComponent<TextMeshProUGUI>();    
        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<RCC_CarControllerV3>().canControl = false;

        millisecText.text = MillisecToString(timer.totalMillisec);
        secText.text = $"{SecToString(timer.totalSec)}.";
        minText.text = $"{timer.totalMin}:";
    }

    string MillisecToString(float t)
    {
        if (t < 10)
        {
            return "00" + t.ToString("F0");
        }
        else if (t < 100)
        {
            return "0" + t.ToString("F0");
        }
        else
        {
            return t.ToString("F0");
        }
    }

    string SecToString(int t)
    {
        if (t < 10)
        {
            return $"0{t}";
        }
        else
        {
            return $"{t}";
        }
    }

    public void Restart()
    {
        InFinishScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Submit()
    {
        TimingScript timer = GameObject.Find("Timer").GetComponent<TimingScript>();

        string time = $"{timer.totalMin}:{SecToString(timer.totalSec)}.{MillisecToString(timer.totalMillisec)}";
        int sceneNumber = SceneManager.GetActiveScene().buildIndex - 1;
        string car = GetCarString(MainMenuScript.CarNumber);
        string playername = input.text;

        ScoreManager sm = GameObject.Find("FinishMenu").GetComponent<ScoreManager>();

        sm.AddScore(new Score(playername, time, car), sceneNumber);
    }

    string GetCarString(int i)
    {
        if(i == 1)
        {
            return "earth";
        }
        if(i == 2)
        {
            return "enif";
        }
        if(i == 3)
        {
            return "pegaso";
        }
        if(i == 4)
        {
            return "stellar";
        }
        if(i == 5)
        {
            return "pictoris";
        }
        return "";
    }
    

    public void Menu()
    {
        InFinishScreen = false;
        SceneManager.LoadScene(0);
    }
}
