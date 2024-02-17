using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public static int LeaderboardNumber = 0;
    public ScoreUI sui;
    public string[] LeaderboardName;
    public GameObject LeaderboardText;

    public static int CarNumber = 0;
    public Transform car1;
    public Transform car2;
    public Transform car3;
    public Transform car4;
    public Transform car5;
    public Transform map1;
    public Transform map2;
    public Transform map3;

    public GameObject Cars;

    public GameObject ColorText;

    public Material[] mats;

    public string[] MaterialNames;

    public static int MaterialNumber = 0;

    public void resetLeaderboardNumber()
    {
        LeaderboardNumber = 0;
        LeaderboardText.GetComponent<TextMeshProUGUI>().text = LeaderboardName[LeaderboardNumber];
        sui.RefreshLeaderboard();
    }

    public void incLeaderboardNumber()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        LeaderboardNumber++;
        if(LeaderboardNumber >= 4)
        {
            LeaderboardNumber = 0;
        }
        LeaderboardText.GetComponent<TextMeshProUGUI>().text = LeaderboardName[LeaderboardNumber];
        sui.RefreshLeaderboard();
    }

    public void decLeaderboardNumber()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        LeaderboardNumber--;
        if(LeaderboardNumber < 0)
        {
            LeaderboardNumber = 3;
        }
        LeaderboardText.GetComponent<TextMeshProUGUI>().text = LeaderboardName[LeaderboardNumber];
        sui.RefreshLeaderboard();
    }

    public void resetMaterialNumber()
    {
        MaterialNumber = 0;
        UpdateAllTextures();
    }

    public void nextMaterialNumber()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        MaterialNumber++;
        if(MaterialNumber >= mats.Length)
        {
            MaterialNumber = 0;
        }
        UpdateAllTextures();
    }

    public void beforeMaterialNumber()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        MaterialNumber--;
        if(MaterialNumber < 0)
        {
            MaterialNumber = mats.Length - 1;
        }
        UpdateAllTextures();
    }

    public void UpdateAllTextures()
    {
        ColorText.GetComponent<TextMeshProUGUI>().text = MaterialNames[MaterialNumber];

            MeshRenderer[] CarMats = Cars.GetComponentsInChildren<MeshRenderer>();
            for(int j = 0; j < CarMats.Length; j++)
            {
                Material[] materials = CarMats[j].sharedMaterials;
                for(int i = 0; i < CarMats[j].sharedMaterials.Length; i++)
                {
                    materials[i] = mats[MaterialNumber];
                }
                CarMats[j].sharedMaterials = materials;
            }
    }

    public void StartMap1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMap2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartMap3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void StartMap4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void setCarNumber(int i)
    {
        CarNumber = i;
    }

    public void setAllTransformToDefault()
    {
        Vector3 newRotation = new Vector3(0, 180, 0);
        car1.eulerAngles = newRotation;
        car2.eulerAngles = newRotation;
        car3.eulerAngles = newRotation;
        car4.eulerAngles = newRotation;
        car5.eulerAngles = newRotation;

        newRotation = new Vector3(-30, 0, 0);
        map1.eulerAngles = newRotation;
        map2.eulerAngles = newRotation;
        map3.eulerAngles = newRotation;
    }

}
