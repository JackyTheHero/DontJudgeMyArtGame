using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: Vertices einzeln machen für jedes gedrehte Triangle

public class JH_propScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject bench = new GameObject("bench", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer benchRend = bench.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));
        Texture texture = Resources.Load("TextureGreen") as Texture;
        benchRend.material.mainTexture = texture;
        bench = createBench(bench);
    }

    public GameObject createBench(GameObject benchMaster) {
        Mesh benchMesh = new Mesh();
        GameObject benchLegOne = new GameObject("benchLegOne", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer benchRend = benchLegOne.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));

        Texture texture = Resources.Load("TextureGreen") as Texture;
        benchRend.material.mainTexture = texture;

        benchMesh = benchLegOne.GetComponent<MeshFilter>().mesh;

        benchMesh.Clear();

        List<Vector3> benchVertices = new List<Vector3>();
        List<int> benchTriangles = new List<int>();
        List<Vector2> benchUv = new List<Vector2>();
        
        //bein1 1
        benchVertices.Add(new Vector3(0.25f, 0, 0.5f)); // 0
        benchVertices.Add(new Vector3(0.25f, 0, 0)); // 1
        benchVertices.Add(new Vector3(0.25f, 1, 0)); // 2
        benchVertices.Add(new Vector3(0.25f, 1, 0.5f)); // 3
        
        //bein1 2
        benchVertices.Add(new Vector3(-0.25f, 0, 0.5f)); // 4
        benchVertices.Add(new Vector3(0.25f, 0, 0.5f)); // new5
        benchVertices.Add(new Vector3(0.25f, 1, 0.5f));  //new6
        benchVertices.Add(new Vector3(-0.25f, 1f, 0.5f)); // 5 , new7

        //bein1 3
        benchVertices.Add(new Vector3(-0.25f, 0, 0)); // 6 , new8
        benchVertices.Add(new Vector3(-0.25f, 0, 0.5f)); // new9
        benchVertices.Add(new Vector3(-0.25f, 1f, 0.5f)); // new10
        benchVertices.Add(new Vector3(-0.25f, 1f, 0)); // 7 new11

        //bein1 4
        benchVertices.Add(new Vector3(0.25f, 0, 0)); //1 new12
        benchVertices.Add(new Vector3(-0.25f, 0, 0)); //6 new13
        benchVertices.Add(new Vector3(-0.25f, 1f, 0)); //7 new14
        benchVertices.Add(new Vector3(0.25f, 1, 0)); //2 new15

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
        benchTriangles.Add(5);
        benchTriangles.Add(6);
        benchTriangles.Add(4);
        benchTriangles.Add(6);
        benchTriangles.Add(7);

        //bein1 3
        benchTriangles.Add(8);
        benchTriangles.Add(9);
        benchTriangles.Add(10);
        benchTriangles.Add(8);
        benchTriangles.Add(10);
        benchTriangles.Add(11);

        //bein1 4
        benchTriangles.Add(12);
        benchTriangles.Add(13);
        benchTriangles.Add(14);
        benchTriangles.Add(12);
        benchTriangles.Add(14);
        benchTriangles.Add(15);
        
        benchMesh.triangles = benchTriangles.ToArray();

        // bein1 1
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // bein1 2
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // bein1 3
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // bein1 4
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        benchMesh.uv = benchUv.ToArray();

        benchMesh.RecalculateNormals();


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
        benchRend.material.mainTexture = texture;
        benchMesh = benchSeat.GetComponent<MeshFilter>().mesh;

        benchMesh.Clear();
        benchVertices.Clear();
        benchTriangles.Clear();
        benchUv.Clear();

        //sitzbank 1
        benchVertices.Add(new Vector3(-7f, 1f, 2f)); //0
        benchVertices.Add(new Vector3(7f, 1f, 2f)); //1
        benchVertices.Add(new Vector3(7f, 1.5f, 2f)); //2
        benchVertices.Add(new Vector3(-7f, 1.5f, 2f)); //3

        //sitzbank 2
        benchVertices.Add(new Vector3(7f, 1f, 2f)); //1 //new4
        benchVertices.Add(new Vector3(7f, 1f, -2f)); //4 //new5
        benchVertices.Add(new Vector3(7f, 1.5f, -2f)); //5 new6
        benchVertices.Add(new Vector3(7f, 1.5f, 2f)); //2 new7

        //sitzbank 3
        benchVertices.Add(new Vector3(7f, 1f, -2f)); //4 new8
        benchVertices.Add(new Vector3(-7f, 1f, -2f)); //6 new9
        benchVertices.Add(new Vector3(-7f, 1.5f, -2f)); //7 new10
        benchVertices.Add(new Vector3(7f, 1.5f, -2f)); //5 new11

        //sitzbank 4
        benchVertices.Add(new Vector3(-7f, 1f, -2f)); //6 new12
        benchVertices.Add(new Vector3(-7f, 1f, 2f)); //0 new13
        benchVertices.Add(new Vector3(-7f, 1.5f, 2f)); //3 new14
        benchVertices.Add(new Vector3(-7f, 1.5f, -2f)); //7 new15

        //sitzbank oben
        benchVertices.Add(new Vector3(-7f, 1.5f, 2f)); //3 new16
        benchVertices.Add(new Vector3(7f, 1.5f, 2f)); //2 new17
        benchVertices.Add(new Vector3(7f, 1.5f, -2f)); //5 new18
        benchVertices.Add(new Vector3(-7f, 1.5f, -2f)); //7 new19

        benchMesh.vertices = benchVertices.ToArray();

        //sitzbank 1
        benchTriangles.Add(0);
        benchTriangles.Add(1);
        benchTriangles.Add(2);
        benchTriangles.Add(0);
        benchTriangles.Add(2);
        benchTriangles.Add(3);

        //sitzbank 2
        benchTriangles.Add(4);
        benchTriangles.Add(5);
        benchTriangles.Add(6);
        benchTriangles.Add(4);
        benchTriangles.Add(6);
        benchTriangles.Add(7);

        //sitzbank 3
        benchTriangles.Add(8);
        benchTriangles.Add(9);
        benchTriangles.Add(10);
        benchTriangles.Add(8);
        benchTriangles.Add(10);
        benchTriangles.Add(11);

        //sitzbank 4
        benchTriangles.Add(12);
        benchTriangles.Add(13);
        benchTriangles.Add(14);
        benchTriangles.Add(12);
        benchTriangles.Add(14);
        benchTriangles.Add(15);

        //sitzbank oben
        benchTriangles.Add(16);
        benchTriangles.Add(17);
        benchTriangles.Add(18);
        benchTriangles.Add(16);
        benchTriangles.Add(18);
        benchTriangles.Add(19);

        benchMesh.triangles = benchTriangles.ToArray();

        // sitzbank 1
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // sitzbank 2
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // sitzbank 3
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        // sitzbank 4
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        //sitzbank oben
        benchUv.Add(new Vector2(0, 0));
        benchUv.Add(new Vector2(1, 0));
        benchUv.Add(new Vector2(1, 1));
        benchUv.Add(new Vector2(0, 1));

        benchMesh.uv = benchUv.ToArray();

        benchMesh.RecalculateNormals();

        benchSeat.transform.parent = benchMaster.transform;
        
        CombineMesh(benchMaster);

        Destroy(benchLegOne);
        Destroy(benchLegTwo);
        Destroy(benchLegThree);
        Destroy(benchLegFour);
        Destroy(benchSeat);
        

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
