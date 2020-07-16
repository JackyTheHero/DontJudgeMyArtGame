using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_propScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        benchVertices.Add(new Vector3(0, 0, 0.5f));
        benchVertices.Add(new Vector3(0, 0, 0));
        benchVertices.Add(new Vector3(0, 1, 0));
        benchVertices.Add(new Vector3(0, 1, 0.5f));

        //bein1 2
        benchVertices.Add(new Vector3(-0.5f, 0, 0.5f));
        //benchVertices.Add(new Vector3(0, 0, 0.5f));
        //benchVertices.Add(new Vector3(0, 0.5f, 0.5f));
        benchVertices.Add(new Vector3(-0.5f, 1f, 0.5f));

        //bein1 3
        benchVertices.Add(new Vector3(-0.5f, 0, 0));
        benchVertices.Add(new Vector3(-0.5f, 1f, 0));

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

        
        benchLegOne.transform.Translate(1.5f, 0, 1);
        benchLegTwo.transform.Translate(-1.5f, 0, 1);
        benchLegThree.transform.Translate(1.5f, 0, -0.5f);
        benchLegFour.transform.Translate(-1.5f, 0, -0.5f);
        //benchUv.Add(new);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
