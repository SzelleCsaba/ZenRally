using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingScript : MonoBehaviour
{
    public int totalMin;
    public int totalSec;
    public float totalMillisec;

    private int lapMin;
    private int lapSec;
    private float lapMillisec;

    private GameObject minText;
    private GameObject secText;
    private GameObject milliText;

    private int sectorMin;
    private int sectorSec;
    private float sectorMillisec;

    private GameObject sectorMinText;
    private GameObject sectorSecText;
    private GameObject sectorMilliText;

    public bool countTime;

    private void Start()
    {
        countTime = false;
    }
    
    void Update()
    {
        if (countTime)
        {
            totalMillisec += Time.deltaTime * 1000;
            lapMillisec += Time.deltaTime * 1000;

            if (totalMillisec >= 1000)
            {
                totalMillisec = 0;
                totalSec++;
            }
            if(lapMillisec>= 1000)
            {
                lapMillisec = 0;
                lapSec++;
            }

            if (totalSec >= 60)
            {
                totalSec = 0;
                totalMin++;
            }
            if(lapSec>= 60)
            {
                lapSec = 0;
                lapMin++;
            }

            if (totalMillisec < 10) { 
                milliText.GetComponent<Text>().text= "00" + totalMillisec.ToString("F0");
            }
            else if (totalMillisec < 100) {
                milliText.GetComponent<Text>().text = "0" + totalMillisec.ToString("F0");
            }
            else
            {
                milliText.GetComponent<Text>().text = totalMillisec.ToString("F0");
            }
            if (totalSec < 10)
            {
                secText.GetComponent<Text>().text = $"0{totalSec}.";
            }
            else
            {
                secText.GetComponent<Text>().text = $"{totalSec}.";
            }
            minText.GetComponent<Text>().text = $"{totalMin}:";          
        }
    }

    public void EndLap()
    {
        lapMin = 0;
        lapSec = 0;
        lapMillisec = 0;
    }

    public void EndSector()
    {      
        sectorMin = lapMin;
        sectorSec = lapSec;
        sectorMillisec = lapMillisec;
        if (sectorMillisec < 10)
        {
            sectorMilliText.GetComponent<Text>().text = "00" + sectorMillisec.ToString("F0");
        }
        else if (sectorMillisec < 100)
        {
            sectorMilliText.GetComponent<Text>().text = "0" + sectorMillisec.ToString("F0");
        }
        else
        {
            sectorMilliText.GetComponent<Text>().text = sectorMillisec.ToString("F0");
        }
        if (sectorSec < 10)
        {
            sectorSecText.GetComponent<Text>().text = $"0{sectorSec}.";
        }
        else
        {
            sectorSecText.GetComponent<Text>().text = $"{sectorSec}.";
        }
        sectorMinText.GetComponent<Text>().text = $"{sectorMin}:";
        sectorMinText.GetComponentInParent<Animator>().Play("sectortimeanimation", 0, 0.0f);
    }

    public void StartCounting()
    {
        countTime = true;
        totalMin = 0;
        totalSec = 0;
        totalMillisec = 0;
        minText = GameObject.Find("Minutes");
        secText = GameObject.Find("Seconds");
        milliText = GameObject.Find("Millisecs");

        sectorMinText = GameObject.Find("SectorMinutes");
        sectorSecText = GameObject.Find("SectorSeconds");
        sectorMilliText = GameObject.Find("SectorMillisecs");
    }

    public void PenaltyTime()
    {
        lapSec += 5;
        totalSec += 5;
        GameObject.Find("PenaltyText").GetComponent<Text>().text = "+5 sec";
        GameObject.Find("PenaltyText").GetComponent<Animator>().Play("penaltyanimation",0,0.0f);
    }
}
