using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject textBubble;
    public Boolean nearPainting;
    private Rigidbody visitRigid;
    private int goodOrBad;
    public JH_scoreMaster scoreMaster;

    // Start is called before the first frame update
    void Start()
    {
        //set textBubble to visitorPosition and set parent to visitor figure
        textBubble = GameObject.CreatePrimitive(PrimitiveType.Cube);
        textBubble.SetActive(false);

        textBubble.transform.position = this.transform.position;
        textBubble.transform.parent = this.transform;

        nearPainting = false;

        //adding Collider and Rigidbody for Trigger recognition
        Collider visitorColl = this.GetComponent<Collider>();

        visitRigid = this.GetComponent<Rigidbody>();
        visitRigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        scoreMaster = this.gameObject.AddComponent<JH_scoreMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearPainting) {
            speak();
        }
    }

    public void speak()
    {
        
        //constraints to freeze the figure in place
        visitRigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //need something like Time.time to time the review (maybe 10 secs active)

        //move up speechbubble until it reaches its position at y = 5.0f
        textBubble.SetActive(true);
        if (textBubble.transform.position.y < 5.0f) {
            textBubble.transform.position += new Vector3(0.0f, 0.02f, 0.0f);
        } else {
            textBubble.transform.Rotate(0.0f, 0.1f, 0.0f); 
        }
    }

    
    void OnTriggerEnter(Collider other) {
        // gib folgende Zeile für alle Kollisionen aus
       Debug.Log(this.name + " has an OnTriggerEnter with " + other.gameObject.name);
       
        //if trigger of owned painting was entered
        if (other.gameObject.name.Contains("owned")) {
            nearPainting = true;

            //random number decides if there is a good or bad review (0 == bad, 1 == good)
            goodOrBad = (int)UnityEngine.Random.Range(0f, 2f);

            if (goodOrBad == 1)
            {
                scoreMaster.raiseScore(this.gameObject);
            }
            else {
                scoreMaster.lowerScore(this.gameObject);
            }
        }
    }


}
