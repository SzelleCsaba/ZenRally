using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<RCC_CarControllerV3>().ResetToCheckPoint();
        }
    }
}
