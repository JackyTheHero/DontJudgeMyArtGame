using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instance of JH_scoreMaster in JH_visitorBehaviour.cs

public class JH_scoreMaster : MonoBehaviour
{
    public static int generalScore;
    public static int[] paintingScore;
    public static Boolean gameover;
    public static GameObject[] ownedPaintings;

    // Start is called before the first frame update
    void Start()
    {
        //initializing / resetting the ownedPaintings array; every owned painting gets a tag
        setOwnedPaintings();

        //initializing / resetting the scores
        resetScores();
    }

    // Update is called once per frame
    void Update()
    {
        setOwnedPaintings();

        if (generalScore <= -10) {
            gameover = true;
            Debug.Log("GAME OVER! You reached a general score of " + getGeneralScore() + " !");
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log("generalScore: " + getGeneralScore());
        }

        //ownedPaintings = GameObject.FindGameObjectsWithTag("ownedPainting");
    }

    public static void raiseScore(GameObject painting) {
        //generalScore += 3;

        int index = getPaintingIndex(painting);

        //use found index in paintingScore
        paintingScore[index] += 3;
    }

    public static void lowerScore(GameObject painting) {
        //generalScore -= 2;
        
        int index = getPaintingIndex(painting);

        //use found index in paintingScore
        paintingScore[index] -= 2;
    }

    public static int getGeneralScore()
    {
        //only existing paintings are going into the score
        int generalScorePlus = generalScore;

        for(int i = 0; i < ownedPaintings.Length; i++)
        {
            generalScorePlus += paintingScore[i];
        }
        
        return generalScorePlus;
    }

    public static int getPaintingScore(GameObject painting) {
        return paintingScore[getPaintingIndex(painting)];
    }
    
    //Keep in mind that all (destroyed) paintings have to be reset BEFORE calling this method; an array is initialized containing all owned paintings
    //if resetScores is called before that, the painting scores are possibly not in the right order
    public static void resetScores() {
        gameover = false;
        generalScore = 0;

        paintingScore = new int[ownedPaintings.Length];

        for (int i = 0; i < paintingScore.Length; i++)
        {
            paintingScore[i] = 0;
        }

        
        ownedPaintings = GameObject.FindGameObjectsWithTag("ownedPainting");
    }

    //search the index of the right painting in the ownedPaintings array
    public static int getPaintingIndex(GameObject painting)
    {
        int i = 0;

        //the score of the painting on the x index of ownedPaintings has the index x in paintingScore
        while (i < ownedPaintings.Length && ownedPaintings[i].name != painting.name)
        {
            ++i;
        }

        return i;
    }

    public static void setOwnedPaintings()
    {
        // giving all owned paintings a tag to access them easier
        var gameObjList = GameObject.FindObjectsOfType<GameObject>();

        for (int i = 0; i < gameObjList.Length; i++)
        {
            if (gameObjList[i].name.Contains("owned") && gameObjList[i].name.Contains("Gemälde"))
            {
                gameObjList[i].tag = "ownedPainting";
            }
        }

        //own array for ownedPainting tagged GameObjects for easy access
        ownedPaintings = GameObject.FindGameObjectsWithTag("ownedPainting");
    }

    public static void raiseGeneralScore(Boolean stolen)
    {
        if (stolen) {
            generalScore += 10;
        }else
        {
            generalScore += 5;
        }
        
    }

}
