using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Kamera folgt player
        Camera.main.transform.position = player.transform.position;
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.Translate(0, 2, -6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}