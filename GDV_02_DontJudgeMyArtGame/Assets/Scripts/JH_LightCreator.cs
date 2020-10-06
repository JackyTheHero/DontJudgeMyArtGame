using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_LightCreator : MonoBehaviour
{
    private static List<GameObject> closedWindows;
    private static List<GameObject> openWindows;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddWindowLighting()
    {
        closedWindows = new List<GameObject>();
        openWindows = new List<GameObject>();

        ListAllWindows();

        for (int i = 0; i < closedWindows.Count; i++)
        {
            //Vier Lichter für vier Fensterteile
            for (int j = 0; j < 4; j++)
            {
                //neues Licht mit Werten erstellen
                GameObject light = new GameObject();
                light.AddComponent<Light>();
                light.name = "ClosedWindowLight " + j + " of window " + i;
                light.transform.position = closedWindows[i].transform.position;
                light.GetComponent<Light>().range = 7.6f;
                light.GetComponent<Light>().intensity = 0.04f;
                light.GetComponent<Light>().color = new Color(243, 238, 201);


                light.transform.parent = closedWindows[i].transform;

                switch (j)
                {
                    case 0:
                        light.transform.position = closedWindows[i].transform.position + closedWindows[i].transform.rotation * new Vector3(-2, 2, -0.5f);
                        break;
                    case 1:
                        light.transform.position = closedWindows[i].transform.position + closedWindows[i].transform.rotation * new Vector3(2, 2, -0.5f);
                        break;
                    case 2:
                        light.transform.position = closedWindows[i].transform.position + closedWindows[i].transform.rotation * new Vector3(-2, -2, -0.5f);
                        break;
                    case 3:
                        light.transform.position = closedWindows[i].transform.position + closedWindows[i].transform.rotation * new Vector3(2, -2, -0.5f);
                        break;
                }
            }
        }

        for (int i = 0; i < openWindows.Count; i++)
        {
            //Vier Lichter für vier Fensterteile
            for (int j = 0; j < 2; j++)
            {
                //neues Licht mit Werten erstellen
                GameObject light = new GameObject();
                light.AddComponent<Light>();
                light.name = "OpenWindowLight " + j + " of window " + i;
                light.transform.position = openWindows[i].transform.position;
                light.GetComponent<Light>().range = 7.6f;
                light.GetComponent<Light>().intensity = 0.04f;
                light.GetComponent<Light>().color = new Color(243, 238, 201);
                
                light.transform.parent = openWindows[i].transform;

                switch (j)
                {
                    case 0:
                        light.transform.position += new Vector3(-2, 2, 0);
                        break;
                    case 1:
                        light.transform.position += new Vector3(2, 2, 0);
                        break;
                }
            }
        }
    }

    static void ListAllWindows()
    {
        var gameObjList = GameObject.FindObjectsOfType<GameObject>();
        
        for (int i = 0; i < gameObjList.Length; i++)
        {
            if (gameObjList[i].name == "Fenster(Clone)")
            {
                closedWindows.Add(gameObjList[i]);
            }

            if (gameObjList[i].name == "FensterOffen(Clone)")
            {
                openWindows.Add(gameObjList[i]);
            }
        }
    }
}
