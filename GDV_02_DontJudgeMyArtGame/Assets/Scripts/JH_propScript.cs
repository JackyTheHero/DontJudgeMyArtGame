using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: Vertices einzeln machen für jedes gedrehte Triangle

public class JH_propScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Standard Bench
        GameObject bench = new GameObject("bench", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer benchRend = bench.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));
        Texture texture = Resources.Load("holz") as Texture;
        benchRend.material.mainTexture = texture;
        bench = createBench(bench);

        MeshCollider doorCollider = bench.AddComponent<MeshCollider>();

        //Bench Parent
        GameObject benchParent = new GameObject("benchParent");

        //Bench placing
        placingBenches(bench, benchParent);

        bench.transform.Translate(-20,30,20);

        GameObject statue = new GameObject("statue", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer statueRend = statue.GetComponent<Renderer>();
        benchRend.material = new Material(Shader.Find("Standard"));
        Texture statueTexture = Resources.Load("TexturePurple") as Texture;
        statueRend.material.mainTexture = texture;
        statue = createStatue(statue);

        MeshCollider statueCollider = statue.AddComponent<MeshCollider>();


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

    public void placingBenches(GameObject bench, GameObject parent) {

        GameObject benchOne = Instantiate(bench);
        benchOne.name = "benchOne";
        benchOne.transform.Translate(17.5f, 0f, -28f);
        benchOne.transform.Rotate(new Vector3(0,90,0));

        GameObject benchTwo = Instantiate(bench);
        benchTwo.name = "benchTwo";
        benchTwo.transform.Translate(16.5f, 0f, 26f);
        benchTwo.transform.Rotate(new Vector3(0,90,0));

        GameObject benchThree = Instantiate(bench);
        benchThree.name = "benchThree";
        benchThree.transform.Translate(83f, 0f, 11.5f);

        GameObject benchFour = Instantiate(bench);
        benchFour.name = "benchFour";
        benchFour.transform.Translate(155f, 0f, 11.5f);

        GameObject benchFive = Instantiate(bench);
        benchFive.name = "benchFive";
        benchFive.transform.Translate(158f, 0f, -43.5f);

        GameObject benchSix = Instantiate(bench);
        benchSix.name = "benchSix";
        benchSix.transform.Translate(88f, 0f, -85.5f);

        GameObject benchSeven = Instantiate(bench);
        benchSeven.name = "benchSeven";
        benchSeven.transform.Translate(158f, 0f, -19f);

        GameObject benchEight = Instantiate(bench);
        benchEight.name = "benchEight";
        benchEight.transform.Translate(158f, 0f, -13f);

        GameObject benchNine = Instantiate(bench);
        benchNine.name = "benchNine";
        benchNine.transform.Translate(30f, 0f, -75f);
        benchNine.transform.Rotate(new Vector3(0, 90, 0));

        GameObject benchTen = Instantiate(bench);
        benchTen.name = "benchTen";
        benchTen.transform.Translate(36f, 0f, -75f);
        benchTen.transform.Rotate(new Vector3(0, 90, 0));

        GameObject benchEleven = Instantiate(bench);
        benchEleven.name = "benchEleven";
        benchEleven.transform.Translate(131f, 0f, 11.5f);

        benchOne.transform.parent = parent.transform;
        benchTwo.transform.parent = parent.transform;
        benchThree.transform.parent = parent.transform;
        benchFour.transform.parent = parent.transform;
        benchFive.transform.parent = parent.transform;
        benchSix.transform.parent = parent.transform;
        benchSeven.transform.parent = parent.transform;
        benchEight.transform.parent = parent.transform;
        benchNine.transform.parent = parent.transform;
        benchTen.transform.parent = parent.transform;
        benchEleven.transform.parent = parent.transform;
    }

    public GameObject createStatue(GameObject statueMaster) {
        Mesh statueMesh = new Mesh();
        GameObject foundation = new GameObject("foundation", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer foundationRend = foundation.GetComponent<Renderer>();
        foundationRend.material = new Material(Shader.Find("Standard"));

        statueMesh = foundation.GetComponent<MeshFilter>().mesh;

        statueMesh.Clear();

        List<Vector3> statueVertices = new List<Vector3>();
        List<int> statueTriangles = new List<int>();
        List<Vector2> statueUv = new List<Vector2>();

        //foundation 1
        statueVertices.Add(new Vector3(-7, 0, 7));
        statueVertices.Add(new Vector3(7, 0, 7));
        statueVertices.Add(new Vector3(7, 2, 7));
        statueVertices.Add(new Vector3(-7, 2, 7));

        //foundation 2
        statueVertices.Add(new Vector3(7, 0, 7));
        statueVertices.Add(new Vector3(7, 0, -7));
        statueVertices.Add(new Vector3(7, 2, -7));
        statueVertices.Add(new Vector3(7, 2, 7));

        //foundation 3
        statueVertices.Add(new Vector3(7, 0, -7));
        statueVertices.Add(new Vector3(-7, 0, -7));
        statueVertices.Add(new Vector3(-7, 2, -7));
        statueVertices.Add(new Vector3(7, 2, -7));

        //foundation 4
        statueVertices.Add(new Vector3(-7, 0, -7));
        statueVertices.Add(new Vector3(-7, 0, 7));
        statueVertices.Add(new Vector3(-7, 2, 7));
        statueVertices.Add(new Vector3(-7, 2, -7));

        //foundation 5
        statueVertices.Add(new Vector3(-7, 2, 7));
        statueVertices.Add(new Vector3(7, 2, 7));
        statueVertices.Add(new Vector3(7, 2, -7));
        statueVertices.Add(new Vector3(-7, 2, -7));


        statueMesh.vertices = statueVertices.ToArray();

        //foundation 1
        statueTriangles.Add(0);
        statueTriangles.Add(1);
        statueTriangles.Add(2);
        statueTriangles.Add(0);
        statueTriangles.Add(2);
        statueTriangles.Add(3);

        //foundation 2
        statueTriangles.Add(4);
        statueTriangles.Add(5);
        statueTriangles.Add(6);
        statueTriangles.Add(4);
        statueTriangles.Add(6);
        statueTriangles.Add(7);

        //foundation 3
        statueTriangles.Add(8);
        statueTriangles.Add(9);
        statueTriangles.Add(10);
        statueTriangles.Add(8);
        statueTriangles.Add(10);
        statueTriangles.Add(11);

        //foundation 4
        statueTriangles.Add(12);
        statueTriangles.Add(13);
        statueTriangles.Add(14);
        statueTriangles.Add(12);
        statueTriangles.Add(14);
        statueTriangles.Add(15);

        //foundation 5
        statueTriangles.Add(16);
        statueTriangles.Add(17);
        statueTriangles.Add(18);
        statueTriangles.Add(16);
        statueTriangles.Add(18);
        statueTriangles.Add(19);

        statueMesh.triangles = statueTriangles.ToArray();

        //foundation 1
        statueUv.Add(new Vector2(0, 0));
        statueUv.Add(new Vector2(1, 0));
        statueUv.Add(new Vector2(1, 1));
        statueUv.Add(new Vector2(0, 1));

        //foundation 2
        statueUv.Add(new Vector2(0, 0));
        statueUv.Add(new Vector2(1, 0));
        statueUv.Add(new Vector2(1, 1));
        statueUv.Add(new Vector2(0, 1));

        //foundation 3
        statueUv.Add(new Vector2(0, 0));
        statueUv.Add(new Vector2(1, 0));
        statueUv.Add(new Vector2(1, 1));
        statueUv.Add(new Vector2(0, 1));

        //foundation 4
        statueUv.Add(new Vector2(0, 0));
        statueUv.Add(new Vector2(1, 0));
        statueUv.Add(new Vector2(1, 1));
        statueUv.Add(new Vector2(0, 1));

        //foundation 5
        statueUv.Add(new Vector2(0, 0));
        statueUv.Add(new Vector2(1, 0));
        statueUv.Add(new Vector2(1, 1));
        statueUv.Add(new Vector2(0, 1));

        statueMesh.uv = statueUv.ToArray();

        statueMesh.RecalculateNormals();

        foundation.transform.parent = statueMaster.transform;

        return statueMaster;
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
