using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_VisitorCreator : MonoBehaviour
{
    GameObject standardVisitor;
    static int visitorCount;

    // Start is called before the first frame update
    void Start()
    {
        //add JH_scoreMaster to game after the start rather than adding it in the UI (since no ownedPaintings are made yet)
        this.gameObject.AddComponent<JH_scoreMaster>();

        visitorCount = 1;
        standardVisitor = Instantiate(GameObject.Find("visitorFigure"));
        standardVisitor.name = "visitor 2";
        ++visitorCount;
        standardVisitor.transform.position = new Vector3(14,0,-9);
        StartCoroutine(VisitorCoroutine());
    }

    IEnumerator VisitorCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(10,20));
        GameObject visitor = Instantiate(standardVisitor);
        ++visitorCount;
        visitor.name = "visitor " + visitorCount;
        visitor.transform.position = new Vector3(14f, 0f, 0);

        if (visitorCount != 10)
        {
            StartCoroutine(VisitorCoroutine());
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void test() { }
}
