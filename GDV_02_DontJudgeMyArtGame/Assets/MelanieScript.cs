using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelanieScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CreateGround();
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

        meshGround.vertices = new Vector3[] {new Vector3(84, 0, 84), new Vector3(84, 0, -5), new Vector3(-4, 0, 84), new Vector3(-4, 0, -5)};

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
        rend.material.color = Color.blue;
        meshRoom = room.GetComponent<MeshFilter>().mesh;

        meshRoom.Clear();

        List<Vector3> roomVertices = new List<Vector3>();
        List<int> roomTriangles = new List<int>();
        List<Vector3> roomNormals = new List<Vector3>();
        List<Vector2> roomUvs = new List<Vector2>();

        room.transform.position = new Vector3(7, 0, -4);

        int height = 10;

        // Vorderseite
        roomVertices.Add(new Vector3(-10, 0, 0));
        roomVertices.Add(new Vector3(40, 0, 0));
        roomVertices.Add(new Vector3(40, height, 0));
        roomVertices.Add(new Vector3(-10, height, 0));
        // Rückseite
        roomVertices.Add(new Vector3(-10, 0, 0.5f));
        roomVertices.Add(new Vector3(40, 0, 0.5f));
        roomVertices.Add(new Vector3(40, height, 0.5f));
        roomVertices.Add(new Vector3(-10, height, 0.5f));
        // Vorderseite
        roomVertices.Add(new Vector3(-9.5f, 0, 0));
        roomVertices.Add(new Vector3(-9.5f, 0, 50));
        roomVertices.Add(new Vector3(-9.5f, height, 50));
        roomVertices.Add(new Vector3(-9.5f, height, 0));
        // Rückseite
        roomVertices.Add(new Vector3(-10, 0, 0));
        roomVertices.Add(new Vector3(-10, 0, 50));
        roomVertices.Add(new Vector3(-10, height, 50));
        roomVertices.Add(new Vector3(-10, height, 0));
        // Vorderseite
        roomVertices.Add(new Vector3(-10, 0, 49.5f));
        roomVertices.Add(new Vector3(40, 0, 49.5f));
        roomVertices.Add(new Vector3(40, height, 49.5f));
        roomVertices.Add(new Vector3(-10, height, 49.5f));
        // Rückseite
        roomVertices.Add(new Vector3(-10, 0, 50));
        roomVertices.Add(new Vector3(40, 0, 50));
        roomVertices.Add(new Vector3(40, height, 50));
        roomVertices.Add(new Vector3(-10, height, 50));
        // Vorderseite
        roomVertices.Add(new Vector3(40, 0, 0));
        roomVertices.Add(new Vector3(40, 0, 50));
        roomVertices.Add(new Vector3(40, height, 50));
        roomVertices.Add(new Vector3(40, height, 0));
        // Rückseite
        roomVertices.Add(new Vector3(39.5f, 0, 0));
        roomVertices.Add(new Vector3(39.5f, 0, 50));
        roomVertices.Add(new Vector3(39.5f, height, 50));
        roomVertices.Add(new Vector3(39.5f, height, 0));

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
        // Vorderseite -> 16 bis 19
        roomTriangles.Add(16);
        roomTriangles.Add(18);
        roomTriangles.Add(17);
        roomTriangles.Add(16);
        roomTriangles.Add(19);
        roomTriangles.Add(18);
        // Rückseite -> 20 bis 23
        roomTriangles.Add(20);
        roomTriangles.Add(21);
        roomTriangles.Add(22);
        roomTriangles.Add(20);
        roomTriangles.Add(22);
        roomTriangles.Add(23);
        // Vorderseite -> 24 bis 27
        roomTriangles.Add(24);
        roomTriangles.Add(26);
        roomTriangles.Add(25);
        roomTriangles.Add(24);
        roomTriangles.Add(27);
        roomTriangles.Add(26);
        // Rückseite -> 28 bis 31
        roomTriangles.Add(28);
        roomTriangles.Add(29);
        roomTriangles.Add(30);
        roomTriangles.Add(28);
        roomTriangles.Add(30);
        roomTriangles.Add(31);

        meshRoom.triangles = roomTriangles.ToArray();

        // berechnet Normalen automatisch
        meshRoom.RecalculateNormals();

        MeshCollider roomCollider = room.AddComponent<MeshCollider>();
        Rigidbody roomBody = room.AddComponent<Rigidbody>();
        roomBody.isKinematic = true;
        meshRoom = roomCollider.sharedMesh;
    }
}
