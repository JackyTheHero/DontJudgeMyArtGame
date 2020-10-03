﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* TO-DO:
- visitor walks around
- if near a painting by the player: walks to it and activates speech bubble   || in progress; visitor reacts with speechbubble if Trigger is entered
- mostly random review by speech bubble: positive or negative
- review will be added to picture score and general score
- visitor walks away --> loops begins again

 - visitors become invisible when player is in interaction menu
 */


public class JH_visitorBehaviour : MonoBehaviour
{

    // public GameObject visitor; // visitor height --> 4 tiles
    public GameObject speechBubble;
    public Boolean nearPainting;
    private Rigidbody visitRigid;
    private int goodOrBad;
    Texture speechTexture;
    float countdown;
    Boolean countsDown;
    Collider otherCollider;
    NavMeshAgent agent;
    GameObject[] ownedPaintings;


    // Start is called before the first frame update
    void Start()
    {
        //set speechBubble to visitorPosition and set parent to visitor figure
        createSpeechBubble();
        speechBubble.SetActive(false);

        speechBubble.transform.position = this.transform.position;
        speechBubble.transform.parent = this.transform;

        nearPainting = false;

        //adding Collider and Rigidbody for Trigger recognition
        Collider visitorColl = this.GetComponent<Collider>();

        visitRigid = this.GetComponent<Rigidbody>();
        visitRigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //this.gameObject.AddComponent<JH_scoreMaster>();

        countdown = 0;
        countsDown = false;

        otherCollider = null;

        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(RatingCoroutine());
    }

    IEnumerator RatingCoroutine()
    {
        //leichte Verzögerung, damit NavMesh zuerst erstellt wird
        yield return new WaitForSeconds(0.2f);
        ownedPaintings = GameObject.FindGameObjectsWithTag("ownedPainting");
        
        //Zufälliges Bild des Spielers wird ausgewählt und als Ziel gesetzt
        int randomOwnedPainting = (int)UnityEngine.Random.Range(0.0f, ownedPaintings.Length);
        agent.destination = ownedPaintings[randomOwnedPainting].transform.position;
        Debug.Log(this.gameObject + " is walking to " + agent.destination);

        //Warte so lange, bis der Collider des Bildes aktiviert wurde und warte da dann 20 Sekunden
        yield return new WaitUntil(() => getCollidedObject() == ownedPaintings[randomOwnedPainting]);
        yield return new WaitForSeconds(20);
        
        //neues Bild zur Bewertung wird gesucht 
        StartCoroutine(RatingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //if no painting, no speechBubble
        //if near painting, speechBubble appears for 10 seconds
        //after 20 seconds speechBubble disappears and visitor moves on
        //this.transform.LookAt(agent.destination);
        if (nearPainting) speak();
    }

    public void speak()
    {
        //countdown -= Time.deltaTime;

            //constraints to freeze the figure in place
        //visitRigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //move up speechbubble until it reaches its position at y = 5.0f
        speechBubble.SetActive(true);
        if (speechBubble.transform.position.y < 5.0f) {
            speechBubble.transform.position += new Vector3(0.0f, 0.02f, 0.0f);
        } else {
            speechBubble.transform.Rotate(0.0f, 0.1f, 0.0f); 
        }
    }

    private void createSpeechBubble()
    {
        Mesh speechMesh = new Mesh();
        speechBubble = new GameObject("speechBubble", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer speechRend = speechBubble.GetComponent<Renderer>();
        speechRend.material = new Material(Shader.Find("Standard"));

        speechTexture = Resources.Load("thumbsUp") as Texture;
        speechRend.material.mainTexture = speechTexture;

        speechMesh = speechBubble.GetComponent<MeshFilter>().mesh;

        speechMesh.Clear();

        List<Vector3> speechVertices = new List<Vector3>();
        List<int> speechTriangles = new List<int>();
        List<Vector2> speechUv = new List<Vector2>();

        speechVertices.Add(new Vector3(-0.5f,0 , 0.5f));
        speechVertices.Add(new Vector3(0.5f, 0, 0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, 0.5f));
        speechVertices.Add(new Vector3(-0.5f, 1, 0.5f));

        speechVertices.Add(new Vector3(0.5f, 0, 0.5f));
        speechVertices.Add(new Vector3(0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, -0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, 0.5f));

        speechVertices.Add(new Vector3(0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(-0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(-0.5f, 1, -0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, -0.5f));

        speechVertices.Add(new Vector3(-0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(-0.5f, 0, 0.5f));
        speechVertices.Add(new Vector3(-0.5f, 1, 0.5f));
        speechVertices.Add(new Vector3(-0.5f, 1, -0.5f));

        //oben
        speechVertices.Add(new Vector3(-0.5f, 1, 0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, 0.5f));
        speechVertices.Add(new Vector3(0.5f, 1, -0.5f));
        speechVertices.Add(new Vector3(-0.5f, 1, -0.5f));

        //unten
        speechVertices.Add(new Vector3(-0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(0.5f, 0, -0.5f));
        speechVertices.Add(new Vector3(0.5f, 0, 0.5f));
        speechVertices.Add(new Vector3(-0.5f, 0, 0.5f));

        speechMesh.vertices = speechVertices.ToArray();

        for (int i = 0; i < speechMesh.vertices.Length; i = i + 4)
        {
            speechTriangles.Add(i);
            speechTriangles.Add(i + 1);
            speechTriangles.Add(i + 2);
            speechTriangles.Add(i);
            speechTriangles.Add(i + 2);
            speechTriangles.Add(i + 3);
        }

        speechMesh.triangles = speechTriangles.ToArray();

        for (int j = 0; j < speechMesh.vertices.Length; j = j + 4)
        {
            speechUv.Add(new Vector2(0, 0));
            speechUv.Add(new Vector2(1, 0));
            speechUv.Add(new Vector2(1, 1));
            speechUv.Add(new Vector2(0, 1));
        }

        speechMesh.uv = speechUv.ToArray();

        speechMesh.RecalculateNormals();
    }
    
    void OnTriggerEnter(Collider other) {
        //saves other collider to 
        otherCollider = other;

        //if trigger of owned painting was entered
        if (other.gameObject.tag == "ownedPainting") {
            nearPainting = true;

            //random number decides if there is a good or bad review (0 == bad, 1 and 2 == good)
            goodOrBad = (int) UnityEngine.Random.Range(0f, 3f);

            if (goodOrBad >= 1)
            {
                speechTexture = Resources.Load("thumbsUp") as Texture;
                speechBubble.GetComponent<Renderer>().material.mainTexture = speechTexture;
                JH_scoreMaster.raiseScore(other.gameObject);
            }
            else {
                speechTexture = Resources.Load("thumbsDown") as Texture;
                speechBubble.GetComponent<Renderer>().material.mainTexture = speechTexture;
                JH_scoreMaster.lowerScore(other.gameObject);
            }
        } else
        {
            nearPainting = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        speechBubble.SetActive(false);
        speechBubble.transform.position = this.transform.position;
        otherCollider = null;
        nearPainting = false;
    }
    
    public GameObject getCollidedObject()
    {
        if (otherCollider != null)
        {
            return otherCollider.gameObject;
        }
       
        return this.gameObject;
    }
}
