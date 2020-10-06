using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JH_VisitorCreator : MonoBehaviour
{
    GameObject standardVisitor;
    static int visitorCount;
    private int visitorLimit;

    // Start is called before the first frame update
    void Start()
    {
        //add JH_scoreMaster to game after the start rather than adding it in the UI (since no ownedPaintings are made yet)
        this.gameObject.AddComponent<JH_scoreMaster>();

        visitorCount = 0;
        visitorLimit = 10;

        StartCoroutine(VisitorCoroutine());
    }

    IEnumerator VisitorCoroutine()
    {
        //create new visitors in an interval of 20-30 seconds
        yield return new WaitForSeconds(UnityEngine.Random.Range(20,30));
        GameObject visitor = Instantiate(GameObject.Find("visitorFigure"));
        visitor.transform.position = new Vector3(-7, 0, 0);
        visitor.transform.rotation = new Quaternion(0, 0, 0, 0);
        ++visitorCount;
        visitor.name = "visitor " + visitorCount;

        //NavMeshAgent has to be disabled for visitorFigure so that visitors don't spawn directly beside it
        visitor.GetComponent<NavMeshAgent>().enabled = true;

        visitor.AddComponent<JH_visitorBehaviour>();

        //routine only continues if visitorLimit is not yet reached
        if (visitorCount <= visitorLimit)
        {
            StartCoroutine(VisitorCoroutine());
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (visitorCount > visitorLimit)
        {
            StopCoroutine(VisitorCoroutine());
        }
    }

    public void test() { }
}
