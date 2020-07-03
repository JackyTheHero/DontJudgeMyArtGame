using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelanieScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // CreateGround();
        CreateRooms();
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
        rend.material.color = Color.white;

        meshGround = ground.GetComponent<MeshFilter>().mesh;
        meshGround.Clear();

        meshGround.vertices = new Vector3[] {new Vector3(90, 0, 90), new Vector3(90, 0, -7), new Vector3(-7, 0, 90), new Vector3(-7, 0, -7)};

        meshGround.triangles = new int[] {0, 1, 2, 2, 1, 3};

        // Material wird erst durch UV-Koordinaten sichtbar
        meshGround.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1)};
        // wird zusätzlich benötigt, damit Material sichtbar wird
        meshGround.normals = new Vector3[] {new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0)};

        // MeshCollider erst hinzufügen, nachdem Mesh kreiert wurde, ansonsten macht der Collider gar nichts, da kein Mesh zugewiesen wird
        MeshCollider groundCollider = ground.AddComponent<MeshCollider>();
        meshGround = groundCollider.sharedMesh;
        // meshGround.RecalculateNormals(); // berechnet Normalen automatisch
    }

    private void CreateRooms() {

        Mesh meshRoom = new Mesh();
        GameObject room = new GameObject("Rooms", typeof(MeshFilter), typeof(MeshRenderer));
        Renderer rend = room.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        meshRoom = room.GetComponent<MeshFilter>().mesh;
        Texture texture = Resources.Load("Textures") as Texture;
        rend.material.mainTexture = texture;

        meshRoom.Clear();

        List<Vector3> roomVertices = new List<Vector3>();
        List<int> roomTriangles = new List<int>();
        List<Vector3> roomNormals = new List<Vector3>();
        List<Vector2> roomUvs = new List<Vector2>();

        room.transform.position = new Vector3(7, 0, -4);

        int height = 12;
        int wallThickness = 2;

        // Vorderseite
        roomVertices.Add(new Vector3(-12, 0, 0));
        roomVertices.Add(new Vector3(42, 0, 0));
        roomVertices.Add(new Vector3(42, height, 0));
        roomVertices.Add(new Vector3(-12, height, 0));
        // Rückseite
        roomVertices.Add(new Vector3(-12, 0, wallThickness));
        roomVertices.Add(new Vector3(42, 0, wallThickness));
        roomVertices.Add(new Vector3(42, height, wallThickness));
        roomVertices.Add(new Vector3(-12, height, wallThickness));
        // Vorderseite
        roomVertices.Add(new Vector3(-12 + wallThickness, 0, 0));
        roomVertices.Add(new Vector3(-12 + wallThickness, 0, 50));
        roomVertices.Add(new Vector3(-12 + wallThickness, height, 50));
        roomVertices.Add(new Vector3(-12 + wallThickness, height, 0));
        // Rückseite
        roomVertices.Add(new Vector3(-12, 0, 0));
        roomVertices.Add(new Vector3(-12, 0, 50));
        roomVertices.Add(new Vector3(-12, height, 50));
        roomVertices.Add(new Vector3(-12, height, 0));
        // Wand über Türrahmen -> Vorderseite
        roomVertices.Add(new Vector3(-12, height / 2, 50 - wallThickness));
        roomVertices.Add(new Vector3(42, height / 2, 50 - wallThickness));
        roomVertices.Add(new Vector3(42, height, 50 - wallThickness));
        roomVertices.Add(new Vector3(-12, height, 50 - wallThickness));
        // Wand über Türrahmen -> Rückseite
        roomVertices.Add(new Vector3(-12, height / 2, 50));
        roomVertices.Add(new Vector3(42, height / 2, 50));
        roomVertices.Add(new Vector3(42, height, 50));
        roomVertices.Add(new Vector3(-12, height, 50));
        // Wand unter Türrahmen -> Voderseite
        roomVertices.Add(new Vector3(-12, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(22, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(22, height / 2,  50 - wallThickness));
        roomVertices.Add(new Vector3(-12, height / 2,  50 - wallThickness));
        // Wand unter Türrahmen -> Voderseite
        roomVertices.Add(new Vector3(30, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(42, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(42, height / 2,  50 - wallThickness));
        roomVertices.Add(new Vector3(30, height / 2,  50 - wallThickness));
        // Wand unter Türrahmen -> Rückseite
        roomVertices.Add(new Vector3(-12, 0, 50));
        roomVertices.Add(new Vector3(22, 0, 50));
        roomVertices.Add(new Vector3(22, height / 2, 50));
        roomVertices.Add(new Vector3(-12, height / 2, 50));
        // Rückseite
        roomVertices.Add(new Vector3(42, 0, 0));
        roomVertices.Add(new Vector3(42, 0, 50));
        roomVertices.Add(new Vector3(42, height, 50));
        roomVertices.Add(new Vector3(42, height, 0));
        // Vorderseite
        roomVertices.Add(new Vector3(42 - wallThickness, 0, 0));
        roomVertices.Add(new Vector3(42 - wallThickness, 0, 50));
        roomVertices.Add(new Vector3(42 - wallThickness, height, 50));
        roomVertices.Add(new Vector3(42 - wallThickness, height, 0));
        // Boden
        roomVertices.Add(new Vector3(-12, 0, 0));
        roomVertices.Add(new Vector3(42, 0, 0));
        roomVertices.Add(new Vector3(-12, 0, 50));
        roomVertices.Add(new Vector3(42, 0, 50));
        // Lücken an Türrahmen schließen
        roomVertices.Add(new Vector3(-12, 0, 50));
        roomVertices.Add(new Vector3(22, 0, 50));
        roomVertices.Add(new Vector3(22, height / 2, 50));
        roomVertices.Add(new Vector3(-12, height / 2, 50));
        //
        roomVertices.Add(new Vector3(30, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(42, 0,  50 - wallThickness));
        roomVertices.Add(new Vector3(42, height / 2,  50 - wallThickness));
        roomVertices.Add(new Vector3(30, height / 2,  50 - wallThickness));
        //
        roomVertices.Add(new Vector3(30, height / 2, 50));
        roomVertices.Add(new Vector3(22, height / 2, 50));
        roomVertices.Add(new Vector3(30, height / 2,  50 - wallThickness));
        roomVertices.Add(new Vector3(22, height / 2,  50 - wallThickness));             
        /*// Decke
        roomVertices.Add(new Vector3(-12, height, 0));
        roomVertices.Add(new Vector3(42, height, 0));
        roomVertices.Add(new Vector3(-12, height, 50));
        roomVertices.Add(new Vector3(42, height, 50));*/

        // int countVertices = roomVertices.Count;

        meshRoom.vertices = roomVertices.ToArray();

        // Vorderseite -> 0 bis 3
        roomTriangles.Add(0);
        roomTriangles.Add(2);
        roomTriangles.Add(1);
        roomTriangles.Add(0);
        roomTriangles.Add(3);
        roomTriangles.Add(2);
        // Rückseite -> 4 bis 7
        roomTriangles.Add(4);
        roomTriangles.Add(5);
        roomTriangles.Add(6);
        roomTriangles.Add(4);
        roomTriangles.Add(6);
        roomTriangles.Add(7);
        // Vorderseite -> 8 bis 11
        roomTriangles.Add(8);
        roomTriangles.Add(10);
        roomTriangles.Add(9);
        roomTriangles.Add(8);
        roomTriangles.Add(11);
        roomTriangles.Add(10);
        // Rückseite -> 12 bis 15
        roomTriangles.Add(12);
        roomTriangles.Add(13);
        roomTriangles.Add(14);
        roomTriangles.Add(12);
        roomTriangles.Add(14);
        roomTriangles.Add(15);
        // Wand über Türrahmen -> Voderseite -> 16 bis 19
        roomTriangles.Add(16);
        roomTriangles.Add(18);
        roomTriangles.Add(17);
        roomTriangles.Add(16);
        roomTriangles.Add(19);
        roomTriangles.Add(18);
        // Wand über Türrahmen -> Rückseite -> 20 bis 23
        roomTriangles.Add(20);
        roomTriangles.Add(21);
        roomTriangles.Add(22);
        roomTriangles.Add(20);
        roomTriangles.Add(22);
        roomTriangles.Add(23);
        // Wand unter Türrahmen -> Voderseite -> 24 bis 27
        roomTriangles.Add(24);
        roomTriangles.Add(26);
        roomTriangles.Add(25);
        roomTriangles.Add(24);
        roomTriangles.Add(27);
        roomTriangles.Add(26);
        // Wand unter Türrahmen -> Voderseite -> 28 bis 31
        roomTriangles.Add(28);
        roomTriangles.Add(30);
        roomTriangles.Add(29);
        roomTriangles.Add(28);
        roomTriangles.Add(31);
        roomTriangles.Add(30);
        // Wand unter Türrahmen -> Rückseite -> 32 bis 35
        roomTriangles.Add(32);
        roomTriangles.Add(33);
        roomTriangles.Add(34);
        roomTriangles.Add(32);
        roomTriangles.Add(34);
        roomTriangles.Add(35);
        // Rückseite -> 36 bis 39
        roomTriangles.Add(36);
        roomTriangles.Add(38);
        roomTriangles.Add(37);
        roomTriangles.Add(36);
        roomTriangles.Add(39);
        roomTriangles.Add(38);
        // Vorderseite -> 40 bis 43
        roomTriangles.Add(40);
        roomTriangles.Add(41);
        roomTriangles.Add(42);
        roomTriangles.Add(40);
        roomTriangles.Add(42);
        roomTriangles.Add(43);
        // Boden -> 44 bis 47
        roomTriangles.Add(45);
        roomTriangles.Add(44);
        roomTriangles.Add(46);
        roomTriangles.Add(47);
        roomTriangles.Add(45);
        roomTriangles.Add(46);
        // Lücken an Türrahmen schließen
        // Rückseite -> 48 bis 51
        roomTriangles.Add(48);
        roomTriangles.Add(50);
        roomTriangles.Add(49);
        roomTriangles.Add(48);
        roomTriangles.Add(51);
        roomTriangles.Add(50);
        // Vorderseite -> 52 bis 55
        roomTriangles.Add(52);
        roomTriangles.Add(53);
        roomTriangles.Add(54);
        roomTriangles.Add(52);
        roomTriangles.Add(54);
        roomTriangles.Add(55);
        // Vorderseite -> 56 bis 59
        roomTriangles.Add(57);
        roomTriangles.Add(56);
        roomTriangles.Add(58);
        roomTriangles.Add(56);
        roomTriangles.Add(58);
        roomTriangles.Add(59);
        /*// Decke -> 36 bis 39
        roomTriangles.Add(36);
        roomTriangles.Add(37);
        roomTriangles.Add(38);
        roomTriangles.Add(37);
        roomTriangles.Add(39);
        roomTriangles.Add(38);*/

        meshRoom.triangles = roomTriangles.ToArray();

        // Vorderseite
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        // Rückseite
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        // Vorderseite
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        // Rückseite
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        // Wand über Türrahmen -> Voderseite
        roomUvs.Add(new Vector2(0.25f, 0.25f / 2));
        roomUvs.Add(new Vector2(0.25f / 2, 0.25f / 2));
        roomUvs.Add(new Vector2(0.25f / 2, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f)); 
        // Wand über Türrahmen -> Rückseite
        roomUvs.Add(new Vector2(0.5f, 0.375f));
        roomUvs.Add(new Vector2(0.375f, 0.375f));
        roomUvs.Add(new Vector2(0.375f, 0.5f));
        roomUvs.Add(new Vector2(0.5f, 0.5f)); 
        // Wand unter Türrahmen -> Voderseite
        roomUvs.Add(new Vector2(0.25f / 2, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f / 2));
        roomUvs.Add(new Vector2(0.25f / 2, 0.25f / 2));
        // Wand unter Türrahmen -> Voderseite
        roomUvs.Add(new Vector2(0.25f / 2, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f / 2));
        roomUvs.Add(new Vector2(0.25f / 2, 0.25f / 2)); 
        // Wand unter Türrahmen -> Vorderseite
        roomUvs.Add(new Vector2(0.275f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.375f));
        roomUvs.Add(new Vector2(0.375f, 0.375f)); 
        // Rückseite
        roomUvs.Add(new Vector2(1, 0.75f));
        roomUvs.Add(new Vector2(0.75f, 0.75f));
        roomUvs.Add(new Vector2(0.75f, 1));
        roomUvs.Add(new Vector2(1, 1));
        // Vorderseite
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        // Boden
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0));
        // Lücken an Türrahmen schließen
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        /*// Decke
        roomUvs.Add(new Vector2(0, 0.25f));
        roomUvs.Add(new Vector2(0, 0));
        roomUvs.Add(new Vector2(0.25f, 0.25f));
        roomUvs.Add(new Vector2(0.25f, 0));*/
        
        meshRoom.uv = roomUvs.ToArray();

        // berechnet Normalen automatisch
        meshRoom.RecalculateNormals();

        //meshRoom.normals = roomNormals.ToArray();


        MeshCollider roomCollider = room.AddComponent<MeshCollider>();
        Rigidbody roomBody = room.AddComponent<Rigidbody>();
        roomBody.isKinematic = true;
        meshRoom = roomCollider.sharedMesh;
    }
}
