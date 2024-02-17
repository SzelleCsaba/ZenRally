using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRotation : MonoBehaviour
{

    public Transform parent;
    public Vector3 rotatewith;
    public float speed;
    private bool activeRotatation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeRotatation)
            parent.Rotate(rotatewith * speed * Time.deltaTime/2);
    }

    public void changeWhenHover(){
        activeRotatation = true;
    }

    public void changeWhenLeaves(){
        activeRotatation = false;
    }
}
