using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CheckpointSingle : MonoBehaviour
{

    private TrackCheckpoints trackCheckpoints;

    public bool endOfSector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trackCheckpoints.PlayerThroughCheckpoint(this, other);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
