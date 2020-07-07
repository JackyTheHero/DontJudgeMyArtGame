using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelanieScript : MonoBehaviour
{
    // variable for height and thickness of walls, so they can be dynamically changed
    float height = 12.0f;
    float wallThickness = 2.0f;
    // how high is the doorway in relation to the wall height? -> height / doorwayFactor
    float doorwayFactor = 2.0f;
    // how wide and long is the doorway
    float doorwayThickness = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateGround();
        CreateRooms();
        CreateDoorways();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateGround() {
        Mesh meshGround = new Mesh();
        GameObject ground = new GameObject("Ground", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer rend = ground.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        Texture texture = Resources.Load("TextureLight") as Texture;
        rend.material.mainTexture = texture;

        meshGround = ground.GetComponent<MeshFilter>().mesh;
        meshGround.Clear();

        List<Vector3> groundVertices = new List<Vector3>();
        List<int> groundTriangles = new List<int>();
        List<Vector3> groundNormals = new List<Vector3>();
        List<Vector2> groundUvs = new List<Vector2>();

        // Raum 1 -> grüner Raum
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 0));
        groundVertices.Add(new Vector3(42, 0, 0));
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 50));
        groundVertices.Add(new Vector3(42, 0, 50));
        // Raum 2 -> lila Raum
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 50 - wallThickness));
        groundVertices.Add(new Vector3(60 + wallThickness, 0, 50 - wallThickness));
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 130 + wallThickness));
        groundVertices.Add(new Vector3(60 + wallThickness, 0, 130 + wallThickness));
        // Raum 3 -> blauer Raum
        groundVertices.Add(new Vector3(42, 0, 0));
        groundVertices.Add(new Vector3(110 + wallThickness, 0, 0));
        groundVertices.Add(new Vector3(42, 0, 50));
        groundVertices.Add(new Vector3(110 + wallThickness, 0, 50));
        // Raum 4 -> dunkelblauer Raum
        groundVertices.Add(new Vector3(-70, 0, 0));
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 0));
        groundVertices.Add(new Vector3(-70, 0, 80));
        groundVertices.Add(new Vector3(-10 - wallThickness, 0, 80));
        // Raum 5 -> dunkelgrüner Raum
        groundVertices.Add(new Vector3(42 + wallThickness, 0, -70 - wallThickness));
        groundVertices.Add(new Vector3(-30 - wallThickness, 0, 0));
        groundVertices.Add(new Vector3(-30 - wallThickness, 0, -70 - wallThickness));
        groundVertices.Add(new Vector3(42 + wallThickness, 0, 0));
        // Raum 6 -> lila Raum
        groundVertices.Add(new Vector3(-30, 0, -70 - wallThickness));
        groundVertices.Add(new Vector3(-70, 0, 0));
        groundVertices.Add(new Vector3(-30, 0, 0));
        groundVertices.Add(new Vector3(-70, 0, -70 - wallThickness));
        // Raum 7 -> grüner Raum
        groundVertices.Add(new Vector3(-12, 0, 78 + wallThickness));
        groundVertices.Add(new Vector3(-70, 0, 78 + wallThickness));
        groundVertices.Add(new Vector3(-12, 0, 130 + wallThickness));
        groundVertices.Add(new Vector3(-70, 0, 130 + wallThickness));

        meshGround.vertices = groundVertices.ToArray();

        // Raum 1 -> 0 bis 3
        groundTriangles.Add(1);
        groundTriangles.Add(0);
        groundTriangles.Add(2);
        groundTriangles.Add(3);
        groundTriangles.Add(1);
        groundTriangles.Add(2);
        // Raum 2 -> 4 bis 7
        groundTriangles.Add(5);
        groundTriangles.Add(4);
        groundTriangles.Add(6);
        groundTriangles.Add(7);
        groundTriangles.Add(5);
        groundTriangles.Add(6);
        // Raum 3 -> 8 bis 11
        groundTriangles.Add(9);
        groundTriangles.Add(8);
        groundTriangles.Add(10);
        groundTriangles.Add(11);
        groundTriangles.Add(9);
        groundTriangles.Add(10);
        // Raum 4 -> 12 bis 15
        groundTriangles.Add(13);
        groundTriangles.Add(12);
        groundTriangles.Add(14);
        groundTriangles.Add(15);
        groundTriangles.Add(13);
        groundTriangles.Add(14);
        // Raum 5 -> 16 bis 19
        groundTriangles.Add(17);
        groundTriangles.Add(16);
        groundTriangles.Add(18);
        groundTriangles.Add(19);
        groundTriangles.Add(16);
        groundTriangles.Add(17);
        // Raum 6 -> 20 bis 23
        groundTriangles.Add(20);
        groundTriangles.Add(21);
        groundTriangles.Add(22);
        groundTriangles.Add(20);
        groundTriangles.Add(23);
        groundTriangles.Add(21);
        // Raum 7 -> 24 bis 27
        groundTriangles.Add(24);
        groundTriangles.Add(25);
        groundTriangles.Add(26);
        groundTriangles.Add(27);
        groundTriangles.Add(26);
        groundTriangles.Add(25);

        meshGround.triangles = groundTriangles.ToArray();

        // Material wird erst durch UV-Koordinaten sichtbar
        // Raum 1
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 2
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 3
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 4
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 5
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 6
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));
        // Raum 7
        groundUvs.Add(new Vector2(0, 1));
        groundUvs.Add(new Vector2(0, 0));
        groundUvs.Add(new Vector2(1, 1));
        groundUvs.Add(new Vector2(1, 0));

        meshGround.uv = groundUvs.ToArray();

        // wird zusätzlich benötigt, damit Material sichtbar wird
        //meshGround.normals = new Vector3[] {new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0)};
        meshGround.RecalculateNormals(); // berechnet Normalen automatisch

        // MeshCollider erst hinzufügen, nachdem Mesh kreiert wurde, ansonsten macht der Collider gar nichts, da kein Mesh zugewiesen wird
        MeshCollider groundCollider = ground.AddComponent<MeshCollider>();
        meshGround = groundCollider.sharedMesh;
    }

    private void CreateRooms() {
        // Room 1
        Mesh meshRoom1 = new Mesh();
        GameObject room1 = new GameObject("Room 1", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend1 = room1.GetComponent<Renderer>();
        rend1.material = new Material(Shader.Find("Specular"));
        meshRoom1 = room1.GetComponent<MeshFilter>().mesh;
        Texture texture1 = Resources.Load("TextureGreen") as Texture;
        rend1.material.mainTexture = texture1;

        meshRoom1.Clear();

        List<Vector3> room1Vertices = new List<Vector3>();
        List<int> room1Triangles = new List<int>();
        List<Vector3> room1Normals = new List<Vector3>();
        List<Vector2> room1Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu dunkelgrüner Wand
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(42, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(42, height, wallThickness));
        room1Vertices.Add(new Vector3(-12, height, wallThickness));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(-12, 0, wallThickness));
        room1Vertices.Add(new Vector3(5, 0, wallThickness));
        room1Vertices.Add(new Vector3(5, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor, wallThickness));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(5 + doorwayThickness, 0, wallThickness));
        room1Vertices.Add(new Vector3(42, 0, wallThickness));
        room1Vertices.Add(new Vector3(42  , height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor, wallThickness));
        // Wand über Türrahmen -> Eingang zu dunkelblauer Wand
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 0 + wallThickness));
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 20));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 20));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 20 + doorwayThickness));
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 20 + doorwayThickness));
        // Wand über Türrahmen -> Eingang zu lila Wand
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor, 50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height / doorwayFactor, 50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height, 50 - wallThickness));
        room1Vertices.Add(new Vector3(-12, height, 50 - wallThickness));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(-12, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(22, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(22, height / doorwayFactor,  50 - wallThickness));
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor,  50 - wallThickness));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(22 + doorwayThickness, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(42, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height / doorwayFactor,  50 - wallThickness));
        room1Vertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor,  50 - wallThickness));
        // Wand über Türrahmen -> Eingang zu blauer Wand
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 0));
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height, 0));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 0));
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 20));
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 20));
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 20 + doorwayThickness));
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 20 + doorwayThickness));                     
        /*// Decke
        room1Vertices.Add(new Vector3(-12, height, 0));
        room1Vertices.Add(new Vector3(42, height, 0));
        room1Vertices.Add(new Vector3(-12, height, 50));
        room1Vertices.Add(new Vector3(42, height, 50));*/

        // int countVertices = roomVertices.Count;

        meshRoom1.vertices = room1Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room1Triangles.Add(0);
        room1Triangles.Add(1);
        room1Triangles.Add(2);
        room1Triangles.Add(0);
        room1Triangles.Add(2);
        room1Triangles.Add(3);
        // Wand unter Türrahmen -> rechts -> 4 bis 7
        room1Triangles.Add(6);
        room1Triangles.Add(4);
        room1Triangles.Add(5);
        room1Triangles.Add(4);
        room1Triangles.Add(6);
        room1Triangles.Add(7);
        // Wand unter Türrahmen -> links -> 8 bis 11
        room1Triangles.Add(10);
        room1Triangles.Add(8);
        room1Triangles.Add(9);
        room1Triangles.Add(8);
        room1Triangles.Add(10);
        room1Triangles.Add(11);
        // Wand über Türrahmen -> 12 bis 15
        room1Triangles.Add(12);
        room1Triangles.Add(14);
        room1Triangles.Add(13);
        room1Triangles.Add(12);
        room1Triangles.Add(15);
        room1Triangles.Add(14);
        // Wand unter Türrahmen -> rechts -> 16 bis 19
        room1Triangles.Add(16);
        room1Triangles.Add(18);
        room1Triangles.Add(17);
        room1Triangles.Add(16);
        room1Triangles.Add(19);
        room1Triangles.Add(18);
        // Wand unter Türrahmen -> links -> 20 bis 23
        room1Triangles.Add(20);
        room1Triangles.Add(22);
        room1Triangles.Add(21);
        room1Triangles.Add(20);
        room1Triangles.Add(23);
        room1Triangles.Add(22);
        // Wand über Türrahmen -> 24 bis 27
        room1Triangles.Add(25);
        room1Triangles.Add(24);
        room1Triangles.Add(26);
        room1Triangles.Add(24);
        room1Triangles.Add(27);
        room1Triangles.Add(26);
        // Wand unter Türrahmen -> links -> 28 bis 31
        room1Triangles.Add(30);
        room1Triangles.Add(29);
        room1Triangles.Add(28);
        room1Triangles.Add(28);
        room1Triangles.Add(31);
        room1Triangles.Add(30);
        // Wand unter Türrahmen -> rechts -> 32 bis 35
        room1Triangles.Add(34);
        room1Triangles.Add(33);
        room1Triangles.Add(32);
        room1Triangles.Add(32);
        room1Triangles.Add(35);
        room1Triangles.Add(34);
        // Wand über Türrahmen -> 36 bis 39
        room1Triangles.Add(36);
        room1Triangles.Add(37);
        room1Triangles.Add(38);
        room1Triangles.Add(36);
        room1Triangles.Add(38);
        room1Triangles.Add(39);
        // Wand unter Türrahmen -> rechts -> 40 bis 43
        room1Triangles.Add(40);
        room1Triangles.Add(41);
        room1Triangles.Add(42);
        room1Triangles.Add(40);
        room1Triangles.Add(42);
        room1Triangles.Add(43);
        // Wand unter Türrahmen -> links -> 44 bis 47
        room1Triangles.Add(44);
        room1Triangles.Add(45);
        room1Triangles.Add(46);
        room1Triangles.Add(44);
        room1Triangles.Add(46);
        room1Triangles.Add(47);        
        /*// Decke -> 48 bis 51
        room1Triangles.Add(48);
        room1Triangles.Add(49);
        room1Triangles.Add(50);
        room1Triangles.Add(48);
        room1Triangles.Add(50);
        room1Triangles.Add(51);*/

        meshRoom1.triangles = room1Triangles.ToArray();

        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1)); 
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(0.5f, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 0.5f));
        room1Uvs.Add(new Vector2(0.5f, 0.5f));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(0.5f, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 0.5f));
        room1Uvs.Add(new Vector2(0.5f, 0.5f)); 
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        //Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        /*// Decke
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(1, 1));
        room1Uvs.Add(new Vector2(1, 0));*/
        
        meshRoom1.uv = room1Uvs.ToArray();

        // berechnet Normalen automatisch
        meshRoom1.RecalculateNormals();

        //meshRoom.normals = roomNormals.ToArray();

        MeshCollider room1Collider = room1.AddComponent<MeshCollider>();
        Rigidbody room1Body = room1.AddComponent<Rigidbody>();
        room1Body.isKinematic = true;
        meshRoom1 = room1Collider.sharedMesh;

        // Room 2
        Mesh meshRoom2 = new Mesh();
        GameObject room2 = new GameObject("Room 2", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend2 = room2.GetComponent<Renderer>();
        rend2.material = new Material(Shader.Find("Specular"));
        meshRoom2 = room2.GetComponent<MeshFilter>().mesh;
        Texture texture2 = Resources.Load("TexturePurple") as Texture;
        rend2.material.mainTexture = texture2;

        meshRoom2.Clear();

        List<Vector3> room2Vertices = new List<Vector3>();
        List<int> room2Triangles = new List<int>();
        List<Vector3> room2Normals = new List<Vector3>();
        List<Vector2> room2Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room2Vertices.Add(new Vector3(-12, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height, 50));
        room2Vertices.Add(new Vector3(-12, height, 50));
        // Wand unter Türrahmen -> rechts
        room2Vertices.Add(new Vector3(-12, 0, 50));
        room2Vertices.Add(new Vector3(22, 0, 50));
        room2Vertices.Add(new Vector3(22, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(-12, height / doorwayFactor, 50));
        // Wand unter Türrahmen -> links
        room2Vertices.Add(new Vector3(22 + doorwayThickness, 0,  50));
        room2Vertices.Add(new Vector3(60, 0,  50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor,  50));
        room2Vertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor,  50));
        // Vorderseite
        room2Vertices.Add(new Vector3(60, 0, 50));
        room2Vertices.Add(new Vector3(60, 0, 130));
        room2Vertices.Add(new Vector3(60, height, 50));
        room2Vertices.Add(new Vector3(60, height, 130));
        // Vorderseite
        room2Vertices.Add(new Vector3(60, 0, 130));
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 130));
        room2Vertices.Add(new Vector3(60, height, 130));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height, 130));
        // Wand über Türrahmen
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 130));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height, 130));
        // Wand unter Türrahmen -> links
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 100));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100));
        // Wand unter Türrahmen -> rechts
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 100 + doorwayThickness));
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 130));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100 + doorwayThickness));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 130)); 

        meshRoom2.vertices = room2Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room2Triangles.Add(0);
        room2Triangles.Add(1);
        room2Triangles.Add(2);
        room2Triangles.Add(0);
        room2Triangles.Add(2);
        room2Triangles.Add(3);
        // Wand unter Türrahmen -> rechts -> 4 bis 7
        room2Triangles.Add(4);
        room2Triangles.Add(5);
        room2Triangles.Add(6);
        room2Triangles.Add(4);
        room2Triangles.Add(6);
        room2Triangles.Add(7);
        // Wand uner Türrahmen -> links -> 8 bis 11
        room2Triangles.Add(8);
        room2Triangles.Add(9);
        room2Triangles.Add(10);
        room2Triangles.Add(8);
        room2Triangles.Add(10);
        room2Triangles.Add(11);
        // Vorderseite -> 12 bis 15
        room2Triangles.Add(12);
        room2Triangles.Add(13);
        room2Triangles.Add(14);
        room2Triangles.Add(13);
        room2Triangles.Add(15);
        room2Triangles.Add(14);
        // Vorderseite -> 16 bis 19
        room2Triangles.Add(18);
        room2Triangles.Add(17);
        room2Triangles.Add(19);
        room2Triangles.Add(16);
        room2Triangles.Add(17);
        room2Triangles.Add(18);
        // Wand über Türrahmen -> 20 bis 23
        room2Triangles.Add(21);
        room2Triangles.Add(20);
        room2Triangles.Add(22);
        room2Triangles.Add(21);
        room2Triangles.Add(22);
        room2Triangles.Add(23);
        // Wand unter Türrahmen -> links -> 24 bis 27
        room2Triangles.Add(25);
        room2Triangles.Add(24);
        room2Triangles.Add(26);
        room2Triangles.Add(25);
        room2Triangles.Add(26);
        room2Triangles.Add(27);
        // Wand unter Türrahmen -> rechts -> 28 bis 31
        room2Triangles.Add(29);
        room2Triangles.Add(28);
        room2Triangles.Add(30);
        room2Triangles.Add(29);
        room2Triangles.Add(30);
        room2Triangles.Add(31);

        meshRoom2.triangles = room2Triangles.ToArray();

        // Wand über Türrahmen
        room2Uvs.Add(new Vector2(1, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 1));
        room2Uvs.Add(new Vector2(1, 0.5f));
        // Wand unter Türrahmen -> rechts
        room2Uvs.Add(new Vector2(0.5f, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 0.5f));
        // Wand unter Türrahmen -> links
        room2Uvs.Add(new Vector2(0.5f, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 0.5f));
        // Vorderseite
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room2Uvs.Add(new Vector2(0.5f, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 0.5f));
        // Wand unter Türrahmen -> rechts
        room2Uvs.Add(new Vector2(0.5f, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, 0.5f));
        room2Uvs.Add(new Vector2(0.5f, 0.5f));

        meshRoom2.uv = room2Uvs.ToArray();

        meshRoom2.RecalculateNormals();

        MeshCollider room2Collider = room2.AddComponent<MeshCollider>();
        Rigidbody room2Body = room2.AddComponent<Rigidbody>();
        room2Body.isKinematic = true;
        meshRoom2 = room2Collider.sharedMesh;

        // Room 3
        Mesh meshRoom3 = new Mesh();
        GameObject room3 = new GameObject("Room 3", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend3 = room3.GetComponent<Renderer>();
        rend3.material = new Material(Shader.Find("Specular"));
        meshRoom3 = room3.GetComponent<MeshFilter>().mesh;
        Texture texture3 = Resources.Load("TextureBlue") as Texture;
        rend3.material.mainTexture = texture3;

        meshRoom3.Clear();

        List<Vector3> room3Vertices = new List<Vector3>();
        List<int> room3Triangles = new List<int>();
        List<Vector3> room3Normals = new List<Vector3>();
        List<Vector2> room3Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu grünem Raum
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 50));
        room3Vertices.Add(new Vector3(42, height, 50));
        room3Vertices.Add(new Vector3(42, height, 0));
        // Wand unter Türrahmen -> links
        room3Vertices.Add(new Vector3(42, 0, 0));
        room3Vertices.Add(new Vector3(42, 0, 20));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 20));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> rechts
        room3Vertices.Add(new Vector3(42, 0, 20 + doorwayThickness));
        room3Vertices.Add(new Vector3(42, 0, 50));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 50));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 20 + doorwayThickness));
        // Vorderseite
        room3Vertices.Add(new Vector3(42, 0, 50 - wallThickness));
        room3Vertices.Add(new Vector3(110, 0, 50 - wallThickness));
        room3Vertices.Add(new Vector3(42, height, 50 - wallThickness));
        room3Vertices.Add(new Vector3(110, height, 50 - wallThickness));
        // Vorderseite
        room3Vertices.Add(new Vector3(42, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(42, height, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110, height, 0 + wallThickness));
        // Vorderseite
        room3Vertices.Add(new Vector3(110, 0, 0));
        room3Vertices.Add(new Vector3(110, 0, 50));
        room3Vertices.Add(new Vector3(110, height, 50));
        room3Vertices.Add(new Vector3(110, height, 0));

        meshRoom3.vertices = room3Vertices.ToArray();        

        // Wand über Türrahmen -> 0 bis 3
        room3Triangles.Add(0);
        room3Triangles.Add(2);
        room3Triangles.Add(1);
        room3Triangles.Add(2);
        room3Triangles.Add(0);
        room3Triangles.Add(3);
        // Wand unter Türramen -> links -> 4 bis 7
        room3Triangles.Add(4);
        room3Triangles.Add(6);
        room3Triangles.Add(5);
        room3Triangles.Add(6);
        room3Triangles.Add(4);
        room3Triangles.Add(7);
        // Wand unter Türrahmen -> rechts -> 8 bis 11
        room3Triangles.Add(8);
        room3Triangles.Add(10);
        room3Triangles.Add(9);
        room3Triangles.Add(10);
        room3Triangles.Add(8);
        room3Triangles.Add(11);
        // Vorderseite -> 12 bis 15
        room3Triangles.Add(12);
        room3Triangles.Add(14);
        room3Triangles.Add(13);
        room3Triangles.Add(13);
        room3Triangles.Add(14);
        room3Triangles.Add(15);
        // Vorderseite -> 16 bis 19
        room3Triangles.Add(16);
        room3Triangles.Add(17);
        room3Triangles.Add(18);
        room3Triangles.Add(17);
        room3Triangles.Add(19);
        room3Triangles.Add(18);
        // Vorderseite -> 20 bis 23
        room3Triangles.Add(20);
        room3Triangles.Add(21);
        room3Triangles.Add(22);
        room3Triangles.Add(20);
        room3Triangles.Add(22);
        room3Triangles.Add(23);

        meshRoom3.triangles = room3Triangles.ToArray();

        // Wand über Türrahmen
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));

        meshRoom3.uv = room3Uvs.ToArray();

        meshRoom3.RecalculateNormals();

        MeshCollider room3Collider = room3.AddComponent<MeshCollider>();
        Rigidbody room3Body = room3.AddComponent<Rigidbody>();
        room3Body.isKinematic = true;
        meshRoom3 = room3Collider.sharedMesh;

        // Raum 4
        Mesh meshRoom4 = new Mesh();
        GameObject room4 = new GameObject("Room 4", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend4 = room4.GetComponent<Renderer>();
        rend4.material = new Material(Shader.Find("Specular"));
        meshRoom4 = room4.GetComponent<MeshFilter>().mesh;
        Texture texture4 = Resources.Load("TextureDarkBlue") as Texture;
        rend4.material.mainTexture = texture4;

        meshRoom4.Clear();

        List<Vector3> room4Vertices = new List<Vector3>();
        List<int> room4Triangles = new List<int>();
        List<Vector3> room4Normals = new List<Vector3>();
        List<Vector2> room4Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu grüner Wand
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room4Vertices.Add(new Vector3(-12, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, 0, 20));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 20));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room4Vertices.Add(new Vector3(-12, 0, 20 + doorwayThickness));
        room4Vertices.Add(new Vector3(-12, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 20 + doorwayThickness));  


        // Wand über Türrahmen
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height, 80 - wallThickness));
        // Wand über Türrahmen -> rechts
        room4Vertices.Add(new Vector3(-30 - doorwayThickness, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 80 - wallThickness));
        // Wand über Türrahmen -> links
        room4Vertices.Add(new Vector3(-12, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-30, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-30, height / doorwayFactor, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 80 - wallThickness));


        // Vorderseite
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 80 - wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 0 + wallThickness));
        // Wand über Türrahmen
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, height, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room4Vertices.Add(new Vector3(-12, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-50, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-50, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room4Vertices.Add(new Vector3(-50 - doorwayThickness, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0 + wallThickness));

        meshRoom4.vertices = room4Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room4Triangles.Add(0);
        room4Triangles.Add(1);
        room4Triangles.Add(2);
        room4Triangles.Add(0);
        room4Triangles.Add(2);
        room4Triangles.Add(3);
        // Wand unter Türrahmen -> rechts -> 4 bis 7
        room4Triangles.Add(4);
        room4Triangles.Add(5);
        room4Triangles.Add(6);
        room4Triangles.Add(4);
        room4Triangles.Add(6);
        room4Triangles.Add(7);
        // Wand unter Türrahmen -> links -> 8 bis 11
        room4Triangles.Add(8);
        room4Triangles.Add(9);
        room4Triangles.Add(10);
        room4Triangles.Add(8);
        room4Triangles.Add(10);
        room4Triangles.Add(11);  
        // Wand über Türrahmen -> 12 bis 15
        room4Triangles.Add(12);
        room4Triangles.Add(13);
        room4Triangles.Add(14);
        room4Triangles.Add(12);
        room4Triangles.Add(14);
        room4Triangles.Add(15);
        // Wand über Türrahmen -> rechts -> 16 bis 19
        room4Triangles.Add(16);
        room4Triangles.Add(17);
        room4Triangles.Add(18);
        room4Triangles.Add(16);
        room4Triangles.Add(18);
        room4Triangles.Add(19);
        // Wand über Türrahmen -> links -> 20 bis 23
        room4Triangles.Add(20);
        room4Triangles.Add(21);
        room4Triangles.Add(22);
        room4Triangles.Add(20);
        room4Triangles.Add(22);
        room4Triangles.Add(23);
        // Vorderseite -> 24 bis 27
        room4Triangles.Add(25);
        room4Triangles.Add(24);
        room4Triangles.Add(26);
        room4Triangles.Add(24);
        room4Triangles.Add(27);
        room4Triangles.Add(26);
        // Wand über Türrahmen -> 28 bis 31
        room4Triangles.Add(29);
        room4Triangles.Add(28);
        room4Triangles.Add(30);
        room4Triangles.Add(28);
        room4Triangles.Add(31);
        room4Triangles.Add(30);
        // Wand unter Türrahmen -> links -> 31 bis 35
        room4Triangles.Add(33);
        room4Triangles.Add(32);
        room4Triangles.Add(34);
        room4Triangles.Add(32);
        room4Triangles.Add(35);
        room4Triangles.Add(34);
        // Wand unter Türrahmen -> rechts -> 36 bis 39
        room4Triangles.Add(37);
        room4Triangles.Add(36);
        room4Triangles.Add(38);
        room4Triangles.Add(36);
        room4Triangles.Add(39);
        room4Triangles.Add(38);

        meshRoom4.triangles = room4Triangles.ToArray();

        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));

        meshRoom4.uv = room4Uvs.ToArray();

        meshRoom4.RecalculateNormals();

        MeshCollider room4Collider = room4.AddComponent<MeshCollider>();
        Rigidbody room4Body = room4.AddComponent<Rigidbody>();
        room4Body.isKinematic = true;
        meshRoom4 = room4Collider.sharedMesh;

        // Room 5
        Mesh meshRoom5 = new Mesh();
        GameObject room5 = new GameObject("Room 5", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend5 = room5.GetComponent<Renderer>();
        rend5.material = new Material(Shader.Find("Specular"));
        meshRoom5 = room5.GetComponent<MeshFilter>().mesh;
        Texture texture5 = Resources.Load("TextureDarkGreen") as Texture;
        rend5.material.mainTexture = texture5;

        meshRoom5.Clear();

        List<Vector3> room5Vertices = new List<Vector3>();
        List<int> room5Triangles = new List<int>();
        List<Vector3> room5Normals = new List<Vector3>();
        List<Vector2> room5Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room5Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(42, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(42, height, 0));
        room5Vertices.Add(new Vector3(-30, height, 0));
        // Wand unter Türrahmen -> links
        room5Vertices.Add(new Vector3(-30, 0, 0));
        room5Vertices.Add(new Vector3(5, 0, 0));
        room5Vertices.Add(new Vector3(5, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> rechts
        room5Vertices.Add(new Vector3(5 + doorwayThickness, 0, 0));
        room5Vertices.Add(new Vector3(42, 0, 0));
        room5Vertices.Add(new Vector3(42  , height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor, 0));
        // Wand über Türrahmen
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -70));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height, 0));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height, -70));
        // Wand unter Türrahmen -> links
        room5Vertices.Add(new Vector3(-30 + wallThickness, 0, -30 - doorwayThickness));
        room5Vertices.Add(new Vector3(-30 + wallThickness, 0, -70));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30 - doorwayThickness));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -70));
        // Wand unter Türrahmen -> rechts
        room5Vertices.Add(new Vector3(-30 + wallThickness, 0, 0));
        room5Vertices.Add(new Vector3(-30 + wallThickness, 0, -30));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30));
        // Vorderseite
        room5Vertices.Add(new Vector3(-30, 0, -70 + wallThickness));
        room5Vertices.Add(new Vector3(42, 0, -70 + wallThickness));
        room5Vertices.Add(new Vector3(42, height, -70 + wallThickness));
        room5Vertices.Add(new Vector3(-30, height, -70 + wallThickness));
        // Vorderseite
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, 0 + wallThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, -70 - wallThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, height, 0 + wallThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, height, -70 - wallThickness));

        meshRoom5.vertices = room5Vertices.ToArray();
        
        // Wand über Türrahmen -> 0 bis 3
        room5Triangles.Add(0);
        room5Triangles.Add(2);
        room5Triangles.Add(1);
        room5Triangles.Add(0);
        room5Triangles.Add(3);
        room5Triangles.Add(2);
        // Wand unter Türrahmen -> links -> 4 bis 7
        room5Triangles.Add(4);
        room5Triangles.Add(6);
        room5Triangles.Add(5);
        room5Triangles.Add(4);
        room5Triangles.Add(7);
        room5Triangles.Add(6);
        // Wand unter Türrahmen -> rechts -> 8 bis 11
        room5Triangles.Add(8);
        room5Triangles.Add(10);
        room5Triangles.Add(9);
        room5Triangles.Add(8);
        room5Triangles.Add(11);
        room5Triangles.Add(10);
        // Wand über Türrahmen -> 12 bis 15
        room5Triangles.Add(12);
        room5Triangles.Add(13);
        room5Triangles.Add(14);
        room5Triangles.Add(13);
        room5Triangles.Add(15);
        room5Triangles.Add(14);
        // Wand unter Türrahmen -> links -> 16 bis 19
        room5Triangles.Add(16);
        room5Triangles.Add(17);
        room5Triangles.Add(18);
        room5Triangles.Add(17);
        room5Triangles.Add(19);
        room5Triangles.Add(18);        
        // Wand unter Türrahmen -> rechts -> 20 bis 23
        room5Triangles.Add(20);
        room5Triangles.Add(21);
        room5Triangles.Add(22);
        room5Triangles.Add(21);
        room5Triangles.Add(23);
        room5Triangles.Add(22);
        // Vorderseite -> 24 bis 27
        room5Triangles.Add(24);
        room5Triangles.Add(25);
        room5Triangles.Add(26);
        room5Triangles.Add(24);
        room5Triangles.Add(26);
        room5Triangles.Add(27);
        // Vorderseite -> 28 bis 31
        room5Triangles.Add(29);
        room5Triangles.Add(28);
        room5Triangles.Add(30);
        room5Triangles.Add(29);
        room5Triangles.Add(30);
        room5Triangles.Add(31);

        meshRoom5.triangles = room5Triangles.ToArray();

        // Wand über Türrahmen
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));

        meshRoom5.uv = room5Uvs.ToArray();

        meshRoom5.RecalculateNormals();

        MeshCollider room5Collider = room5.AddComponent<MeshCollider>();
        Rigidbody room5Body = room5.AddComponent<Rigidbody>();
        room5Body.isKinematic = true;
        meshRoom5 = room5Collider.sharedMesh;

        // Room 6
        Mesh meshRoom6 = new Mesh();
        GameObject room6 = new GameObject("Room 6", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend6 = room6.GetComponent<Renderer>();
        rend6.material = new Material(Shader.Find("Specular"));
        meshRoom6 = room6.GetComponent<MeshFilter>().mesh;
        Texture texture6 = Resources.Load("TexturePurple") as Texture;
        rend6.material.mainTexture = texture6;

        meshRoom6.Clear();

        List<Vector3> room6Vertices = new List<Vector3>();
        List<int> room6Triangles = new List<int>();
        List<Vector3> room6Normals = new List<Vector3>();
        List<Vector2> room6Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        room6Vertices.Add(new Vector3(-70, height / doorwayFactor, 0));
        room6Vertices.Add(new Vector3(-70, height, 0));
        room6Vertices.Add(new Vector3(-30, height, 0));
        // Wand unter Türrahmen -> rechts
        room6Vertices.Add(new Vector3(-30, 0, 0));
        room6Vertices.Add(new Vector3(-50, 0, 0));
        room6Vertices.Add(new Vector3(-50, height / doorwayFactor, 0));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> links
        room6Vertices.Add(new Vector3(-50 - doorwayThickness, 0, 0));
        room6Vertices.Add(new Vector3(-70, 0, 0));
        room6Vertices.Add(new Vector3(-70, height / doorwayFactor, 0));
        room6Vertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0));
        // Wand über Türrahmen
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, -70 - wallThickness));
        room6Vertices.Add(new Vector3(-30, height, -70 - wallThickness));
        room6Vertices.Add(new Vector3(-30, height, 0));
        // Wand unter Türrahmen -> links
        room6Vertices.Add(new Vector3(-30, 0, 0));
        room6Vertices.Add(new Vector3(-30, 0, -30));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, -30));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> rechts
        room6Vertices.Add(new Vector3(-30, 0, -30 - doorwayThickness));
        room6Vertices.Add(new Vector3(-30, 0, -70 - wallThickness));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, -70 - wallThickness));
        room6Vertices.Add(new Vector3(-30, height / doorwayFactor, -30 - doorwayThickness));
        // Vorderseite
        room6Vertices.Add(new Vector3(-70 + wallThickness, 0, 0));
        room6Vertices.Add(new Vector3(-70 + wallThickness, 0, -70 - wallThickness));
        room6Vertices.Add(new Vector3(-70 + wallThickness, height, 0));
        room6Vertices.Add(new Vector3(-70 + wallThickness, height, -70 - wallThickness));
        // Vorderseite
        room6Vertices.Add(new Vector3(-30, 0, -70 + wallThickness));
        room6Vertices.Add(new Vector3(-70, 0, -70 + wallThickness));
        room6Vertices.Add(new Vector3(-70, height, -70 + wallThickness));
        room6Vertices.Add(new Vector3(-30, height, -70 + wallThickness));

        meshRoom6.vertices = room6Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room6Triangles.Add(0);
        room6Triangles.Add(1);
        room6Triangles.Add(2);
        room6Triangles.Add(0);
        room6Triangles.Add(2);
        room6Triangles.Add(3);
        // Wand unter Türrahmen -> rechts -> 4 bis 7
        room6Triangles.Add(4);
        room6Triangles.Add(5);
        room6Triangles.Add(6);
        room6Triangles.Add(4);
        room6Triangles.Add(6);
        room6Triangles.Add(7);
        // Wand unter Türrahmen -> rechts -> 8 bis 11
        room6Triangles.Add(8);
        room6Triangles.Add(9);
        room6Triangles.Add(10);
        room6Triangles.Add(8);
        room6Triangles.Add(10);
        room6Triangles.Add(11);
        // Wand über Türrahmen -> 12 bis 15
        room6Triangles.Add(13);
        room6Triangles.Add(12);
        room6Triangles.Add(14);
        room6Triangles.Add(12);
        room6Triangles.Add(15);
        room6Triangles.Add(14);
        // Wand über Türrahmen -> 16 bis 19
        room6Triangles.Add(17);
        room6Triangles.Add(16);
        room6Triangles.Add(18);
        room6Triangles.Add(16);
        room6Triangles.Add(19);
        room6Triangles.Add(18);
        // Wand über Türrahmen -> 20 bis 23
        room6Triangles.Add(21);
        room6Triangles.Add(20);
        room6Triangles.Add(22);
        room6Triangles.Add(20);
        room6Triangles.Add(23);
        room6Triangles.Add(22);
        // Vorderseite -> 24 bis 27
        room6Triangles.Add(24);
        room6Triangles.Add(25);
        room6Triangles.Add(26);
        room6Triangles.Add(26);
        room6Triangles.Add(25);
        room6Triangles.Add(27);
        // Vorderseite -> 28 bis 31
        room6Triangles.Add(29);
        room6Triangles.Add(28);
        room6Triangles.Add(31);
        room6Triangles.Add(30);
        room6Triangles.Add(29);
        room6Triangles.Add(31);

        meshRoom6.triangles = room6Triangles.ToArray();

        // Wand über Türrahmen
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));

        meshRoom6.uv = room6Uvs.ToArray();

        meshRoom6.RecalculateNormals();

        MeshCollider room6Collider = room6.AddComponent<MeshCollider>();
        Rigidbody room6Body = room6.AddComponent<Rigidbody>();
        room6Body.isKinematic = true;
        meshRoom6 = room6Collider.sharedMesh;

        // Room 7
        Mesh meshRoom7 = new Mesh();
        GameObject room7 = new GameObject("Room 7", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend7 = room7.GetComponent<Renderer>();
        rend7.material = new Material(Shader.Find("Specular"));
        meshRoom7 = room7.GetComponent<MeshFilter>().mesh;
        Texture texture7 = Resources.Load("TextureGreen") as Texture;
        rend7.material.mainTexture = texture7;

        meshRoom7.Clear();

        List<Vector3> room7Vertices = new List<Vector3>();
        List<int> room7Triangles = new List<int>();
        List<Vector3> room7Normals = new List<Vector3>();
        List<Vector2> room7Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang lila zu grün
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 130 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height, 130 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room7Vertices.Add(new Vector3(-12, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, 0, 100));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 100));
        // Wand unter Türrahmen -> links
        room7Vertices.Add(new Vector3(-12, 0, 100 + doorwayThickness));
        room7Vertices.Add(new Vector3(-12, 0, 130 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 100 + doorwayThickness));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 130 + wallThickness));
        // Wand über Türrahmen -> Eingang dunkelblau zu grün
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70, height, 78 + wallThickness));
        // Wand unter Türrahmen -> links
        room7Vertices.Add(new Vector3(-12, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-30, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-12, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-30, height / doorwayFactor, 78 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room7Vertices.Add(new Vector3(-30 - doorwayThickness, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70, height / doorwayFactor, 78 + wallThickness));
        // Vorderseite
        room7Vertices.Add(new Vector3(-12, 0, 130));
        room7Vertices.Add(new Vector3(-70, 0, 130));
        room7Vertices.Add(new Vector3(-12, height, 130));
        room7Vertices.Add(new Vector3(-70, height, 130));
        // Vorderseite
        room7Vertices.Add(new Vector3(-70 + wallThickness, 0, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70 + wallThickness, 0, 130));
        room7Vertices.Add(new Vector3(-70 + wallThickness, height, 78 + wallThickness));
        room7Vertices.Add(new Vector3(-70 + wallThickness, height, 130));

        meshRoom7.vertices = room7Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room7Triangles.Add(0);
        room7Triangles.Add(1);
        room7Triangles.Add(3);
        room7Triangles.Add(0);
        room7Triangles.Add(3);
        room7Triangles.Add(2);
        // Wand unter Türrahmen -> rechts -> 4 bis 7
        room7Triangles.Add(4);
        room7Triangles.Add(5);
        room7Triangles.Add(7);
        room7Triangles.Add(4);
        room7Triangles.Add(7);
        room7Triangles.Add(6);
        // Wand unter Türrahmen -> links -> 8 bis 11
        room7Triangles.Add(8);
        room7Triangles.Add(9);
        room7Triangles.Add(11);
        room7Triangles.Add(8);
        room7Triangles.Add(11);
        room7Triangles.Add(10);
        // Wand über Türrahmen -> 12 bis 15
        room7Triangles.Add(13);
        room7Triangles.Add(12);
        room7Triangles.Add(15);
        room7Triangles.Add(12);
        room7Triangles.Add(14);
        room7Triangles.Add(15);
        // Wand unter Türrahmen -> links -> 16 bis 19
        room7Triangles.Add(17);
        room7Triangles.Add(16);
        room7Triangles.Add(19);
        room7Triangles.Add(16);
        room7Triangles.Add(18);
        room7Triangles.Add(19);
        // Wand unter Türrahmen -> rechts -> 20 bis 23
        room7Triangles.Add(21);
        room7Triangles.Add(20);
        room7Triangles.Add(23);
        room7Triangles.Add(20);
        room7Triangles.Add(22);
        room7Triangles.Add(23);
        // Vorderseite -> 24 bis 27
        room7Triangles.Add(24);
        room7Triangles.Add(25);
        room7Triangles.Add(27);
        room7Triangles.Add(24);
        room7Triangles.Add(27);
        room7Triangles.Add(26);
        // Vorderseite -> 28 bis 31
        room7Triangles.Add(29);
        room7Triangles.Add(28);
        room7Triangles.Add(31);
        room7Triangles.Add(28);
        room7Triangles.Add(30);
        room7Triangles.Add(31);

        meshRoom7.triangles = room7Triangles.ToArray();

        // Wand über Türrahmen
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));

        meshRoom7.uv = room7Uvs.ToArray();

        meshRoom7.RecalculateNormals();

        MeshCollider room7Collider = room7.AddComponent<MeshCollider>();
        Rigidbody room7Body = room7.AddComponent<Rigidbody>();
        room7Body.isKinematic = true;
        meshRoom7 = room7Collider.sharedMesh;
    }

    private void CreateDoorways() {
        Mesh meshDoorway = new Mesh();
        GameObject doorway = new GameObject("Doorways", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend = doorway.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        meshDoorway = doorway.GetComponent<MeshFilter>().mesh;
        Texture texture = Resources.Load("TextureLight") as Texture;
        rend.material.mainTexture = texture;

        meshDoorway.Clear();

        List<Vector3> doorwayVertices = new List<Vector3>();
        List<int> doorwayTriangles = new List<int>();
        List<Vector3> doorwayNormals = new List<Vector3>();
        List<Vector2> doorwayUvs = new List<Vector2>();

        // Eingang grün zu lila
        // oben
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor, 50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / doorwayFactor, 50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / doorwayFactor, 50));
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor, 50));
        // links
        doorwayVertices.Add(new Vector3(22, 0,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / doorwayFactor,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, 0,  50));
        doorwayVertices.Add(new Vector3(22, height / doorwayFactor,  50));
        // rechts
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, 0,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, 0,  50));
        doorwayVertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor,  50));

        // Eingang grün zu blau
        // oben
        doorwayVertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(42, height / doorwayFactor, 20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(42, height / doorwayFactor, 20));
        doorwayVertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 20));
        // links
        doorwayVertices.Add(new Vector3(42 - wallThickness, 0,  20));
        doorwayVertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor,  20));
        doorwayVertices.Add(new Vector3(42, 0,  20));
        doorwayVertices.Add(new Vector3(42, height / doorwayFactor,  20));
        // rechts
        doorwayVertices.Add(new Vector3(42 - wallThickness, 0,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(42, 0,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(42, height / doorwayFactor,  20 + doorwayThickness));

        // Eingang grün zu dunkelblau
        // oben
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 20));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 20));
        // links
        doorwayVertices.Add(new Vector3(-12 + wallThickness, 0,  20));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor,  20));
        doorwayVertices.Add(new Vector3(-12, 0,  20));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor,  20));
        // rechts
        doorwayVertices.Add(new Vector3(-12 + wallThickness, 0,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, 0,  20 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor,  20 + doorwayThickness));

        // Eingang grün zu dunkelgrün
        // oben
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(5, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(5, height / doorwayFactor, 0));
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor, 0));
        // links
        doorwayVertices.Add(new Vector3(5, 0,  0 + wallThickness));
        doorwayVertices.Add(new Vector3(5, height / doorwayFactor,  0 + wallThickness));
        doorwayVertices.Add(new Vector3(5, 0,  0));
        doorwayVertices.Add(new Vector3(5, height / doorwayFactor,  0));
        // rechts
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, 0,  0 + wallThickness));
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor,  0 + wallThickness));
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, 0,  0));
        doorwayVertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor,  0));

        // Eingang dunkelblau zu lila
        // oben
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0));
        doorwayVertices.Add(new Vector3(-50, height / doorwayFactor, 0));
        // links
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, 0, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, 0, 0));
        doorwayVertices.Add(new Vector3(-50 - doorwayThickness, height / doorwayFactor, 0));
        // rechts
        doorwayVertices.Add(new Vector3(-50, 0, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50, height / doorwayFactor, 0 + wallThickness));
        doorwayVertices.Add(new Vector3(-50, 0, 0));
        doorwayVertices.Add(new Vector3(-50, height / doorwayFactor, 0));

        // Eingang dunkelgrün zu lila
        // oben
        doorwayVertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30 - doorwayThickness));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, -30 - doorwayThickness));
        doorwayVertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, -30));
        // links
        doorwayVertices.Add(new Vector3(-30 + wallThickness, 0, -30));
        doorwayVertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30));
        doorwayVertices.Add(new Vector3(-30, 0, -30));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, -30));
        // rechts
        doorwayVertices.Add(new Vector3(-30 + wallThickness, 0, -30 - doorwayThickness));
        doorwayVertices.Add(new Vector3(-30 + wallThickness, height / doorwayFactor, -30 - doorwayThickness));
        doorwayVertices.Add(new Vector3(-30, 0, -30 - doorwayThickness));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, -30 - doorwayThickness));

        // Eingang lila zu grün
        // oben
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 100 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 100));
        // links
        doorwayVertices.Add(new Vector3(-12 + wallThickness, 0, 100 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, 0, 100 + doorwayThickness));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 100 + doorwayThickness));
        // rechts
        doorwayVertices.Add(new Vector3(-12 + wallThickness, 0, 100));
        doorwayVertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 100));
        doorwayVertices.Add(new Vector3(-12, 0, 100));
        doorwayVertices.Add(new Vector3(-12, height / doorwayFactor, 100));

        // Eingang lila zu dunkelblau
        // oben
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, 78));
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78));
        // links
        doorwayVertices.Add(new Vector3(-30, 0, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30, 0, 78));
        doorwayVertices.Add(new Vector3(-30, height / doorwayFactor, 78));
        // rechts
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, 0, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78 + wallThickness));
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, 0, 78));
        doorwayVertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78));

        meshDoorway.vertices = doorwayVertices.ToArray();

        // Eingang grün zu lila
        // oben -> 0 bis 3
        doorwayTriangles.Add(0);
        doorwayTriangles.Add(2);
        doorwayTriangles.Add(1);
        doorwayTriangles.Add(0);
        doorwayTriangles.Add(3);
        doorwayTriangles.Add(2);
        // links -> 4 bis 7
        doorwayTriangles.Add(4);
        doorwayTriangles.Add(5);
        doorwayTriangles.Add(6);
        doorwayTriangles.Add(5);
        doorwayTriangles.Add(7);
        doorwayTriangles.Add(6);
        // rechts -> 8 bis 11
        doorwayTriangles.Add(9);
        doorwayTriangles.Add(8);
        doorwayTriangles.Add(10);
        doorwayTriangles.Add(9);
        doorwayTriangles.Add(10);
        doorwayTriangles.Add(11);

        // Eingang grün zu blau
        // oben -> 12 bis 15
        doorwayTriangles.Add(12);
        doorwayTriangles.Add(14);
        doorwayTriangles.Add(13);
        doorwayTriangles.Add(12);
        doorwayTriangles.Add(15);
        doorwayTriangles.Add(14);
        // links -> 16 bis 19
        doorwayTriangles.Add(17);
        doorwayTriangles.Add(16);
        doorwayTriangles.Add(18);
        doorwayTriangles.Add(17);
        doorwayTriangles.Add(18);
        doorwayTriangles.Add(19);
        // rechts -> 20 bis 23
        doorwayTriangles.Add(20);
        doorwayTriangles.Add(21);
        doorwayTriangles.Add(22);
        doorwayTriangles.Add(21);
        doorwayTriangles.Add(23);
        doorwayTriangles.Add(22);

        // Eingang grün zu dunkelblau
        // oben -> 24 bis 27
        doorwayTriangles.Add(26);
        doorwayTriangles.Add(24);
        doorwayTriangles.Add(25);
        doorwayTriangles.Add(24);
        doorwayTriangles.Add(26);
        doorwayTriangles.Add(27);
        // links -> 28 bis 31
        doorwayTriangles.Add(28);
        doorwayTriangles.Add(29);
        doorwayTriangles.Add(30);
        doorwayTriangles.Add(29);
        doorwayTriangles.Add(31);
        doorwayTriangles.Add(30);
        // rechts -> 32 bis 35
        doorwayTriangles.Add(33);
        doorwayTriangles.Add(32);
        doorwayTriangles.Add(34);
        doorwayTriangles.Add(33);
        doorwayTriangles.Add(34);
        doorwayTriangles.Add(35);

        // Eingang grün zu dunkelgrün
        // oben -> 36 bis 39
        doorwayTriangles.Add(38);
        doorwayTriangles.Add(36);
        doorwayTriangles.Add(37);
        doorwayTriangles.Add(36);
        doorwayTriangles.Add(38);
        doorwayTriangles.Add(39);
        // links -> 40 bis 43
        doorwayTriangles.Add(41);
        doorwayTriangles.Add(40);
        doorwayTriangles.Add(42);
        doorwayTriangles.Add(41);
        doorwayTriangles.Add(42);
        doorwayTriangles.Add(43);
        // rechts -> 44 bis 47
        doorwayTriangles.Add(44);
        doorwayTriangles.Add(45);
        doorwayTriangles.Add(46);
        doorwayTriangles.Add(45);
        doorwayTriangles.Add(47);
        doorwayTriangles.Add(46);

        // Eingang dunkelblau zu lila
        // oben -> 48 bis 51
        doorwayTriangles.Add(50);
        doorwayTriangles.Add(49);
        doorwayTriangles.Add(48);
        doorwayTriangles.Add(49);
        doorwayTriangles.Add(50);
        doorwayTriangles.Add(51);
        // links -> 52 bis 55
        doorwayTriangles.Add(53);
        doorwayTriangles.Add(52);
        doorwayTriangles.Add(54);
        doorwayTriangles.Add(53);
        doorwayTriangles.Add(54);
        doorwayTriangles.Add(55);
        // rechts -> 56 bis 59
        doorwayTriangles.Add(57);
        doorwayTriangles.Add(58);
        doorwayTriangles.Add(56);
        doorwayTriangles.Add(57);
        doorwayTriangles.Add(59);
        doorwayTriangles.Add(58);

        // Eingang dunkelgrün zu lila
        // oben -> 60 bis 63
        doorwayTriangles.Add(62);
        doorwayTriangles.Add(61);
        doorwayTriangles.Add(60);
        doorwayTriangles.Add(61);
        doorwayTriangles.Add(62);
        doorwayTriangles.Add(63);
        // links -> 64 bis 67
        doorwayTriangles.Add(65);
        doorwayTriangles.Add(64);
        doorwayTriangles.Add(66);
        doorwayTriangles.Add(65);
        doorwayTriangles.Add(66);
        doorwayTriangles.Add(67);
        // rechts -> 68 bis 71
        doorwayTriangles.Add(69);
        doorwayTriangles.Add(70);
        doorwayTriangles.Add(68);
        doorwayTriangles.Add(69);
        doorwayTriangles.Add(71);
        doorwayTriangles.Add(70);

        // Eingang lila zu grün
        // oben -> 72 bis 75
        doorwayTriangles.Add(74);
        doorwayTriangles.Add(72);
        doorwayTriangles.Add(73);
        doorwayTriangles.Add(73);
        doorwayTriangles.Add(75);
        doorwayTriangles.Add(74);
        // links -> 76 bis 79
        doorwayTriangles.Add(77);
        doorwayTriangles.Add(76);
        doorwayTriangles.Add(78);
        doorwayTriangles.Add(77);
        doorwayTriangles.Add(78);
        doorwayTriangles.Add(79);
        // rechts -> 80 bis 83
        doorwayTriangles.Add(80);
        doorwayTriangles.Add(81);
        doorwayTriangles.Add(82);
        doorwayTriangles.Add(81);
        doorwayTriangles.Add(83);
        doorwayTriangles.Add(82);

        // Eingang lila zu dunkelblau
        // oben -> 84 bis 87
        doorwayTriangles.Add(87);
        doorwayTriangles.Add(85);
        doorwayTriangles.Add(84);
        doorwayTriangles.Add(85);
        doorwayTriangles.Add(87);
        doorwayTriangles.Add(86);
        // links -> 88 bis 91
        doorwayTriangles.Add(88);
        doorwayTriangles.Add(89);
        doorwayTriangles.Add(90);
        doorwayTriangles.Add(89);
        doorwayTriangles.Add(91);
        doorwayTriangles.Add(90);
        // rechts -> 92 bis 95
        doorwayTriangles.Add(93);
        doorwayTriangles.Add(92);
        doorwayTriangles.Add(94);
        doorwayTriangles.Add(93);
        doorwayTriangles.Add(94);
        doorwayTriangles.Add(95);

        meshDoorway.triangles = doorwayTriangles.ToArray();

        // Eingang grün zu lila
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang grün zu blau
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // Eingang grün zu dunkelblau
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang grün zu dunkelgrün
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang dunkelblau zu lila
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang dunkelgrün zu lila
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang lila zu grün
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        // Eingang lila zu dunkelblau
        // oben
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // links
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));
        // rechts
        doorwayUvs.Add(new Vector2(1, 0));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(1, 1));

        meshDoorway.uv = doorwayUvs.ToArray();

        meshDoorway.RecalculateNormals();

        MeshCollider doorwayCollider = doorway.AddComponent<MeshCollider>();
        Rigidbody doorwayBody = doorway.AddComponent<Rigidbody>();
        doorwayBody.isKinematic = true;
        meshDoorway = doorwayCollider.sharedMesh;
    }
}
