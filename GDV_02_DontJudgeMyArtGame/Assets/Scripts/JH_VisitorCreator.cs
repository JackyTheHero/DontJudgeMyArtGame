using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        visitorCount = 1;
        standardVisitor = Instantiate(GameObject.Find("visitorFigure"));
        
        standardVisitor.name = "visitor2";
        
        ++visitorCount;
        standardVisitor.transform.position = new Vector3(14, 0, 0);
        standardVisitor.AddComponent<JH_visitorBehaviour>();

        visitorLimit = 10;

        StartCoroutine(VisitorCoroutine());
    }

    IEnumerator VisitorCoroutine()
    {
        //create new visitors in an interval of 20-30 seconds
        yield return new WaitForSeconds(UnityEngine.Random.Range(20,30));
        GameObject visitor = Instantiate(standardVisitor);
        visitor.transform.position = new Vector3(14, 0, 0);
        ++visitorCount;
        visitor.name = "visitor " + visitorCount;

        //destroy first speechbubble of visitor since a new one will be spawned via script
        Destroy(visitor.transform.GetChild(visitor.transform.childCount - 1).gameObject);

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
