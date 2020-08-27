using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instance of JH_scoreMaster in JH_visitorBehaviour.cs

public class JH_scoreMaster : MonoBehaviour
{
    public int generalScore;
    public int[] paintingScore;
    public Boolean gameover;

    // Start is called before the first frame update
    void Start()
    {
        generalScore = 0;
        gameover = false;
        //here initializing paintingScore through the method Gameobject.FindGameObjectsWithTag("ownedPainting")
    }

    // Update is called once per frame
    void Update()
    {
        if (generalScore == -10) {
            gameover = true;
            Debug.Log("GAME OVER! You reached a general score of -10!");
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log(generalScore);
        }
    }

    public void raiseScore(GameObject painting) {
        generalScore += 3;
        //paintingScore on the right index raised (read the name of the painting or add a painting array with the gameobjects to transfer right index)
    }

    public void lowerScore(GameObject painting) {
        generalScore -= 2;
        //paintingScore on the right index lowered (read the name of the painting or add a painting array with the gameobjects to transfer right index)
    }
}
