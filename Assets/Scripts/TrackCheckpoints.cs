using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointSingle> checkpointList;
    public Transform lastCheckpointPos;
    private int nextCheckpointIndex;

    public int lapToComplete;
    private int currentLap;

    private void Awake()
    { 
        checkpointList = new List<CheckpointSingle>();
        Transform checkpointsTransform = transform.Find("Checkpoints");

        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);

            checkpointList.Add(checkpointSingle);
        }

        lastCheckpointPos = checkpointList[0].transform;
        nextCheckpointIndex = 0;
        currentLap = 1;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle, Collider car)
    {
        if (currentLap <= lapToComplete)
        {
            if (checkpointList.IndexOf(checkpointSingle) == nextCheckpointIndex)
            {
                nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;               
                lastCheckpointPos=checkpointSingle.transform;
                lastCheckpointPos.position = new Vector3(lastCheckpointPos.position.x, car.ClosestPoint(lastCheckpointPos.position).y, lastCheckpointPos.position.z);
                if (checkpointSingle.endOfSector)
                {
                    GameObject.Find("Timer").GetComponent<TimingScript>().EndSector();
                }
                if (nextCheckpointIndex == 0)
                {
                    GameObject.Find("Timer").GetComponent<TimingScript>().EndLap();
                    currentLap++;
                    if(currentLap > lapToComplete)
                    {
                        GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishScript>().FinishGame();
                    }
                }
            }
            else if(checkpointList.IndexOf(checkpointSingle) != nextCheckpointIndex-1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInParent<RCC_CarControllerV3>().ResetToCheckPoint();
            }
        }
        GameObject.FindGameObjectWithTag("LapCNT").GetComponent<Text>().text = $"{currentLap} / {lapToComplete}";
    }
}
