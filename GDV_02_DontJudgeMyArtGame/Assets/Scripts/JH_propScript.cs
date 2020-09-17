using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


//TODO: Vertices einzeln machen für jedes gedrehte Triangle

public class JH_propScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //createAllBenches();
        //createAllStatues();
    }

    public static void createAllBenches()
    {
        //Standard bench
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

        bench.transform.Translate(-20, 30, 20);
        Destroy(bench);
    }

    public static void createAllStatues() {
        //Standard statue
        GameObject statue = new GameObject("statue", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer statueRend = statue.GetComponent<Renderer>();
        statueRend.material = new Material(Shader.Find("Standard"));
        Texture statueTexture = Resources.Load("marbleTexture") as Texture;
        statueRend.material.mainTexture = statueTexture;
        statue = createStatue(statue);

        MeshCollider statueCollider = statue.AddComponent<MeshCollider>();

        //statue parent
        GameObject statueParent = new GameObject("statueParent");

        //statue placing
        placingStatues(statue, statueParent);

        statue.transform.Translate(-20, 30, 20);
        Destroy(statue);
    }


    public static GameObject createBench(GameObject benchMaster) {
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

    public static void placingBenches(GameObject bench, GameObject parent) {

        GameObject benchOne = Instantiate(bench);
        benchOne.name = "benchOne";
        benchOne.transform.Translate(17.5f, 0f, -28f);
        benchOne.transform.Rotate(new Vector3(0,90,0));

        GameObject benchTwo = Instantiate(bench);
        benchTwo.name = "benchTwo";
        benchTwo.transform.Translate(17.5f, 0f, 26f);
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

    public static GameObject createStatue(GameObject statueMaster) {
        Mesh statueMesh = new Mesh();
        GameObject foundation = new GameObject("foundation", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer statueRend = foundation.GetComponent<Renderer>();
        statueRend.material = new Material(Shader.Find("Standard"));

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

        for (int i = 0; i < statueMesh.vertices.Length; i = i + 4)
        {
            statueTriangles.Add(i);
            statueTriangles.Add(i + 1);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i + 3);
        }

        statueMesh.triangles = statueTriangles.ToArray();

        for (int j = 0; j < statueMesh.vertices.Length; j = j + 4)
        {
            statueUv.Add(new Vector2(0, 0));
            statueUv.Add(new Vector2(1, 0));
            statueUv.Add(new Vector2(1, 1));
            statueUv.Add(new Vector2(0, 1));
        }

        statueMesh.uv = statueUv.ToArray();

        statueMesh.RecalculateNormals();

        foundation.transform.parent = statueMaster.transform;

        CombineMesh(statueMaster);

        //statue pole
        
        GameObject statuePole = new GameObject("statuePole", typeof(MeshFilter), typeof(MeshRenderer));

        statueRend = statuePole.GetComponent<Renderer>();
        statueRend.material = new Material(Shader.Find("Standard"));
        //statueRend.material.mainTexture = texture;
        statueMesh = statuePole.GetComponent<MeshFilter>().mesh;

        statueMesh.Clear();
        statueVertices.Clear();
        statueTriangles.Clear();
        statueUv.Clear();

        //statuePole1
        statueVertices.Add(new Vector3(-2f, 2, 2f));
        statueVertices.Add(new Vector3(2f, 2, 2f));
        statueVertices.Add(new Vector3(2f, 7, 2f));
        statueVertices.Add(new Vector3(-2f, 7, 2f));

        //statuePole2
        statueVertices.Add(new Vector3(2,2,2));
        statueVertices.Add(new Vector3(2,2,-2));
        statueVertices.Add(new Vector3(2,7,-2));
        statueVertices.Add(new Vector3(2,7,2));

        //statuePole3
        statueVertices.Add(new Vector3(2,2,-2));
        statueVertices.Add(new Vector3(-2,2,-2));
        statueVertices.Add(new Vector3(-2,7,-2));
        statueVertices.Add(new Vector3(2,7,-2));

        //statuePole4
        statueVertices.Add(new Vector3(-2,2,-2));
        statueVertices.Add(new Vector3(-2,2,2));
        statueVertices.Add(new Vector3(-2,7,2));
        statueVertices.Add(new Vector3(-2,7,-2));

        statueMesh.vertices = statueVertices.ToArray();

        for (int i = 0; i < statueMesh.vertices.Length; i = i + 4)
        {
            statueTriangles.Add(i);
            statueTriangles.Add(i + 1);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i + 3);
        }

        statueMesh.triangles = statueTriangles.ToArray();

        for (int j = 0; j < statueMesh.vertices.Length; j = j + 4)
        {
            statueUv.Add(new Vector2(0, 0));
            statueUv.Add(new Vector2(1, 0));
            statueUv.Add(new Vector2(1, 1));
            statueUv.Add(new Vector2(0, 1));
        }

        statueMesh.uv = statueUv.ToArray();

        statueMesh.RecalculateNormals();

        statuePole.transform.parent = statueMaster.transform;

        CombineMesh(statueMaster);

        //sphere
        //import settings for fbx sphere had to have read/write enabled for the mesh, else no interaction with it would have been possible
        GameObject sphereFBX = Resources.Load<GameObject>("lowPolySphereBig");
        GameObject lowPolySphere = new GameObject("lowPolySphere", typeof(MeshFilter), typeof(MeshRenderer));
        lowPolySphere.GetComponent<MeshFilter>().mesh = sphereFBX.GetComponent<MeshFilter>().sharedMesh;

        //trees on sphere
        GameObject allTrees = new GameObject();
        GameObject tree = new GameObject();

        GameObject treeTrunk = new GameObject("treeTrunk", typeof(MeshFilter), typeof(MeshRenderer));

        statueRend = treeTrunk.GetComponent<Renderer>();
        statueRend.material = new Material(Shader.Find("Standard"));
        statueMesh = treeTrunk.GetComponent<MeshFilter>().mesh;

        statueMesh.Clear();
        statueVertices.Clear();
        statueTriangles.Clear();
        statueUv.Clear();

        //treeTrunk 1
        statueVertices.Add(new Vector3(-1f, 0, 1f));
        statueVertices.Add(new Vector3(1f, 0, 1f));
        statueVertices.Add(new Vector3(1f, 4, 1f));
        statueVertices.Add(new Vector3(-1f, 4, 1f));

        //treeTrunk 2
        statueVertices.Add(new Vector3(1, 0, 1));
        statueVertices.Add(new Vector3(1, 0, -1));
        statueVertices.Add(new Vector3(1, 4, -1));
        statueVertices.Add(new Vector3(1, 4, 1));

        //treeTrunk 3
        statueVertices.Add(new Vector3(1, 0, -1));
        statueVertices.Add(new Vector3(-1, 0, -1));
        statueVertices.Add(new Vector3(-1, 4, -1));
        statueVertices.Add(new Vector3(1, 4, -1));

        //treeTrunk 4
        statueVertices.Add(new Vector3(-1, 0, -1));
        statueVertices.Add(new Vector3(-1, 0, 1));
        statueVertices.Add(new Vector3(-1, 4, 1));
        statueVertices.Add(new Vector3(-1, 4, -1));

        //treeTrunk 5
        statueVertices.Add(new Vector3(-1, 4, 1));
        statueVertices.Add(new Vector3(1, 4, 1));
        statueVertices.Add(new Vector3(1, 4, -1));
        statueVertices.Add(new Vector3(-1, 4, -1));

        statueMesh.vertices = statueVertices.ToArray();

        for (int i = 0; i < statueMesh.vertices.Length; i = i + 4)
        {
            statueTriangles.Add(i);
            statueTriangles.Add(i + 1);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i);
            statueTriangles.Add(i + 2);
            statueTriangles.Add(i + 3);
        }

        statueMesh.triangles = statueTriangles.ToArray();

        for (int j = 0; j < statueMesh.vertices.Length; j = j + 4)
        {
            statueUv.Add(new Vector2(0, 0));
            statueUv.Add(new Vector2(1, 0));
            statueUv.Add(new Vector2(1, 1));
            statueUv.Add(new Vector2(0, 1));
        }

        statueMesh.uv = statueUv.ToArray();

        statueMesh.RecalculateNormals();

        treeTrunk.transform.parent = tree.transform;

        //tree branches

        GameObject treeBranchOne = Instantiate(treeTrunk);
        treeBranchOne.transform.Translate(0, 4, 0);
        treeBranchOne.transform.Rotate(60, 0, 0);
        treeBranchOne.transform.parent = tree.transform;


        GameObject treeBranchTwo = Instantiate(treeTrunk);
        treeBranchTwo.transform.Translate(0, 4, 0);
        treeBranchTwo.transform.Rotate(60, 120, 0);
        treeBranchTwo.transform.parent = tree.transform;

        GameObject treeBranchThree = Instantiate(treeTrunk);
        treeBranchThree.transform.Translate(0, 4, 0);
        treeBranchThree.transform.Rotate(60, 240, 0);
        treeBranchThree.transform.parent = tree.transform;

        tree.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        //array for all placed trees because it's easier than searching for children of gameobject
        GameObject[] treeArray = new GameObject[lowPolySphere.GetComponent<MeshFilter>().mesh.vertices.Length];

        //placing a tree on every vertex of the lowPolySphere
        for (int i = 0; i < lowPolySphere.GetComponent<MeshFilter>().mesh.vertices.Length; i++)
        {
            Vector3 treePos = lowPolySphere.GetComponent<MeshFilter>().mesh.vertices[i];

            GameObject placedTree = new GameObject();
            treeArray[i] = placedTree;
            placedTree = Instantiate(tree);

            placedTree.transform.Translate(treePos);
            placedTree.transform.rotation = Quaternion.FromToRotation(Vector3.up, treePos);
            //Debug.Log(Vector3.Angle(Vector3.forward, treePos));
            placedTree.transform.parent = allTrees.transform;

        }

        allTrees.transform.parent = lowPolySphere.transform;

        //final changes to the lowPolySphere after adding everything to it
        lowPolySphere.transform.parent = statueMaster.transform;
        //to check the readable flag for the mesh: lowPolySphere.GetComponent<MeshFilter>().mesh.isReadable;
        lowPolySphere.transform.position = new Vector3(0,12,0);
        lowPolySphere.transform.Rotate(90, 0, 0);

        CombineMesh(statueMaster);

        //destroying every gameobject that was copied into the new mesh
        Destroy(foundation);
        Destroy(statuePole);
        Destroy(lowPolySphere);
        Destroy(allTrees);
        for (int i = 0; i < treeArray.Length; i++)
        {
            Destroy(treeArray[i]);
        }
        Destroy(tree);
        //not able to destroy sphereFBX because it's imported
            //DestroyImmediate(sphereFBX, true);

        return statueMaster;

        //for-loops for adding triangles and uv --> usable for every rectangle shape if order of vertices is: lowLeft, lowRight, highRight, highLeft
        /*
       for (int i = 0; i < statueMesh.vertices.Length; i = i + 4)
        {
            statueTriangles.Add(i);
            statueTriangles.Add(i+1);
            statueTriangles.Add(i+2);
            statueTriangles.Add(i);
            statueTriangles.Add(i+2);
            statueTriangles.Add(i+3);
        }

        statueMesh.triangles = statueTriangles.ToArray();

        for (int j = 0; j < statueMesh.vertices.Length; j = j + 4)
        {
            statueUv.Add(new Vector2(0, 0));
            statueUv.Add(new Vector2(1, 0));
            statueUv.Add(new Vector2(1, 1));
            statueUv.Add(new Vector2(0, 1));
        } 

        statueMesh.uv = statueUv.ToArray();
         */

        
    }

    public static void placingStatues(GameObject statue, GameObject parent) {
        GameObject statueOne = Instantiate(statue);
        statueOne.name = "statueOne";
        statueOne.transform.parent = parent.transform;
        statueOne.transform.Translate(88,0,-75);

        GameObject statueTwo = Instantiate(statue);
        statueTwo.name = "statueTwo";
        statueTwo.transform.parent = parent.transform;
        statueTwo.transform.Translate(168, 0, 49);
    }

    public static void CombineMesh(GameObject obj) {

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


/*
       //statue virus; tried to make an icosphere but forgot some faces >> used fbx of a low poly sphere instead


       //10 triangles for the belt
       GameObject statueVirus = new GameObject("statuePole", typeof(MeshFilter), typeof(MeshRenderer));

       statueRend = statueVirus.GetComponent<Renderer>();
       statueRend.material = new Material(Shader.Find("Standard"));
       //statueRend.material.mainTexture = texture;
       statueMesh = statueVirus.GetComponent<MeshFilter>().mesh;

       statueMesh.Clear();
       statueVertices.Clear();
       statueTriangles.Clear();
       statueUv.Clear();

       //statueVirusBelt1 1 6x6
       statueVertices.Add(new Vector3(-3f, 12, 3f));
       statueVertices.Add(new Vector3(0f, 7, 4f));
       statueVertices.Add(new Vector3(3f, 12, 3f));

       //statueVirusBelt1 2
       statueVertices.Add(new Vector3(3,12,3));
       statueVertices.Add(new Vector3(4, 7, 0));
       statueVertices.Add(new Vector3(3,12,-3));

       //statueVirusBelt1 3
       statueVertices.Add(new Vector3(3,12,-3));
       statueVertices.Add(new Vector3(0,7,-4));
       statueVertices.Add(new Vector3(-3f, 12, -3f));

       //statueVirusBelt1 4
       statueVertices.Add(new Vector3(-3, 12, -3));
       statueVertices.Add(new Vector3(-4, 7, 0));
       statueVertices.Add(new Vector3(-3, 12, 3));

       //statueVirusBelt2 1
       statueVertices.Add(new Vector3(3f, 12, 3f)); //1 3
       statueVertices.Add(new Vector3(0f, 7, 4f)); //1 2
       statueVertices.Add(new Vector3(4, 7, 0)); //2 2

       //statueVirusBelt2 2
       statueVertices.Add(new Vector3(3, 12, -3));
       statueVertices.Add(new Vector3(4, 7, 0));
       statueVertices.Add(new Vector3(0, 7, -4));

       //statueVirusBelt2 3
       statueVertices.Add(new Vector3(-3f, 12, -3f));
       statueVertices.Add(new Vector3(0, 7, -4));
       statueVertices.Add(new Vector3(-4, 7, 0));

       //statueVirusBelt2 4
       statueVertices.Add(new Vector3(-3, 12, 3));
       statueVertices.Add(new Vector3(-4, 7, 0));
       statueVertices.Add(new Vector3(0f, 7, 4f));

       //statueVirusUp1 1
       statueVertices.Add(new Vector3(0,15,0));
       statueVertices.Add(new Vector3(-3,12,3));
       statueVertices.Add(new Vector3(3,12,3));

       //statueVirusUp1 2
       statueVertices.Add(new Vector3(0, 15, 0));
       statueVertices.Add(new Vector3(3,12,3));
       statueVertices.Add(new Vector3(3,12,-3));

       //statueVirusUp1 3
       statueVertices.Add(new Vector3(0,15,0));
       statueVertices.Add(new Vector3(3, 12, -3));
       statueVertices.Add(new Vector3(-3f, 12, -3f));

       //statueVirusUp1 4
       statueVertices.Add(new Vector3(0, 15, 0));
       statueVertices.Add(new Vector3(-3, 12, -3));
       statueVertices.Add(new Vector3(-3, 12, 3));

       //statueVirusDown2 1 || von 2: 2 unten 3
       statueVertices.Add(new Vector3(0f, 7, 4f));
       statueVertices.Add(new Vector3(0,4,0));
       statueVertices.Add(new Vector3(4, 7, 0));

       //statueVirusDown2 2
       statueVertices.Add(new Vector3(4, 7, 0));
       statueVertices.Add(new Vector3(0, 4, 0));
       statueVertices.Add(new Vector3(0, 7, -4));

       //statueVirusDown2 3
       statueVertices.Add(new Vector3(0, 7, -4));
       statueVertices.Add(new Vector3(0, 4, 0));
       statueVertices.Add(new Vector3(-4, 7, 0));

       //statueVirusDown2 4
       statueVertices.Add(new Vector3(-4, 7, 0));
       statueVertices.Add(new Vector3(0, 4, 0));
       statueVertices.Add(new Vector3(0f, 7, 4f));

       statueMesh.vertices = statueVertices.ToArray();

       for(int i = 0; i < statueMesh.vertices.Length; i++) {
           statueTriangles.Add(i);
       }

       /*
       //statueVirusMain1 6x6
       statueTriangles.Add(0);
       statueTriangles.Add(1);
       statueTriangles.Add(2);

       //statueVirusMain2
       statueTriangles.Add(3);
       statueTriangles.Add(4);
       statueTriangles.Add(5);

       //statueVirusMain3
       statueTriangles.Add(6);
       statueTriangles.Add(7);
       statueTriangles.Add(8);

       //statueVirusMain4
       statueTriangles.Add(9);
       statueTriangles.Add(10);
       statueTriangles.Add(11);


       statueMesh.triangles = statueTriangles.ToArray();

       for (int j = 0; j < statueMesh.vertices.Length; j = j + 3) {
           statueUv.Add(new Vector2(0, 0));
           statueUv.Add(new Vector2(1, 0));
           statueUv.Add(new Vector2(1, 1));
       }

       /*
       //statueVirus1 UV
       statueUv.Add(new Vector2(0, 0));
       statueUv.Add(new Vector2(1, 0));
       statueUv.Add(new Vector2(1, 1));

       //statueVirus2 UV
       statueUv.Add(new Vector2(0, 0));
       statueUv.Add(new Vector2(1, 0));
       statueUv.Add(new Vector2(1, 1));

       //statueVirus3 UV
       statueUv.Add(new Vector2(0, 0));
       statueUv.Add(new Vector2(1, 0));
       statueUv.Add(new Vector2(1, 1));

       //statueVirus4 UV
       statueUv.Add(new Vector2(0, 0));
       statueUv.Add(new Vector2(1, 0));
       statueUv.Add(new Vector2(1, 1));

       statueMesh.uv = statueUv.ToArray();

       statueMesh.RecalculateNormals();

       statueVirus.transform.parent = statueMaster.transform;

       CombineMesh(statueMaster);
       */
