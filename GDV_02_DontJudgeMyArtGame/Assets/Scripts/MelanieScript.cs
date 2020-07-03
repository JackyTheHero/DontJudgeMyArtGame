using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelanieScript : MonoBehaviour
{
    int height = 12;
    int wallThickness = 2;

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
        Mesh meshGround1 = new Mesh();
        GameObject ground1 = new GameObject("Ground1", typeof(MeshFilter), typeof(MeshRenderer));

        Renderer rend = ground1.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        Texture texture = Resources.Load("TextureLight") as Texture;
        rend.material.mainTexture = texture;

        meshGround1 = ground1.GetComponent<MeshFilter>().mesh;
        meshGround1.Clear();

        List<Vector3> ground1Vertices = new List<Vector3>();
        List<int> ground1Triangles = new List<int>();
        List<Vector3> ground1Normals = new List<Vector3>();
        List<Vector2> ground1Uvs = new List<Vector2>();

        // Raum 1 -> Boden
        ground1Vertices.Add(new Vector3(-12, 0, 0));
        ground1Vertices.Add(new Vector3(42, 0, 0));
        ground1Vertices.Add(new Vector3(-12, 0, 50));
        ground1Vertices.Add(new Vector3(42, 0, 50));

        meshGround1.vertices = ground1Vertices.ToArray();

        // Boden -> 0 bis 3
        ground1Triangles.Add(1);
        ground1Triangles.Add(0);
        ground1Triangles.Add(2);
        ground1Triangles.Add(3);
        ground1Triangles.Add(1);
        ground1Triangles.Add(2);

        meshGround1.triangles = ground1Triangles.ToArray();

        // Material wird erst durch UV-Koordinaten sichtbar
        // Boden
        ground1Uvs.Add(new Vector2(0, 1));
        ground1Uvs.Add(new Vector2(0, 0));
        ground1Uvs.Add(new Vector2(1, 1));
        ground1Uvs.Add(new Vector2(1, 0));

        meshGround1.uv = ground1Uvs.ToArray();

        // wird zusätzlich benötigt, damit Material sichtbar wird
        meshGround1.normals = new Vector3[] {new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0)};

        // MeshCollider erst hinzufügen, nachdem Mesh kreiert wurde, ansonsten macht der Collider gar nichts, da kein Mesh zugewiesen wird
        MeshCollider ground1Collider = ground1.AddComponent<MeshCollider>();
        meshGround1 = ground1Collider.sharedMesh;
        // meshGround1.RecalculateNormals(); // berechnet Normalen automatisch
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

        // Vorderseite
        room1Vertices.Add(new Vector3(-12, 0, 0));
        room1Vertices.Add(new Vector3(42, 0, 0));
        room1Vertices.Add(new Vector3(42, height, 0));
        room1Vertices.Add(new Vector3(-12, height, 0));
        // Rückseite
        room1Vertices.Add(new Vector3(-12, 0, wallThickness));
        room1Vertices.Add(new Vector3(42, 0, wallThickness));
        room1Vertices.Add(new Vector3(42, height, wallThickness));
        room1Vertices.Add(new Vector3(-12, height, wallThickness));
        // Vorderseite
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 0));
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 0));
        // Rückseite
        room1Vertices.Add(new Vector3(-12, 0, 0));
        room1Vertices.Add(new Vector3(-12, 0, 50));
        room1Vertices.Add(new Vector3(-12, height, 50));
        room1Vertices.Add(new Vector3(-12, height, 0));
        // Wand über Türrahmen
        room1Vertices.Add(new Vector3(-12, height / 2, 50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height / 2, 50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height, 50 - wallThickness));
        room1Vertices.Add(new Vector3(-12, height, 50 - wallThickness));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(-12, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(22, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(22, height / 2,  50 - wallThickness));
        room1Vertices.Add(new Vector3(-12, height / 2,  50 - wallThickness));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(30, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(42, 0,  50 - wallThickness));
        room1Vertices.Add(new Vector3(42, height / 2,  50 - wallThickness));
        room1Vertices.Add(new Vector3(30, height / 2,  50 - wallThickness));
        // Vorderseite
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 0));
        room1Vertices.Add(new Vector3(42 - wallThickness, 0, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height, 50));
        room1Vertices.Add(new Vector3(42 - wallThickness, height, 0));            
        /*// Decke
        room1Vertices.Add(new Vector3(-12, height, 0));
        room1Vertices.Add(new Vector3(42, height, 0));
        room1Vertices.Add(new Vector3(-12, height, 50));
        room1Vertices.Add(new Vector3(42, height, 50));*/

        // int countVertices = roomVertices.Count;

        meshRoom1.vertices = room1Vertices.ToArray();

        // Vorderseite -> 0 bis 3
        room1Triangles.Add(0);
        room1Triangles.Add(2);
        room1Triangles.Add(1);
        room1Triangles.Add(0);
        room1Triangles.Add(3);
        room1Triangles.Add(2);
        // Rückseite -> 4 bis 7
        room1Triangles.Add(4);
        room1Triangles.Add(5);
        room1Triangles.Add(6);
        room1Triangles.Add(4);
        room1Triangles.Add(6);
        room1Triangles.Add(7);
        // Vorderseite -> 8 bis 11
        room1Triangles.Add(8);
        room1Triangles.Add(10);
        room1Triangles.Add(9);
        room1Triangles.Add(8);
        room1Triangles.Add(11);
        room1Triangles.Add(10);
        // Rückseite -> 12 bis 15
        room1Triangles.Add(12);
        room1Triangles.Add(13);
        room1Triangles.Add(14);
        room1Triangles.Add(12);
        room1Triangles.Add(14);
        room1Triangles.Add(15);
        // Wand über Türrahmen -> 16 bis 19
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
        // Wand unter Türrahmen -> rechts -> 24 bis 27
        room1Triangles.Add(24);
        room1Triangles.Add(26);
        room1Triangles.Add(25);
        room1Triangles.Add(24);
        room1Triangles.Add(27);
        room1Triangles.Add(26);
        // Vorderseite -> 28 bis 31
        room1Triangles.Add(28);
        room1Triangles.Add(29);
        room1Triangles.Add(30);
        room1Triangles.Add(28);
        room1Triangles.Add(30);
        room1Triangles.Add(31);
        
        /*// Decke -> 36 bis 39
        room1Triangles.Add(36);
        room1Triangles.Add(37);
        room1Triangles.Add(38);
        room1Triangles.Add(37);
        room1Triangles.Add(39);
        room1Triangles.Add(38);*/

        meshRoom1.triangles = room1Triangles.ToArray();

        // Vorderseite
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Rückseite
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Vorderseite
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Rückseite
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
        // Vorderseite
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        /*// Decke
        room1Uvs.Add(new Vector2(0, 0.25f));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0.25f, 0.25f));
        room1Uvs.Add(new Vector2(0.25f, 0));*/
        
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
        room2Vertices.Add(new Vector3(-12, height / 2, 50));
        room2Vertices.Add(new Vector3(42, height / 2, 50));
        room2Vertices.Add(new Vector3(42, height, 50));
        room2Vertices.Add(new Vector3(-12, height, 50));
        // Wand unter Türrahmen -> rechts
        room2Vertices.Add(new Vector3(-12, 0, 50));
        room2Vertices.Add(new Vector3(22, 0, 50));
        room2Vertices.Add(new Vector3(22, height / 2, 50));
        room2Vertices.Add(new Vector3(-12, height / 2, 50));
        // Wand unter Türrahmen -> links
        room2Vertices.Add(new Vector3(30, 0,  50));
        room2Vertices.Add(new Vector3(42, 0,  50));
        room2Vertices.Add(new Vector3(42, height / 2,  50));
        room2Vertices.Add(new Vector3(30, height / 2,  50));

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
        // Rückseite
        room3Vertices.Add(new Vector3(42, 0, 0));
        room3Vertices.Add(new Vector3(42, 0, 50));
        room3Vertices.Add(new Vector3(42, height, 50));
        room3Vertices.Add(new Vector3(42, height, 0));
        
        meshRoom3.vertices = room3Vertices.ToArray();        

        // Rückseite -> 0 bis 3
        room3Triangles.Add(0);
        room3Triangles.Add(2);
        room3Triangles.Add(1);
        room3Triangles.Add(2);
        room3Triangles.Add(0);
        room3Triangles.Add(3);
        
        meshRoom3.triangles = room3Triangles.ToArray();

        // Rückseite
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        
        meshRoom3.uv = room3Uvs.ToArray();

        meshRoom3.RecalculateNormals();

        MeshCollider room3Collider = room3.AddComponent<MeshCollider>();
        Rigidbody room3Body = room3.AddComponent<Rigidbody>();
        room3Body.isKinematic = true;
        meshRoom3 = room2Collider.sharedMesh;
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

        // oben
        doorwayVertices.Add(new Vector3(30, height / 2, 50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / 2, 50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / 2, 50));
        doorwayVertices.Add(new Vector3(30, height / 2, 50));
        // links
        doorwayVertices.Add(new Vector3(22, 0,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, height / 2,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(22, 0,  50));
        doorwayVertices.Add(new Vector3(22, height / 2,  50));
        // rechts
        doorwayVertices.Add(new Vector3(30, 0,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(30, height / 2,  50 - wallThickness));
        doorwayVertices.Add(new Vector3(30, 0,  50));
        doorwayVertices.Add(new Vector3(30, height / 2,  50));

        meshDoorway.vertices = doorwayVertices.ToArray();

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

        meshDoorway.triangles = doorwayTriangles.ToArray();

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
