using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: Vertices einzeln machen für jedes gedrehte Triangle

public class JH_propScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject benchLegs = new GameObject("benchLegs", typeof(MeshFilter), typeof(MeshRenderer));
        benchLegs = createBench(benchLegs);
        //CombineMesh(benchLegs);
    }

    public GameObject createBench(GameObject benchMaster) {
        Mesh benchMesh = new Mesh();
        GameObject benchLegOne = new GameObject("benchLegOne", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer benchRend = benchLegOne.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));
        benchMesh = benchLegOne.GetComponent<MeshFilter>().mesh;

        benchMesh.Clear();

        List<Vector3> benchVertices = new List<Vector3>();
        List<int> benchTriangles = new List<int>();
        List<Vector2> benchUv = new List<Vector2>();



        //bein1 1
        benchVertices.Add(new Vector3(0.25f, 0, 0.5f));
        benchVertices.Add(new Vector3(0.25f, 0, 0));
        benchVertices.Add(new Vector3(0.25f, 1, 0));
        benchVertices.Add(new Vector3(0.25f, 1, 0.5f));

        //bein1 2
        benchVertices.Add(new Vector3(-0.25f, 0, 0.5f));
        //benchVertices.Add(new Vector3(0, 0, 0.5f));
        //benchVertices.Add(new Vector3(0, 0.5f, 0.5f));
        benchVertices.Add(new Vector3(-0.25f, 1f, 0.5f));

        //bein1 3
        benchVertices.Add(new Vector3(-0.25f, 0, 0));
        benchVertices.Add(new Vector3(-0.25f, 1f, 0));

        benchMesh.vertices = benchVertices.ToArray();

        //bein1 1
        benchTriangles.Add(0);
        benchTriangles.Add(1);
        benchTriangles.Add(2);
        benchTriangles.Add(0);
        benchTriangles.Add(2);
        benchTriangles.Add(3);

        //bein1 2
        benchTriangles.Add(4);
        benchTriangles.Add(0);
        benchTriangles.Add(3);
        benchTriangles.Add(4);
        benchTriangles.Add(3);
        benchTriangles.Add(5);

        //bein1 3
        benchTriangles.Add(6);
        benchTriangles.Add(4);
        benchTriangles.Add(5);
        benchTriangles.Add(6);
        benchTriangles.Add(5);
        benchTriangles.Add(7);

        //bein1 4
        benchTriangles.Add(1);
        benchTriangles.Add(6);
        benchTriangles.Add(7);
        benchTriangles.Add(1);
        benchTriangles.Add(7);
        benchTriangles.Add(2);

        benchMesh.triangles = benchTriangles.ToArray();


        GameObject benchLegTwo = Instantiate(benchLegOne);
        GameObject benchLegThree = Instantiate(benchLegOne);
        GameObject benchLegFour = Instantiate(benchLegOne);

        benchLegTwo.name = "benchLegTwo";
        benchLegThree.name = "benchLegThree";
        benchLegFour.name = "benchLegFour";

        benchLegOne.transform.Translate(6f, 0, 1);
        benchLegTwo.transform.Translate(-6f, 0, 1);
        benchLegThree.transform.Translate(6f, 0, -1.5f);
        benchLegFour.transform.Translate(-6f, 0, -1.5f);

        benchLegOne.transform.parent = benchMaster.transform;
        benchLegTwo.transform.parent = benchMaster.transform;
        benchLegThree.transform.parent = benchMaster.transform;
        benchLegFour.transform.parent = benchMaster.transform;

        CombineMesh(benchMaster);
        

        //Sitzbank
        GameObject benchSeat = new GameObject("benchSeat", typeof(MeshFilter), typeof(MeshRenderer));

        benchRend = benchSeat.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));
        benchMesh = benchSeat.GetComponent<MeshFilter>().mesh;

        benchMesh.Clear();
        benchVertices.Clear();
        benchTriangles.Clear();
        benchUv.Clear();

        //sitzbank 1
        benchVertices.Add(new Vector3(-7f, 1f, 2f));
        benchVertices.Add(new Vector3(7f, 1f, 2f));
        benchVertices.Add(new Vector3(7f, 1.5f, 2f));
        benchVertices.Add(new Vector3(-7f, 1.5f, 2f));

        //sitzbank 2
        benchVertices.Add(new Vector3(7f, 1f, -2f));
        benchVertices.Add(new Vector3(7f, 1.5f, -2f));

        //sitzbank 3
        benchVertices.Add(new Vector3(-7f, 1f, -2f));
        benchVertices.Add(new Vector3(-7f, 1.5f, -2f));

        benchMesh.vertices = benchVertices.ToArray();

        //sitzbank 1
        benchTriangles.Add(0);
        benchTriangles.Add(1);
        benchTriangles.Add(2);
        benchTriangles.Add(0);
        benchTriangles.Add(2);
        benchTriangles.Add(3);

        //sitzbank 2
        benchTriangles.Add(1);
        benchTriangles.Add(4);
        benchTriangles.Add(5);
        benchTriangles.Add(1);
        benchTriangles.Add(5);
        benchTriangles.Add(2);

        //sitzbank 3
        benchTriangles.Add(4);
        benchTriangles.Add(6);
        benchTriangles.Add(7);
        benchTriangles.Add(4);
        benchTriangles.Add(7);
        benchTriangles.Add(5);

        //sitzbank 4
        benchTriangles.Add(6);
        benchTriangles.Add(0);
        benchTriangles.Add(3);
        benchTriangles.Add(6);
        benchTriangles.Add(3);
        benchTriangles.Add(7);

        //sitzbank oben
        benchTriangles.Add(3);
        benchTriangles.Add(2);
        benchTriangles.Add(5);
        benchTriangles.Add(3);
        benchTriangles.Add(5);
        benchTriangles.Add(7);


        benchMesh.triangles = benchTriangles.ToArray();

        return benchMaster;
    }

    public void CombineMesh(GameObject obj) {

        MeshFilter[] meshFilters = obj.GetComponentsInChildren<MeshFilter>();
        
        
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        
        int i = 0;

        while (i < meshFilters.Length) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }
        
        obj.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        obj.transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        obj.transform.gameObject.SetActive(true);

        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
