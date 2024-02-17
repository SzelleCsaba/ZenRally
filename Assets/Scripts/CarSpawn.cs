using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpawn : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        GameObject car = null;
        if(MainMenuScript.CarNumber == 1)
        {
            car = Instantiate(car1) as GameObject;
        }
        if(MainMenuScript.CarNumber == 2)
        {
            car = Instantiate(car2) as GameObject;
        }
        if(MainMenuScript.CarNumber == 3)
        {
            car = Instantiate(car3) as GameObject;
        }
        if(MainMenuScript.CarNumber == 4)
        {
            car = Instantiate(car4) as GameObject;
        }
        if(MainMenuScript.CarNumber == 5)
        {
            car = Instantiate(car5) as GameObject;
        }

        if(car != null)
        {
            car.SetActive(true);
            MeshRenderer[] CarMats = car.GetComponentsInChildren<MeshRenderer>();
            for(int j = 0; j < CarMats.Length; j++)
            {
                Material[] materials = CarMats[j].sharedMaterials;
                for(int i = 0; i < CarMats[j].sharedMaterials.Length; i++)
                {
                    materials[i] = mats[MainMenuScript.MaterialNumber];
                }
                CarMats[j].sharedMaterials = materials;
            }
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;
        }

        StartCoroutine(CountDownRoutine(car));
    }


    IEnumerator CountDownRoutine(GameObject car)
    {
        car.GetComponent<RCC_CarControllerV3>().NGear= true;
        
        GameObject countDown = GameObject.FindGameObjectWithTag("CntDown");

        countDown.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "3";
        AudioSource audio = car.GetComponentInChildren<Canvas>().GetComponentInChildren<AudioSource>();
        audio.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        car.GetComponent<RCC_CarControllerV3>().NGear = false;
        countDown.GetComponent<Text>().text = "GO!";
        countDown.SetActive(true);

        GameObject.Find("Timer").GetComponent<TimingScript>().StartCounting();
    }
}
