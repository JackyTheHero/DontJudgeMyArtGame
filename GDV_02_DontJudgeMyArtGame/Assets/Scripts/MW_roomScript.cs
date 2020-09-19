using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_roomScript : MonoBehaviour
{
    /*
        ALLE FOLGENDEN VARIABLEN WERDEN ZUSÄTZLICH DAZU GENUTZT, EINE SPÄTERE ÄNDERUNG DIESER WERTE DYNAMISCH MÖGLICH ...
        ... ZU MACHEN, OHNE ALLES ABÄNDERN ZU MÜSSEN, SO Z.B.:
            -> DIE UVS, DAMIT SICH BEI ÄNDERUNG DIE TEXTUR NICHT VERSCHIEBT
            -> DIE BREITE DER DURCHGÄNGE, DIE DIE FACES VERÄNDERT
            -> DIE DICKE DER WÄNDE, DIE DIE FACES VERSCHIEBT
            -> USW.
    */

    // Variable für Höhe und Dicke der Wand, sodass sie später leichter dnymaisch geändert werden können
    static float height = 45.0f;
    static float wallThickness = 2.0f;
    // Wie hoch sind die Durchgänge in Relation zur Wandhöhe? -> height / doorwayFactor
    static float doorwayFactor = 4.0f;
    // Wie lang und breit sind die Durchgänge
    static float doorwayThickness = 10.0f;

    // berechnet die UV-Koordinate zwischen den Faces in Realtion zu ihrer Höhe
    static float wallAboveUV;

    static GameObject building;


    // Start is called before the first frame update
    void Start()
    {
		// Methode wird in einem anderen Skript aufgerufen, daher Deklaration als public static
        // CreateWholeBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CreateWholeBuilding() {
		// berechnet die UV-Koordinate zwischen den Faces in Relation zu ihrer Höhe
        wallAboveUV = (height / doorwayFactor) / height;
		
        // Empty, an das alle Bestandteile des Raumaufbaus gehängt werden
        building = new GameObject();
        // Empty so verschieben, dass Spieler auf seiner Startposition steht
        building.transform.Translate(-82, 0, 41);
        building.name = "Building";

        CreateAllGrounds();
        CreateFrontDoor();
        CreateRooms();
        CreateAllDoorways();
        CreateDividingWall();

        // Versetzt Empty auf den Ursprungsppunkt 0|0|0, wo auch Spieler starten soll
        building.transform.Translate(82, 0, -41);
    }


    // Empty, in dem sich Böden aller Räume befinden
    static GameObject grounds = new GameObject("Grounds");
    // zähle Anzahl der Böden beim Erstellen hoch -> Namensgebung
    static int countGrounds = 0;

    /* FUNKTION, DIE EINEN BODEN ERSTELLT */
    static void CreateGround(float posX, float posZ, float width, float length) {
        countGrounds++;

        Mesh meshGround = new Mesh();
        GameObject ground = new GameObject("Ground " + countGrounds, typeof(MeshFilter), typeof(MeshRenderer));
        // füge ground zum Empty "Building"
        ground.transform.parent = building.transform;

        Renderer rend = ground.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Standard"));

        // Material hinzufügen, das in der UI erstellt wurde (Assets -> Create -> Material)
        // unter Albedo schließlich die Textur auswählen
        Material woodGround = Resources.Load("woodGround") as Material;
        ground.GetComponent<Renderer>().material = woodGround;

        meshGround = ground.GetComponent<MeshFilter>().mesh;
        meshGround.Clear();

        List<Vector3> groundVertices = new List<Vector3>();
        List<int> groundTriangles = new List<int>();
        List<Vector2> groundUvs = new List<Vector2>();

        groundVertices.Add(new Vector3(posX, 0, posZ));
        groundVertices.Add(new Vector3(posX + width, 0, posZ ));
        groundVertices.Add(new Vector3(posX, 0, posZ + length));
        groundVertices.Add(new Vector3(posX + width, 0, posZ + length));
        
        meshGround.vertices = groundVertices.ToArray();

        // Raum 1 -> 0 bis 3
        groundTriangles.Add(1);
        groundTriangles.Add(0);
        groundTriangles.Add(2);
        groundTriangles.Add(3);
        groundTriangles.Add(1);
        groundTriangles.Add(2);

        meshGround.triangles = groundTriangles.ToArray();

        // Material wird erst durch UV-Koordinaten sichtbar
        // Raum 1
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

        // Empty grounds wird zu building hinzugefügt
        grounds.transform.parent = building.transform;
        // einzelne Türrahmen werden zum Empty grounds hinzugefügt
        ground.transform.parent = grounds.transform;
    }

    /*FUNKTION, DIE ALLE BÖDEN ERSTELLT*/
    static void CreateAllGrounds() {
        /* wallThickness / 2 -> sodass ein Boden immer bis zur Hälfte des Türrahmens geht */

        // -> Farbangaben aus 1. Version (richtige Tapeten kamen erst, als die Räume fertig waren)
        // Raum 1 -> grüner Raum
        CreateGround(-12.0f + wallThickness / 2, 0.0f + wallThickness / 2, 54.0f - wallThickness, 50.0f- wallThickness);
        // Raum 2 -> lila Raum
        CreateGround(-12.0f + wallThickness / 2, 50.0f - wallThickness / 2, 72.0f, 80.0f + wallThickness);
        // Raum 3 -> blauer Raum
        CreateGround(42.0f - wallThickness / 2, 0.0f + wallThickness / 2, 68.0f + wallThickness, 48.0f);
        // Raum 4 -> dunkelblauer Raum
        CreateGround(-95.0f - wallThickness / 2, 0.0f + wallThickness / 2, 83.0f + wallThickness, 78.0f);
        // Raum 5 -> dunkelgrüner Raum
        CreateGround(-30.0f + wallThickness / 2, -70.0f - wallThickness / 2, 72.0f - wallThickness, 70.0f + wallThickness);
        // Raum 6 -> lila Raum
        CreateGround(-70.0f + wallThickness / 2, -70.0f - wallThickness / 2, 40.0f, 70.0f + wallThickness);
        // Raum 7 -> grüner Raum
        CreateGround(-70.0f - wallThickness / 2, 78.0f + wallThickness / 2, 58.0f + wallThickness, 52.0f);
        // Raum 8 -> dunkelgrüner Raum
        CreateGround(60.0f + wallThickness / 2, 50.0f - wallThickness / 2, 50.0f, 80.0f + wallThickness);
        // Raum 9 -> dunkelblauer Raum
        CreateGround(42.0f - wallThickness / 2, -70.0f - wallThickness / 2, 68.0f + wallThickness, 70.0f + wallThickness);
    }


    // speichere Texturen dieser beiden Räume für die Zwischenwände
    static Texture texture2;
    static Texture texture9;

    /* FUNKTION, DIE RÄUME ERSTELLT */
    static void CreateRooms() {
        // Room 1
        Mesh meshRoom1 = new Mesh();
        GameObject room1 = new GameObject("Room 1", typeof(MeshFilter), typeof(MeshRenderer));
        // füge room1 zum Empty "Building" -> auch alle anderen Räume werden hinzugefügt
        room1.transform.parent = building.transform;

        Renderer rend1 = room1.GetComponent<Renderer>();
        rend1.material = new Material(Shader.Find("Standard"));
        meshRoom1 = room1.GetComponent<MeshFilter>().mesh;
        // Texture texture1 = Resources.Load("TextureGreen") as Texture;
        Texture texture1 = MW_randomWallpaper.RandomTexture(room1);
        rend1.material.mainTexture = texture1;
        MW_randomWallpaper.wallpapers.Remove(texture1);

        meshRoom1.Clear();

        List<Vector3> room1Vertices = new List<Vector3>();
        List<int> room1Triangles = new List<int>();
        List<Vector2> room1Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu dunkelgrüner Wand -> Farbangaben aus 1. Version (richtige Tapeten kamen erst, als die Räume fertig waren)
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(42, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(42, height, wallThickness));
        room1Vertices.Add(new Vector3(-12, height, wallThickness));
        // Wand unter Türrahmen -> rechts
        room1Vertices.Add(new Vector3(-12, 0, wallThickness));
        room1Vertices.Add(new Vector3(5, 0, wallThickness));
        room1Vertices.Add(new Vector3(5, height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(-12, height / doorwayFactor, wallThickness));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(5 + doorwayThickness, 0, wallThickness));
        room1Vertices.Add(new Vector3(42, 0, wallThickness));
        room1Vertices.Add(new Vector3(42  , height / doorwayFactor, wallThickness));
        room1Vertices.Add(new Vector3(5 + doorwayThickness, height / doorwayFactor, wallThickness));
        // Wand über Türrahmen -> Eingang zu dunkelblauer Wand
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 0));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 50));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height, 0));
        // Wand unter Türrahmen -> links
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 0));
        room1Vertices.Add(new Vector3(-12 + wallThickness, 0, 20));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 20));
        room1Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> rechts
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
        room1Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 0 + wallThickness / 2));
        room1Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 0 + wallThickness / 2));
        room1Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 50 - wallThickness / 2));
        room1Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 50 - wallThickness / 2));*/

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
        // Wand unter Türrahmen -> links -> 16 bis 19
        room1Triangles.Add(16);
        room1Triangles.Add(18);
        room1Triangles.Add(17);
        room1Triangles.Add(16);
        room1Triangles.Add(19);
        room1Triangles.Add(18);
        // Wand unter Türrahmen -> rechts -> 20 bis 23
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
        room1Triangles.Add(51);
        room1Triangles.Add(50);
        room1Triangles.Add(49);*/

        meshRoom1.triangles = room1Triangles.ToArray();

        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(1.0f - (17.0f / 54.0f), 0));
        room1Uvs.Add(new Vector2(1.0f - (17.0f / 54.0f), wallAboveUV));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2((42.0f - 5.0f - doorwayThickness) / 54.0f, 0));
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2((42.0f - 5.0f - doorwayThickness) / 54.0f, wallAboveUV));
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(1, 1));
        room1Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(20.0f / 50.0f, 0));
        room1Uvs.Add(new Vector2(20.0f / 50.0f, wallAboveUV));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1.0f - ((50.0f - 20.0f - doorwayThickness) / 50.0f), 0));
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(1.0f - ((50.0f - 20.0f - doorwayThickness) / 50.0f), wallAboveUV));
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(1, 1));
        room1Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(34.0f / 54.0f, 0)); // 0.62962962963f
        room1Uvs.Add(new Vector2(34.0f / 54.0f, wallAboveUV));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1.0f - ((42.0f - 22.0f - doorwayThickness) / 54.0f), 0)); // 0.81481481482f
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(1.0f - ((42.0f - 22.0f - doorwayThickness) / 54.0f), wallAboveUV));
        // Wand über Türrahmen
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2(0, 1));
        room1Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room1Uvs.Add(new Vector2(1, 0));
        room1Uvs.Add(new Vector2(1.0f - (20.0f / 50.0f), 0)); // 0.6f
        room1Uvs.Add(new Vector2(1.0f - (20.0f / 50.0f), wallAboveUV));
        room1Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room1Uvs.Add(new Vector2((50.0f - 20.0f - doorwayThickness) / 50.0f, 0)); // 0.4f
        room1Uvs.Add(new Vector2(0, 0));
        room1Uvs.Add(new Vector2(0, wallAboveUV));
        room1Uvs.Add(new Vector2((50.0f - 20.0f - doorwayThickness) / 50.0f, wallAboveUV));
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
        room2.transform.parent = building.transform;

        Renderer rend2 = room2.GetComponent<Renderer>();
        rend2.material = new Material(Shader.Find("Standard"));
        meshRoom2 = room2.GetComponent<MeshFilter>().mesh;
        // Texture texture2 = Resources.Load("TexturePurple") as Texture;
        texture2 = MW_randomWallpaper.RandomTexture(room2);
        rend2.material.mainTexture = texture2;
        MW_randomWallpaper.wallpapers.Remove(texture2);

        meshRoom2.Clear();

        List<Vector3> room2Vertices = new List<Vector3>();
        List<int> room2Triangles = new List<int>();
        List<Vector2> room2Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height, 50));
        // Wand unter Türrahmen -> rechts
        room2Vertices.Add(new Vector3(-12 + wallThickness, 0, 50));
        room2Vertices.Add(new Vector3(22, 0, 50));
        room2Vertices.Add(new Vector3(22, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(-12 + wallThickness, height / doorwayFactor, 50));
        // Wand unter Türrahmen -> links
        room2Vertices.Add(new Vector3(22 + doorwayThickness, 0,  50));
        room2Vertices.Add(new Vector3(60, 0,  50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor,  50));
        room2Vertices.Add(new Vector3(22 + doorwayThickness, height / doorwayFactor,  50));
        // Wand über Türrahmen
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 130));
        room2Vertices.Add(new Vector3(60, height, 50));
        room2Vertices.Add(new Vector3(60, height, 130));
        // Wand unter Türrahmen -> rechts
        room2Vertices.Add(new Vector3(60, 0, 50));
        room2Vertices.Add(new Vector3(60, 0, 70));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 50));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 70));
        // Wand unter Türrahmen -> links
        room2Vertices.Add(new Vector3(60, 0, 70 + doorwayThickness));
        room2Vertices.Add(new Vector3(60, 0, 130));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 70 + doorwayThickness));
        room2Vertices.Add(new Vector3(60, height / doorwayFactor, 130));
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
        /*// Decke
        room2Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 50 - wallThickness / 2));
        room2Vertices.Add(new Vector3(60 + wallThickness / 2, 0, 50 - wallThickness / 2));
        room2Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 130 - wallThickness / 2));
        room2Vertices.Add(new Vector3(60 + wallThickness / 2, 0, 130 - wallThickness / 2));*/

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
        // Wand über Türrahmen -> 12 bis 15
        room2Triangles.Add(12);
        room2Triangles.Add(13);
        room2Triangles.Add(14);
        room2Triangles.Add(13);
        room2Triangles.Add(15);
        room2Triangles.Add(14);
        // Wand unter Türrahmen -> rechts -> 16 bis 19
        room2Triangles.Add(16);
        room2Triangles.Add(17);
        room2Triangles.Add(18);
        room2Triangles.Add(17);
        room2Triangles.Add(19);
        room2Triangles.Add(18);
        // Wand unter Türrahmen -> links -> 20 bis 23
        room2Triangles.Add(20);
        room2Triangles.Add(21);
        room2Triangles.Add(22);
        room2Triangles.Add(21);
        room2Triangles.Add(23);
        room2Triangles.Add(22);
        // Vorderseite -> 24 bis 27
        room2Triangles.Add(26);
        room2Triangles.Add(25);
        room2Triangles.Add(27);
        room2Triangles.Add(24);
        room2Triangles.Add(25);
        room2Triangles.Add(26);
        // Wand über Türrahmen -> 28 bis 31
        room2Triangles.Add(29);
        room2Triangles.Add(28);
        room2Triangles.Add(30);
        room2Triangles.Add(29);
        room2Triangles.Add(30);
        room2Triangles.Add(31);
        // Wand unter Türrahmen -> links -> 32 bis 35
        room2Triangles.Add(33);
        room2Triangles.Add(32);
        room2Triangles.Add(34);
        room2Triangles.Add(33);
        room2Triangles.Add(34);
        room2Triangles.Add(35);
        // Wand unter Türrahmen -> rechts -> 36 bis 39
        room2Triangles.Add(37);
        room2Triangles.Add(36);
        room2Triangles.Add(38);
        room2Triangles.Add(37);
        room2Triangles.Add(38);
        room2Triangles.Add(39);
        /*// Decke -> 40 bis 43
        room2Triangles.Add(40);
        room2Triangles.Add(41);
        room2Triangles.Add(42);
        room2Triangles.Add(43);
        room2Triangles.Add(42);
        room2Triangles.Add(41);*/

        meshRoom2.triangles = room2Triangles.ToArray();

        // Wand über Türrahmen
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(1.0f - ((22.0f + 12.0f - wallThickness) / (60.0f + 12.0f - wallThickness)), 0));
        room2Uvs.Add(new Vector2(1.0f - ((22.0f + 12.0f - wallThickness) / (60.0f + 12.0f - wallThickness)), wallAboveUV));
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room2Uvs.Add(new Vector2((60.0f - 22.0f - doorwayThickness) / (60.0f + 12.0f - wallThickness), 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        room2Uvs.Add(new Vector2((60.0f - 22.0f - doorwayThickness) / (60.0f + 12.0f - wallThickness), wallAboveUV));
        // Wand über Türrahmen
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        room2Uvs.Add(new Vector2(1, 1));
        room2Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> rechts
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(1.0f - (20.0f / 80.0f), 0));
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        room2Uvs.Add(new Vector2(1.0f - (20.0f / 80.0f), wallAboveUV));
        // Wand unter Türrahmen -> links
        room2Uvs.Add(new Vector2((130.0f - 70.0f - doorwayThickness) / 80.0f, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2((130.0f - 70.0f - doorwayThickness) / 80.0f, wallAboveUV));
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        // Vorderseite
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(1, 1));
        room2Uvs.Add(new Vector2(0, 1));
        // Wand über Türrahmen
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(50.0f / 80.0f, 0));
        room2Uvs.Add(new Vector2(0, wallAboveUV));
        room2Uvs.Add(new Vector2(50.0f / 80.0f, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room2Uvs.Add(new Vector2(1.0f - ((130.0f - 100.0f - doorwayThickness) / 80.0f), 0));
        room2Uvs.Add(new Vector2(1, 0));
        room2Uvs.Add(new Vector2(1.0f - ((130.0f - 100.0f - doorwayThickness) / 80.0f), wallAboveUV));
        room2Uvs.Add(new Vector2(1, wallAboveUV));
        /*// Decke
        room2Uvs.Add(new Vector2(0, 1));
        room2Uvs.Add(new Vector2(0, 0));
        room2Uvs.Add(new Vector2(1, 1));
        room2Uvs.Add(new Vector2(1, 0));*/

        meshRoom2.uv = room2Uvs.ToArray();

        meshRoom2.RecalculateNormals();

        MeshCollider room2Collider = room2.AddComponent<MeshCollider>();
        Rigidbody room2Body = room2.AddComponent<Rigidbody>();
        room2Body.isKinematic = true;
        meshRoom2 = room2Collider.sharedMesh;

        // Room 3
        Mesh meshRoom3 = new Mesh();
        GameObject room3 = new GameObject("Room 3", typeof(MeshFilter), typeof(MeshRenderer));
        room3.transform.parent = building.transform;

        Renderer rend3 = room3.GetComponent<Renderer>();
        rend3.material = new Material(Shader.Find("Standard"));
        meshRoom3 = room3.GetComponent<MeshFilter>().mesh;
        // Texture texture3 = Resources.Load("TextureBlue") as Texture;
        Texture texture3 = MW_randomWallpaper.RandomTexture(room3);
        rend3.material.mainTexture = texture3;
        MW_randomWallpaper.wallpapers.Remove(texture3);

        meshRoom3.Clear();

        List<Vector3> room3Vertices = new List<Vector3>();
        List<int> room3Triangles = new List<int>();
        List<Vector2> room3Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu grünem Raum
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 50));
        room3Vertices.Add(new Vector3(42, height, 50));
        room3Vertices.Add(new Vector3(42, height, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room3Vertices.Add(new Vector3(42, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(42, 0, 20));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 20));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room3Vertices.Add(new Vector3(42, 0, 20 + doorwayThickness));
        room3Vertices.Add(new Vector3(42, 0, 50));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 50));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 20 + doorwayThickness));
        // Wand über Türrahmen
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 48));
        room3Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 48));
        room3Vertices.Add(new Vector3(42, height, 48));
        room3Vertices.Add(new Vector3(110 + wallThickness, height, 48));
        // Wand unter Türrahmen -> rechts
        room3Vertices.Add(new Vector3(95, 0, 48));
        room3Vertices.Add(new Vector3(110 + wallThickness, 0, 48));
        room3Vertices.Add(new Vector3(95, height / doorwayFactor, 48));
        room3Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 48));
        // Wand unter Türrahmen -> links
        room3Vertices.Add(new Vector3(42, 0, 48));
        room3Vertices.Add(new Vector3(95 - doorwayThickness, 0, 48));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 48));
        room3Vertices.Add(new Vector3(95 - doorwayThickness, height / doorwayFactor, 48));
        // Wand über Türrahmen
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        room3Vertices.Add(new Vector3(42, height, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110 + wallThickness, height, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room3Vertices.Add(new Vector3(42, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(95 - doorwayThickness, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        room3Vertices.Add(new Vector3(95 - doorwayThickness, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room3Vertices.Add(new Vector3(95, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110 + wallThickness, 0, 0 + wallThickness));
        room3Vertices.Add(new Vector3(95, height / doorwayFactor, 0 + wallThickness));
        room3Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 0 + wallThickness));
        // Vorderseite
        room3Vertices.Add(new Vector3(110, 0, 0));
        room3Vertices.Add(new Vector3(110, 0, 50));
        room3Vertices.Add(new Vector3(110, height, 50));
        room3Vertices.Add(new Vector3(110, height, 0));
        /*// Decke
        room3Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 0 + wallThickness / 2));
        room3Vertices.Add(new Vector3(110 + wallThickness  /2, 0, 0 + wallThickness / 2));
        room3Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 50 - wallThickness / 2));
        room3Vertices.Add(new Vector3(110 + wallThickness / 2, 0, 50 - wallThickness / 2));*/

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
        // Wand über Türrahmen -> 12 bis 15
        room3Triangles.Add(12);
        room3Triangles.Add(14);
        room3Triangles.Add(13);
        room3Triangles.Add(13);
        room3Triangles.Add(14);
        room3Triangles.Add(15);
        // Wand unter Türrahmen -> rechts -> 16 bis 19
        room3Triangles.Add(16);
        room3Triangles.Add(18);
        room3Triangles.Add(17);
        room3Triangles.Add(17);
        room3Triangles.Add(18);
        room3Triangles.Add(19);
        // Wand unter Türrahmen -> links -> 20 bis 23
        room3Triangles.Add(20);
        room3Triangles.Add(22);
        room3Triangles.Add(21);
        room3Triangles.Add(21);
        room3Triangles.Add(22);
        room3Triangles.Add(23);
        // Wand über Türrahmen -> 24 bis 27
        room3Triangles.Add(24);
        room3Triangles.Add(25);
        room3Triangles.Add(26);
        room3Triangles.Add(25);
        room3Triangles.Add(27);
        room3Triangles.Add(26);
        // Wand unter Türrahmen -> rechts -> 28 bis 31
        room3Triangles.Add(28);
        room3Triangles.Add(29);
        room3Triangles.Add(30);
        room3Triangles.Add(29);
        room3Triangles.Add(31);
        room3Triangles.Add(30);
        // Wand unter Türrahmen -> links -> 32 bis 35
        room3Triangles.Add(32);
        room3Triangles.Add(33);
        room3Triangles.Add(34);
        room3Triangles.Add(33);
        room3Triangles.Add(35);
        room3Triangles.Add(34);
        // Vorderseite -> 36 bis 39
        room3Triangles.Add(36);
        room3Triangles.Add(37);
        room3Triangles.Add(38);
        room3Triangles.Add(36);
        room3Triangles.Add(38);
        room3Triangles.Add(39);
        /*// Decke -> 40 bis 43
        room3Triangles.Add(40);
        room3Triangles.Add(41);
        room3Triangles.Add(42);
        room3Triangles.Add(43);
        room3Triangles.Add(42);
        room3Triangles.Add(41);*/

        meshRoom3.triangles = room3Triangles.ToArray();

        // Wand über Türrahmen
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        room3Uvs.Add(new Vector2(1, 1));
        room3Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2((20.0f - wallThickness) / (50.0f - wallThickness), 0));
        room3Uvs.Add(new Vector2((20.0f - wallThickness) / (50.0f - wallThickness), wallAboveUV));
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room3Uvs.Add(new Vector2(1.0f - ((50.0f - 20.0f - doorwayThickness) / (50.0f - wallThickness)), 0));
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        room3Uvs.Add(new Vector2(1.0f - ((50.0f - 20.0f - doorwayThickness) / (50.0f - wallThickness)), wallAboveUV));
        // Wand über Türrahmen
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room3Uvs.Add(new Vector2(1.0f - ((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f)), 0));
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(1.0f - ((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f)), wallAboveUV));
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2((95.0f - 42.0f - doorwayThickness) / (110.0f + wallThickness - 42.0f), 0));
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        room3Uvs.Add(new Vector2((95.0f - 42.0f - doorwayThickness) / (110.0f + wallThickness - 42.0f), wallAboveUV));
        // Wand über Türrahmen
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        room3Uvs.Add(new Vector2(1, 1));
        room3Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> rechts
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(1.0f - ((95.0f - 42.0f - doorwayThickness) / (110.0f + wallThickness - 42.0f)), 0));
        room3Uvs.Add(new Vector2(1, wallAboveUV));
        room3Uvs.Add(new Vector2(1.0f - ((95.0f - 42.0f - doorwayThickness) / (110.0f + wallThickness - 42.0f)), wallAboveUV));
        // Wand unter Türrahmen -> links
        room3Uvs.Add(new Vector2((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f), 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f), wallAboveUV));
        room3Uvs.Add(new Vector2(0, wallAboveUV));
        // Vorderseite
        room3Uvs.Add(new Vector2(1, 0));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(1, 1));
        /*// Decke
        room3Uvs.Add(new Vector2(0, 1));
        room3Uvs.Add(new Vector2(0, 0));
        room3Uvs.Add(new Vector2(1, 1));
        room3Uvs.Add(new Vector2(1, 0));*/

        meshRoom3.uv = room3Uvs.ToArray();

        meshRoom3.RecalculateNormals();

        MeshCollider room3Collider = room3.AddComponent<MeshCollider>();
        Rigidbody room3Body = room3.AddComponent<Rigidbody>();
        room3Body.isKinematic = true;
        meshRoom3 = room3Collider.sharedMesh;

        // Raum 4
        Mesh meshRoom4 = new Mesh();
        GameObject room4 = new GameObject("Room 4", typeof(MeshFilter), typeof(MeshRenderer));
        room4.transform.parent = building.transform;

        Renderer rend4 = room4.GetComponent<Renderer>();
        rend4.material = new Material(Shader.Find("Standard"));
        meshRoom4 = room4.GetComponent<MeshFilter>().mesh;
        // Texture texture4 = Resources.Load("TextureDarkBlue") as Texture;
        Texture texture4 = MW_randomWallpaper.RandomTexture(room4);
        rend4.material.mainTexture = texture4;
        MW_randomWallpaper.wallpapers.Remove(texture4);

        meshRoom4.Clear();

        List<Vector3> room4Vertices = new List<Vector3>();
        List<int> room4Triangles = new List<int>();
        List<Vector2> room4Uvs = new List<Vector2>();

        // Wand über Türrahmen -> Eingang zu grüner Wand
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-12, height, 78));
        room4Vertices.Add(new Vector3(-12, height, 0 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room4Vertices.Add(new Vector3(-12, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-12, 0, 20));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 20));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 0 + wallThickness));
        // Wand unter Türrahmen -> links
        room4Vertices.Add(new Vector3(-12, 0, 20 + doorwayThickness));
        room4Vertices.Add(new Vector3(-12, 0, 78));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 20 + doorwayThickness));  
        // Wand über Türrahmen
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 78));
        room4Vertices.Add(new Vector3(-12, height, 78));
        // Wand über Türrahmen -> links
        room4Vertices.Add(new Vector3(-30 - doorwayThickness, 0, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-30 - doorwayThickness, height / doorwayFactor, 78));
        // Wand über Türrahmen -> rechts
        room4Vertices.Add(new Vector3(-12, 0, 78));
        room4Vertices.Add(new Vector3(-30, 0, 78));
        room4Vertices.Add(new Vector3(-30, height / doorwayFactor, 78));
        room4Vertices.Add(new Vector3(-12, height / doorwayFactor, 78));
        // Vorderseite -> zu Eingangstür -> links
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 0 + wallThickness));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 26));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 26));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 0 + wallThickness));
        // Vorderseite -> zu Eingangstür -> rechts
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 56));
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 78));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 56));
        // Eingangsbereich -> links
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 26));
        room4Vertices.Add(new Vector3(-95 + wallThickness, 0, 26));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 26));
        room4Vertices.Add(new Vector3(-95 + wallThickness, height, 26));
        // Eingangsbereich -> rechts
        room4Vertices.Add(new Vector3(-70 + wallThickness, 0, 56));
        room4Vertices.Add(new Vector3(-95 + wallThickness, 0, 56));
        room4Vertices.Add(new Vector3(-70 + wallThickness, height, 56));
        room4Vertices.Add(new Vector3(-95 + wallThickness, height, 56));
        // Wand bei Eingangstür
        room4Vertices.Add(new Vector3(-95 + wallThickness, 0, 26));
        room4Vertices.Add(new Vector3(-95 + wallThickness, 0, 56));
        room4Vertices.Add(new Vector3(-95 + wallThickness, height, 26));
        room4Vertices.Add(new Vector3(-95 + wallThickness, height, 56));
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
        /*// Decke
        room4Vertices.Add(new Vector3(-95 - wallThickness / 2, 0, 0 + wallThickness / 2));
        room4Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 0 + wallThickness / 2));
        room4Vertices.Add(new Vector3(-95 - wallThickness / 2, 0, 78 + wallThickness / 2));
        room4Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 78 + wallThickness / 2));*/

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
        // Wand über Türrahmen -> links -> 16 bis 19
        room4Triangles.Add(16);
        room4Triangles.Add(17);
        room4Triangles.Add(18);
        room4Triangles.Add(16);
        room4Triangles.Add(18);
        room4Triangles.Add(19);
        // Wand über Türrahmen -> rechts -> 20 bis 23
        room4Triangles.Add(20);
        room4Triangles.Add(21);
        room4Triangles.Add(22);
        room4Triangles.Add(20);
        room4Triangles.Add(22);
        room4Triangles.Add(23);
        // Vorderseite -> zu Eingangstür -> links -> 24 bis 27
        room4Triangles.Add(25);
        room4Triangles.Add(24);
        room4Triangles.Add(26);
        room4Triangles.Add(24);
        room4Triangles.Add(27);
        room4Triangles.Add(26);
        // Vorderseite -> zu Eingangstür -> rechts -> 28 bis 31
        room4Triangles.Add(29);
        room4Triangles.Add(28);
        room4Triangles.Add(30);
        room4Triangles.Add(28);
        room4Triangles.Add(31);
        room4Triangles.Add(30);
        // Eingangsbereich -> links -> 32 bis 35
        room4Triangles.Add(33);
        room4Triangles.Add(32);
        room4Triangles.Add(34);
        room4Triangles.Add(33);
        room4Triangles.Add(34);
        room4Triangles.Add(35);
        // Eingangsbereich -> rechts -> 36 bis 39
        room4Triangles.Add(36);
        room4Triangles.Add(37);
        room4Triangles.Add(38);
        room4Triangles.Add(37);
        room4Triangles.Add(39);
        room4Triangles.Add(38);
        // Wand bei Eingangstür -> 40 bis 43
        room4Triangles.Add(40);
        room4Triangles.Add(42);
        room4Triangles.Add(41);
        room4Triangles.Add(41);
        room4Triangles.Add(42);
        room4Triangles.Add(43);
        // Wand über Türrahmen -> 44 bis 47
        room4Triangles.Add(45);
        room4Triangles.Add(44);
        room4Triangles.Add(46);
        room4Triangles.Add(44);
        room4Triangles.Add(47);
        room4Triangles.Add(46);
        // Wand unter Türrahmen -> links -> 48 bis 51
        room4Triangles.Add(49);
        room4Triangles.Add(48);
        room4Triangles.Add(50);
        room4Triangles.Add(48);
        room4Triangles.Add(51);
        room4Triangles.Add(50);
        // Wand unter Türrahmen -> rechts -> 52 bis 55
        room4Triangles.Add(53);
        room4Triangles.Add(52);
        room4Triangles.Add(54);
        room4Triangles.Add(52);
        room4Triangles.Add(55);
        room4Triangles.Add(54);
        /*// Decke -> 56 bis 59
        room4Triangles.Add(56);
        room4Triangles.Add(57);
        room4Triangles.Add(58);
        room4Triangles.Add(59);
        room4Triangles.Add(58);
        room4Triangles.Add(57);*/

        meshRoom4.triangles = room4Triangles.ToArray();

        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(1.0f - ((20.0f - wallThickness) / (78.0f - wallThickness)), 0));
        room4Uvs.Add(new Vector2(1.0f - ((20.0f - wallThickness) / (78.0f - wallThickness)), wallAboveUV));
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2((78.0f - 20.0f - doorwayThickness) / (78.0f - wallThickness), 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        room4Uvs.Add(new Vector2((78.0f - 20.0f - doorwayThickness) / (78.0f - wallThickness), wallAboveUV));
        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2((70.0f - wallThickness - 30.0f - doorwayThickness) / (70.0f - wallThickness - 12.0f), 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        room4Uvs.Add(new Vector2((70.0f - wallThickness - 30.0f - doorwayThickness) / (70.0f - wallThickness - 12.0f), wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(1.0f - (18.0f / (70.0f - wallThickness - 12.0f)), 0));
        room4Uvs.Add(new Vector2(1.0f - (18.0f / (70.0f - wallThickness - 12.0f)), wallAboveUV));
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        // Vorderseite -> zu Eingangstür -> links
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Vorderseite -> zu Eingangstür -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Eingangsbereich -> links
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(1, 1));
        room4Uvs.Add(new Vector2(0, 1));
        // Eingangsbereich -> rechts
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(1, 1));
        room4Uvs.Add(new Vector2(0, 1));
        // Wand bei Eingangstür
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        room4Uvs.Add(new Vector2(1, 1));
        room4Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(38.0f / (70.0f - wallThickness - 12.0f), 0));
        room4Uvs.Add(new Vector2(38.0f / (70.0f - wallThickness - 12.0f), wallAboveUV));
        room4Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room4Uvs.Add(new Vector2(1.0f - ((70.0f - wallThickness - 50.0f - doorwayThickness) / (70.0f - wallThickness - 12.0f)), 0));
        room4Uvs.Add(new Vector2(1, 0));
        room4Uvs.Add(new Vector2(1, wallAboveUV));
        room4Uvs.Add(new Vector2(1.0f - ((70.0f - wallThickness - 50.0f - doorwayThickness) / (70.0f - wallThickness - 12.0f)), wallAboveUV));
        /*// Decke
        room4Uvs.Add(new Vector2(0, 1));
        room4Uvs.Add(new Vector2(0, 0));
        room4Uvs.Add(new Vector2(1, 1));
        room4Uvs.Add(new Vector2(1, 0));*/

        meshRoom4.uv = room4Uvs.ToArray();

        meshRoom4.RecalculateNormals();

        MeshCollider room4Collider = room4.AddComponent<MeshCollider>();
        Rigidbody room4Body = room4.AddComponent<Rigidbody>();
        room4Body.isKinematic = true;
        meshRoom4 = room4Collider.sharedMesh;

        // Room 5
        Mesh meshRoom5 = new Mesh();
        GameObject room5 = new GameObject("Room 5", typeof(MeshFilter), typeof(MeshRenderer));
        room5.transform.parent = building.transform;

        Renderer rend5 = room5.GetComponent<Renderer>();
        rend5.material = new Material(Shader.Find("Standard"));
        meshRoom5 = room5.GetComponent<MeshFilter>().mesh;
        // Texture texture5 = Resources.Load("TextureDarkGreen") as Texture;
        Texture texture5 = MW_randomWallpaper.RandomTexture(room5);
        rend5.material.mainTexture = texture5;
        MW_randomWallpaper.wallpapers.Remove(texture5);

        meshRoom5.Clear();

        List<Vector3> room5Vertices = new List<Vector3>();
        List<int> room5Triangles = new List<int>();
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
        // Wand über Türrahmen
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, -70 - wallThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, height, 0));
        room5Vertices.Add(new Vector3(42 - wallThickness, height, -70 - wallThickness));
        // Wand unter Türrahmen -> links
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, 0));
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, -50));
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, 0));
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, -50));
        // Wand unter Türrahmen -> rechts
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, -50 - doorwayThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, 0, -70 - wallThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, -50 - doorwayThickness));
        room5Vertices.Add(new Vector3(42 - wallThickness, height / doorwayFactor, -70 - wallThickness));
        /*// Decke
        room5Vertices.Add(new Vector3(42 - wallThickness / 2, 0, -70 - wallThickness / 2));
        room5Vertices.Add(new Vector3(-30 + wallThickness / 2, 0, 0 + wallThickness / 2));
        room5Vertices.Add(new Vector3(-30 + wallThickness / 2, 0, -70 - wallThickness / 2));
        room5Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 0 + wallThickness / 2));*/

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
        // Wand über Türrahmen -> 28 bis 31
        room5Triangles.Add(29);
        room5Triangles.Add(28);
        room5Triangles.Add(30);
        room5Triangles.Add(29);
        room5Triangles.Add(30);
        room5Triangles.Add(31);
        // Wand unter Türrahmen -> links -> 32 bis 35
        room5Triangles.Add(33);
        room5Triangles.Add(32);
        room5Triangles.Add(34);
        room5Triangles.Add(33);
        room5Triangles.Add(34);
        room5Triangles.Add(35);
        // Wand unter Türrahmen -> rechts -> 36 bis 39
        room5Triangles.Add(37);
        room5Triangles.Add(36);
        room5Triangles.Add(38);
        room5Triangles.Add(37);
        room5Triangles.Add(38);
        room5Triangles.Add(39);
        /*// Decke -> 40 bis 43
        room5Triangles.Add(40);
        room5Triangles.Add(43);
        room5Triangles.Add(42);
        room5Triangles.Add(43);
        room5Triangles.Add(41);
        room5Triangles.Add(42);*/

        meshRoom5.triangles = room5Triangles.ToArray();

        // Wand über Türrahmen
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        room5Uvs.Add(new Vector2(1, 1));
        room5Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(35.0f / 72.0f, 0));
        room5Uvs.Add(new Vector2(35.0f / 72.0f, wallAboveUV));
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room5Uvs.Add(new Vector2(1.0f - ((42.0f - 5.0f - doorwayThickness) / 72.0f), 0));
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        room5Uvs.Add(new Vector2(1.0f - ((42.0f - 5.0f - doorwayThickness) / 72.0f), wallAboveUV));
        // Wand über Türrahmen
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        room5Uvs.Add(new Vector2(1, 1));
        room5Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room5Uvs.Add(new Vector2((70.0f - 30.0f - doorwayThickness) / 70.0f, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2((70.0f - 30.0f - doorwayThickness) / 70.0f, wallAboveUV));
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(1.0f - (30.0f / 70.0f), 0));
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        room5Uvs.Add(new Vector2(1.0f - (30.0f / 70.0f), wallAboveUV));
        // Vorderseite
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand über Türrahmen
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        room5Uvs.Add(new Vector2(0, 1));
        room5Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(50.0f / (70.0f + wallThickness), 0));
        room5Uvs.Add(new Vector2(0, wallAboveUV));
        room5Uvs.Add(new Vector2(50.0f / (70.0f + wallThickness), wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room5Uvs.Add(new Vector2(1.0f - ((70.0f + wallThickness - 50.0f - doorwayThickness) / (70.0f + wallThickness)), 0));
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(1.0f - ((70.0f + wallThickness - 50.0f - doorwayThickness) / (70.0f + wallThickness)), wallAboveUV));
        room5Uvs.Add(new Vector2(1, wallAboveUV));
        /*// Decke
        room5Uvs.Add(new Vector2(1, 0));
        room5Uvs.Add(new Vector2(0, 0));
        room5Uvs.Add(new Vector2(1, 1));
        room5Uvs.Add(new Vector2(0, 1));*/

        meshRoom5.uv = room5Uvs.ToArray();

        meshRoom5.RecalculateNormals();

        MeshCollider room5Collider = room5.AddComponent<MeshCollider>();
        Rigidbody room5Body = room5.AddComponent<Rigidbody>();
        room5Body.isKinematic = true;
        meshRoom5 = room5Collider.sharedMesh;

        // Room 6
        Mesh meshRoom6 = new Mesh();
        GameObject room6 = new GameObject("Room 6", typeof(MeshFilter), typeof(MeshRenderer));
        room6.transform.parent = building.transform;

        Renderer rend6 = room6.GetComponent<Renderer>();
        rend6.material = new Material(Shader.Find("Standard"));
        meshRoom6 = room6.GetComponent<MeshFilter>().mesh;
        Texture texture6 = MW_randomWallpaper.RandomTexture(room6);
        rend6.material.mainTexture = texture6;
        MW_randomWallpaper.wallpapers.Remove(texture6);

        meshRoom6.Clear();

        List<Vector3> room6Vertices = new List<Vector3>();
        List<int> room6Triangles = new List<int>();
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
        /*// Decke
        room6Vertices.Add(new Vector3(-30 + wallThickness / 2, 0, -70 + wallThickness / 2));
        room6Vertices.Add(new Vector3(-70 + wallThickness / 2, 0, 0 + wallThickness / 2));
        room6Vertices.Add(new Vector3(-30 + wallThickness / 2, 0, 0 + wallThickness / 2));
        room6Vertices.Add(new Vector3(-70 + wallThickness / 2, 0, -70 + wallThickness / 2));*/

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
        /*// Decke -> 32 bis 35
        room6Triangles.Add(32);
        room6Triangles.Add(34);
        room6Triangles.Add(33);
        room6Triangles.Add(33);
        room6Triangles.Add(35);
        room6Triangles.Add(32);*/

        meshRoom6.triangles = room6Triangles.ToArray();

        // Wand über Türrahmen
        room6Uvs.Add(new Vector2(1, wallAboveUV));
        room6Uvs.Add(new Vector2(0, wallAboveUV));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> rechts
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(1.0f - (20.0f / 40.0f), 0));
        room6Uvs.Add(new Vector2(1.0f - (20.0f / 40.0f), wallAboveUV));
        room6Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand unter Türrahmen -> links
        room6Uvs.Add(new Vector2((70.0f - 50.0f - doorwayThickness) / 40.0f, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, wallAboveUV));
        room6Uvs.Add(new Vector2((70.0f - 50.0f - doorwayThickness) / 40.0f, wallAboveUV));
        // Wand über Türrahmen
        room6Uvs.Add(new Vector2(0, wallAboveUV));
        room6Uvs.Add(new Vector2(1, wallAboveUV));
        room6Uvs.Add(new Vector2(1, 1));
        room6Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(30.0f / (70.0f + wallThickness), 0));
        room6Uvs.Add(new Vector2(30.0f / (70.0f + wallThickness), wallAboveUV));
        room6Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room6Uvs.Add(new Vector2(1.0f - ((70.0f + wallThickness - 30.0f - doorwayThickness) / (70.0f + wallThickness)), 0));
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(1, wallAboveUV));
        room6Uvs.Add(new Vector2(1.0f - ((70.0f + wallThickness - 30.0f - doorwayThickness) / (70.0f + wallThickness)), wallAboveUV));
        // Vorderseite
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(1, 1));
        room6Uvs.Add(new Vector2(0, 1));
        // Vorderseite
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(1, 1));
        /*// Decke
        room6Uvs.Add(new Vector2(1, 0));
        room6Uvs.Add(new Vector2(0, 1));
        room6Uvs.Add(new Vector2(0, 0));
        room6Uvs.Add(new Vector2(1, 1));*/

        meshRoom6.uv = room6Uvs.ToArray();

        meshRoom6.RecalculateNormals();

        MeshCollider room6Collider = room6.AddComponent<MeshCollider>();
        Rigidbody room6Body = room6.AddComponent<Rigidbody>();
        room6Body.isKinematic = true;
        meshRoom6 = room6Collider.sharedMesh;

        // Room 7
        Mesh meshRoom7 = new Mesh();
        GameObject room7 = new GameObject("Room 7", typeof(MeshFilter), typeof(MeshRenderer));
        room7.transform.parent = building.transform;

        Renderer rend7 = room7.GetComponent<Renderer>();
        rend7.material = new Material(Shader.Find("Standard"));
        meshRoom7 = room7.GetComponent<MeshFilter>().mesh;
        // Texture texture7 = Resources.Load("TextureGreen") as Texture;
        Texture texture7 = MW_randomWallpaper.RandomTexture(room7);
        rend7.material.mainTexture = texture7;
        MW_randomWallpaper.wallpapers.Remove(texture7);

        meshRoom7.Clear();

        List<Vector3> room7Vertices = new List<Vector3>();
        List<int> room7Triangles = new List<int>();
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
        /*// Decke
        room7Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 78 + wallThickness / 2));
        room7Vertices.Add(new Vector3(-70 - wallThickness / 2, 0, 78 + wallThickness / 2));
        room7Vertices.Add(new Vector3(-12 + wallThickness / 2, 0, 130 + wallThickness / 2));
        room7Vertices.Add(new Vector3(-70 - wallThickness / 2, 0, 130 + wallThickness / 2));*/

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
        /*// Decke -> 32 bis 35
        room7Triangles.Add(32);
        room7Triangles.Add(34);
        room7Triangles.Add(33);
        room7Triangles.Add(35);
        room7Triangles.Add(33);
        room7Triangles.Add(34);*/

        meshRoom7.triangles = room7Triangles.ToArray();

        // Wand über Türrahmen
        room7Uvs.Add(new Vector2(1, wallAboveUV));
        room7Uvs.Add(new Vector2(0, wallAboveUV));
        room7Uvs.Add(new Vector2(1, 1));
        room7Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> rechts
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(1.0f - ((100.0f - 78.0f - wallThickness) / (130.0f- 78.0f)), 0));
        room7Uvs.Add(new Vector2(1, wallAboveUV));
        room7Uvs.Add(new Vector2(1.0f - ((100.0f - 78.0f - wallThickness) / (130.0f- 78.0f)), wallAboveUV));
        // Wand unter Türrahmen -> links
        room7Uvs.Add(new Vector2((130.0f + wallThickness - 100.0f - doorwayThickness) / (130.0f- 78.0f), 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2((130.0f + wallThickness - 100.0f - doorwayThickness) / (130.0f- 78.0f), wallAboveUV));
        room7Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand über Türrahmen
        room7Uvs.Add(new Vector2(0, wallAboveUV));
        room7Uvs.Add(new Vector2(1, wallAboveUV));
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(18.0f / 58.0f, 0));
        room7Uvs.Add(new Vector2(0, wallAboveUV));
        room7Uvs.Add(new Vector2(18.0f / 58.0f, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room7Uvs.Add(new Vector2(1.0f - ((70.0f - 30.0f - doorwayThickness) / 58.0f), 0));
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(1.0f - ((70.0f - 30.0f - doorwayThickness) / 58.0f), wallAboveUV));
        room7Uvs.Add(new Vector2(1, wallAboveUV));
        // Vorderseite
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(1, 1));
        room7Uvs.Add(new Vector2(0, 1));
        // Vorderseite
        room7Uvs.Add(new Vector2(1, 0));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(1, 1));
        room7Uvs.Add(new Vector2(0, 1));
        /*// Decke
        room7Uvs.Add(new Vector2(0, 1));
        room7Uvs.Add(new Vector2(0, 0));
        room7Uvs.Add(new Vector2(1, 1));
        room7Uvs.Add(new Vector2(1, 0));*/

        meshRoom7.uv = room7Uvs.ToArray();

        meshRoom7.RecalculateNormals();

        MeshCollider room7Collider = room7.AddComponent<MeshCollider>();
        Rigidbody room7Body = room7.AddComponent<Rigidbody>();
        room7Body.isKinematic = true;
        meshRoom7 = room7Collider.sharedMesh;

        // Room 8
        Mesh meshRoom8 = new Mesh();
        GameObject room8 = new GameObject("Room 8", typeof(MeshFilter), typeof(MeshRenderer));
        room8.transform.parent = building.transform;

        Renderer rend8 = room8.GetComponent<Renderer>();
        rend8.material = new Material(Shader.Find("Standard"));
        meshRoom8 = room8.GetComponent<MeshFilter>().mesh;
        // Texture texture8 = Resources.Load("TextureDarkGreen") as Texture;
        Texture texture8 = MW_randomWallpaper.RandomTexture(room8);
        rend8.material.mainTexture = texture8;
        MW_randomWallpaper.wallpapers.Remove(texture8);

        meshRoom8.Clear();

        List<Vector3> room8Vertices = new List<Vector3>();
        List<int> room8Triangles = new List<int>();
        List<Vector2> room8Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 130));
        room8Vertices.Add(new Vector3(60 + wallThickness, height, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, height, 130));
        // Wand unter Türrahmen -> links
        room8Vertices.Add(new Vector3(60 + wallThickness, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, 0, 70));
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 70));
        // Wand unter Türrahmen -> rechts
        room8Vertices.Add(new Vector3(60 + wallThickness, 0, 70 + doorwayThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, 0, 130));
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 70 + doorwayThickness));
        room8Vertices.Add(new Vector3(60 + wallThickness, height / doorwayFactor, 130));
        // Wand über Türrahmen
        room8Vertices.Add(new Vector3(60, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60, height, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, height, 48 + wallThickness));
        // Wand unter Türrahmen -> links
        room8Vertices.Add(new Vector3(95, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(95, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, height / doorwayFactor, 48 + wallThickness));
        // Wand unter Türrahmen -> rechts
        room8Vertices.Add(new Vector3(60, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(95 - doorwayThickness, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(60, height / doorwayFactor, 48 + wallThickness));
        room8Vertices.Add(new Vector3(95 - doorwayThickness, height / doorwayFactor, 48 + wallThickness));
        // Vorderseite
        room8Vertices.Add(new Vector3(110, 0, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, 0, 130));
        room8Vertices.Add(new Vector3(110, height, 48 + wallThickness));
        room8Vertices.Add(new Vector3(110, height, 130));
        // Vorderseite
        room8Vertices.Add(new Vector3(60, 0, 130));
        room8Vertices.Add(new Vector3(110, 0, 130));
        room8Vertices.Add(new Vector3(60, height, 130));
        room8Vertices.Add(new Vector3(110, height, 130));
        /*// Decke
        room8Vertices.Add(new Vector3(60 + wallThickness / 2, 0, 50 - wallThickness / 2));
        room8Vertices.Add(new Vector3(110 + wallThickness / 2, 0, 50 - wallThickness / 2));
        room8Vertices.Add(new Vector3(60 + wallThickness / 2, 0, 130 + wallThickness / 2));
        room8Vertices.Add(new Vector3(110 + wallThickness / 2, 0, 130 + wallThickness / 2));*/

        meshRoom8.vertices = room8Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room8Triangles.Add(0);
        room8Triangles.Add(3);
        room8Triangles.Add(1);
        room8Triangles.Add(0);
        room8Triangles.Add(2);
        room8Triangles.Add(3);
        // Wand unter Türrahmen -> links -> 4 bis 7
        room8Triangles.Add(4);
        room8Triangles.Add(7);
        room8Triangles.Add(5);
        room8Triangles.Add(4);
        room8Triangles.Add(6);
        room8Triangles.Add(7);
        // Wand unter Türrahmen -> rechts -> 8 bis 11
        room8Triangles.Add(8);
        room8Triangles.Add(11);
        room8Triangles.Add(9);
        room8Triangles.Add(8);
        room8Triangles.Add(10);
        room8Triangles.Add(11);
        // Wand über Türrahmen -> 12 bis 15
        room8Triangles.Add(12);
        room8Triangles.Add(13);
        room8Triangles.Add(15);
        room8Triangles.Add(12);
        room8Triangles.Add(15);
        room8Triangles.Add(14);
        // Wand unter Türrahmen -> links -> 16 bis 19
        room8Triangles.Add(16);
        room8Triangles.Add(17);
        room8Triangles.Add(19);
        room8Triangles.Add(16);
        room8Triangles.Add(19);
        room8Triangles.Add(18);
        // Wand unter Türrahmen -> rechts -> 20 bis 23
        room8Triangles.Add(20);
        room8Triangles.Add(21);
        room8Triangles.Add(23);
        room8Triangles.Add(20);
        room8Triangles.Add(23);
        room8Triangles.Add(22);
        // Vorderseite -> 24 bis 27
        room8Triangles.Add(24);
        room8Triangles.Add(25);
        room8Triangles.Add(27);
        room8Triangles.Add(24);
        room8Triangles.Add(27);
        room8Triangles.Add(26);
        // Vorderseite -> 28 bis 31
        room8Triangles.Add(29);
        room8Triangles.Add(28);
        room8Triangles.Add(31);
        room8Triangles.Add(28);
        room8Triangles.Add(30);
        room8Triangles.Add(31);
        /*// Decke -> 32 bis 35
        room8Triangles.Add(32);
        room8Triangles.Add(35);
        room8Triangles.Add(34);
        room8Triangles.Add(32);
        room8Triangles.Add(33);
        room8Triangles.Add(35);*/

        meshRoom8.triangles = room8Triangles.ToArray();

        // Wand über Türrahmen
        room8Uvs.Add(new Vector2(0, wallAboveUV));
        room8Uvs.Add(new Vector2(1, wallAboveUV));
        room8Uvs.Add(new Vector2(0, 1));
        room8Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room8Uvs.Add(new Vector2(0, 0));
        room8Uvs.Add(new Vector2((70.0f - 48.0f - wallThickness) / (130.0f - 48.0f - wallThickness), 0));
        room8Uvs.Add(new Vector2(0, wallAboveUV));
        room8Uvs.Add(new Vector2((70.0f - 48.0f - wallThickness) / (130.0f - 48.0f - wallThickness), wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room8Uvs.Add(new Vector2(1.0f - ((130.0f - 70.0f - doorwayThickness) / (130.0f - 48.0f - wallThickness)), 0));
        room8Uvs.Add(new Vector2(1, 0));
        room8Uvs.Add(new Vector2(1.0f - ((130.0f - 70.0f - doorwayThickness) / (130.0f - 48.0f - wallThickness)), wallAboveUV));
        room8Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand über Türrahmen
        room8Uvs.Add(new Vector2(1, wallAboveUV));
        room8Uvs.Add(new Vector2(0, wallAboveUV));
        room8Uvs.Add(new Vector2(1, 1));
        room8Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> links
        room8Uvs.Add(new Vector2(15.0f / 50.0f, 0));
        room8Uvs.Add(new Vector2(0, 0));
        room8Uvs.Add(new Vector2(15.0f / 50.0f, wallAboveUV));
        room8Uvs.Add(new Vector2(0, wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room8Uvs.Add(new Vector2(1, 0));
        room8Uvs.Add(new Vector2(1.0f - ((95.0f - doorwayThickness - 60.0f) / 50.0f), 0));
        room8Uvs.Add(new Vector2(1, wallAboveUV));
        room8Uvs.Add(new Vector2(1.0f - ((95.0f - doorwayThickness - 60.0f) / 50.0f), wallAboveUV));
        // Vorderseite
        room8Uvs.Add(new Vector2(1, 0));
        room8Uvs.Add(new Vector2(0, 0));
        room8Uvs.Add(new Vector2(1, 1));
        room8Uvs.Add(new Vector2(0, 1));
        // Vorderseite
        room8Uvs.Add(new Vector2(1, 0));
        room8Uvs.Add(new Vector2(0, 0));
        room8Uvs.Add(new Vector2(1, 1));
        room8Uvs.Add(new Vector2(0, 1));
        /*// Decke
        room8Uvs.Add(new Vector2(0, 1));
        room8Uvs.Add(new Vector2(0, 0));
        room8Uvs.Add(new Vector2(1, 1));
        room8Uvs.Add(new Vector2(1, 0));*/

        meshRoom8.uv = room8Uvs.ToArray();

        meshRoom8.RecalculateNormals();

        MeshCollider room8Collider = room8.AddComponent<MeshCollider>();
        Rigidbody room8Body = room8.AddComponent<Rigidbody>();
        room8Body.isKinematic = true;
        meshRoom8 = room8Collider.sharedMesh;

        // Room 9
        Mesh meshRoom9 = new Mesh();
        GameObject room9 = new GameObject("Room 9", typeof(MeshFilter), typeof(MeshRenderer));
        room9.transform.parent = building.transform;

        Renderer rend9 = room9.GetComponent<Renderer>();
        rend9.material = new Material(Shader.Find("Standard"));
        meshRoom9 = room9.GetComponent<MeshFilter>().mesh;
        // Texture texture9 = Resources.Load("TextureDarkBlue") as Texture;
        texture9 = MW_randomWallpaper.RandomTexture(room9);
        rend9.material.mainTexture = texture9;
        MW_randomWallpaper.wallpapers.Remove(texture9);

        meshRoom9.Clear();

        List<Vector3> room9Vertices = new List<Vector3>();
        List<int> room9Triangles = new List<int>();
        List<Vector2> room9Uvs = new List<Vector2>();

        // Wand über Türrahmen
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, 0));
        room9Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 0));
        room9Vertices.Add(new Vector3(42, height, 0));
        room9Vertices.Add(new Vector3(110 + wallThickness, height, 0));
        // Wand unter Türrahmen -> links
        room9Vertices.Add(new Vector3(42, 0, 0));
        room9Vertices.Add(new Vector3(95 - doorwayThickness, 0, 0));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, 0));
        room9Vertices.Add(new Vector3(95 - doorwayThickness, height / doorwayFactor, 0));
        // Wand unter Türrahmen -> rechts
        room9Vertices.Add(new Vector3(95, 0, 0));
        room9Vertices.Add(new Vector3(110 + wallThickness, 0, 0));
        room9Vertices.Add(new Vector3(95, height / doorwayFactor, 0));
        room9Vertices.Add(new Vector3(110 + wallThickness, height / doorwayFactor, 0));
        // Wand über Türrahmen
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, -70 - wallThickness));
        room9Vertices.Add(new Vector3(42, height, 0 + wallThickness));
        room9Vertices.Add(new Vector3(42, height, -70 - wallThickness));
        // Wand unter Türrahmen -> rechts
        room9Vertices.Add(new Vector3(42, 0, 0 + wallThickness));
        room9Vertices.Add(new Vector3(42, 0, -50));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, 0 + wallThickness));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, -50));
        // Wand unter Türrahmen -> links
        room9Vertices.Add(new Vector3(42, 0, -50 - doorwayThickness));
        room9Vertices.Add(new Vector3(42, 0, -70 - wallThickness));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, -50 - doorwayThickness));
        room9Vertices.Add(new Vector3(42, height / doorwayFactor, -70 - wallThickness));
        // Vorderseite
        room9Vertices.Add(new Vector3(42, 0, -70 + wallThickness));
        room9Vertices.Add(new Vector3(110 + wallThickness, 0, -70 + wallThickness));
        room9Vertices.Add(new Vector3(42, height, -70 + wallThickness));
        room9Vertices.Add(new Vector3(110 + wallThickness, height, -70 + wallThickness));
        // Vorderseite
        room9Vertices.Add(new Vector3(110, 0, 0 + wallThickness));
        room9Vertices.Add(new Vector3(110, 0, -70 - wallThickness));
        room9Vertices.Add(new Vector3(110, height, 0 + wallThickness));
        room9Vertices.Add(new Vector3(110, height, -70 - wallThickness));
        /*// Decke
        room9Vertices.Add(new Vector3(42 - wallThickness / 2, 0, 0 + wallThickness / 2));
        room9Vertices.Add(new Vector3(42 - wallThickness / 2, 0, -70 - wallThickness / 2));
        room9Vertices.Add(new Vector3(110 + wallThickness / 2, 0, -70 - wallThickness / 2));
        room9Vertices.Add(new Vector3(110 + wallThickness / 2, 0, 0 + wallThickness / 2));*/

        meshRoom9.vertices = room9Vertices.ToArray();

        // Wand über Türrahmen -> 0 bis 3
        room9Triangles.Add(0);
        room9Triangles.Add(3);
        room9Triangles.Add(1);
        room9Triangles.Add(0);
        room9Triangles.Add(2);
        room9Triangles.Add(3);
        // Wand unter Türrahmen -> links -> 4 bis 7
        room9Triangles.Add(4);
        room9Triangles.Add(7);
        room9Triangles.Add(5);
        room9Triangles.Add(4);
        room9Triangles.Add(6);
        room9Triangles.Add(7);
        // Wand unter Türrahmen -> rechts -> 8 bis 11
        room9Triangles.Add(8);
        room9Triangles.Add(11);
        room9Triangles.Add(9);
        room9Triangles.Add(8);
        room9Triangles.Add(10);
        room9Triangles.Add(11);
        // Wand über Türrahmen -> 12 bis 15
        room9Triangles.Add(12);
        room9Triangles.Add(13);
        room9Triangles.Add(15);
        room9Triangles.Add(12);
        room9Triangles.Add(15);
        room9Triangles.Add(14);
        // Wand unter Türrahmen -> rechts -> 16 bis 19
        room9Triangles.Add(16);
        room9Triangles.Add(17);
        room9Triangles.Add(19);
        room9Triangles.Add(16);
        room9Triangles.Add(19);
        room9Triangles.Add(18);
        // Wand unter Türrahmen -> links -> 20 bis 23
        room9Triangles.Add(20);
        room9Triangles.Add(21);
        room9Triangles.Add(23);
        room9Triangles.Add(20);
        room9Triangles.Add(23);
        room9Triangles.Add(22);
        // Vorderseite -> 24 bis 27
        room9Triangles.Add(24);
        room9Triangles.Add(25);
        room9Triangles.Add(27);
        room9Triangles.Add(24);
        room9Triangles.Add(27);
        room9Triangles.Add(26);
        // Vorderseite -> 28 bis 31
        room9Triangles.Add(29);
        room9Triangles.Add(28);
        room9Triangles.Add(31);
        room9Triangles.Add(28);
        room9Triangles.Add(30);
        room9Triangles.Add(31);
        /*// Decke -> 32 bis 35
        room9Triangles.Add(32);
        room9Triangles.Add(33);
        room9Triangles.Add(34);
        room9Triangles.Add(32);
        room9Triangles.Add(34);
        room9Triangles.Add(35);*/

        meshRoom9.triangles = room9Triangles.ToArray();

        // Wand über Türrahmen
        room9Uvs.Add(new Vector2(0, wallAboveUV));
        room9Uvs.Add(new Vector2(1, wallAboveUV));
        room9Uvs.Add(new Vector2(0, 1));
        room9Uvs.Add(new Vector2(1, 1));
        // Wand unter Türrahmen -> links
        room9Uvs.Add(new Vector2(0, 0));
        room9Uvs.Add(new Vector2((95.0f - doorwayThickness - 42.0f) / (110.0f + wallThickness - 42.0f), 0));
        room9Uvs.Add(new Vector2(0, wallAboveUV));
        room9Uvs.Add(new Vector2((95.0f - doorwayThickness - 42.0f) / (110.0f + wallThickness - 42.0f), wallAboveUV));
        // Wand unter Türrahmen -> rechts
        room9Uvs.Add(new Vector2(1.0f - ((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f)), 0));
        room9Uvs.Add(new Vector2(1, 0));
        room9Uvs.Add(new Vector2(1.0f - ((110.0f + wallThickness - 95.0f) / (110.0f + wallThickness - 42.0f)), wallAboveUV));
        room9Uvs.Add(new Vector2(1, wallAboveUV));
        // Wand über Türrahmen
        room9Uvs.Add(new Vector2(1, wallAboveUV));
        room9Uvs.Add(new Vector2(0, wallAboveUV));
        room9Uvs.Add(new Vector2(1, 1));
        room9Uvs.Add(new Vector2(0, 1));
        // Wand unter Türrahmen -> rechts
        room9Uvs.Add(new Vector2(1, 0));
        room9Uvs.Add(new Vector2(1.0f - ((50.0f + wallThickness) / (70.0f + wallThickness + wallThickness)), 0));
        room9Uvs.Add(new Vector2(1, wallAboveUV));
        room9Uvs.Add(new Vector2(1.0f - ((50.0f + wallThickness) / (70.0f + wallThickness + wallThickness)), wallAboveUV));
        // Wand unter Türrahmen -> links
        room9Uvs.Add(new Vector2((70.0f + wallThickness - 50.0f - doorwayThickness) / (70.0f + wallThickness + wallThickness), 0));
        room9Uvs.Add(new Vector2(0, 0));
        room9Uvs.Add(new Vector2((70.0f + wallThickness - 50.0f - doorwayThickness) / (70.0f + wallThickness + wallThickness), wallAboveUV));
        room9Uvs.Add(new Vector2(0, wallAboveUV));
        // Vorderseite
        room9Uvs.Add(new Vector2(1, 0));
        room9Uvs.Add(new Vector2(0, 0));
        room9Uvs.Add(new Vector2(1, 1));
        room9Uvs.Add(new Vector2(0, 1));
        // Vorderseite
        room9Uvs.Add(new Vector2(1, 0));
        room9Uvs.Add(new Vector2(0, 0));
        room9Uvs.Add(new Vector2(1, 1));
        room9Uvs.Add(new Vector2(0, 1));
        /*// Decke
        room9Uvs.Add(new Vector2(1, 0));
        room9Uvs.Add(new Vector2(0, 0));
        room9Uvs.Add(new Vector2(0, 1));
        room9Uvs.Add(new Vector2(1, 1));*/

        meshRoom9.uv = room9Uvs.ToArray();

        meshRoom9.RecalculateNormals();

        MeshCollider room9Collider = room9.AddComponent<MeshCollider>();
        Rigidbody room9Body = room9.AddComponent<Rigidbody>();
        room9Body.isKinematic = true;
        meshRoom9 = room9Collider.sharedMesh;
    }


    // Empty für alle Türrahmen
    static GameObject doorways = new GameObject("Doorways");
    // zähle Türrahmen beim Erstellen hoch -> Doorway 1, Doorway 2, ...
    static int countDoorways = 0;

    /* FUNKTION, DIE EINEN TÜRRAHMEN ERSTELLT */
    static void CreateDoorway(float posX, float posZ, bool rotate) {
        countDoorways++;

        Mesh meshDoorway = new Mesh();
        GameObject doorway = new GameObject("Doorway " + countDoorways, typeof(MeshFilter), typeof(MeshRenderer));
        // füge doorways zum Empty "Building"
        doorway.transform.parent = building.transform;

        Renderer rend = doorway.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Standard"));
        meshDoorway = doorway.GetComponent<MeshFilter>().mesh;
        Texture texture = Resources.Load("WoodDoorway") as Texture;
        rend.material.mainTexture = texture;
        // doorway.GetComponent<Renderer>().material = woodDoorway;

        meshDoorway.Clear();

        List<Vector3> doorwayVertices = new List<Vector3>();
        List<int> doorwayTriangles = new List<int>();
        List<Vector2> doorwayUvs = new List<Vector2>();

        // doorwayThickness / 2 und -doorwayThickness / 2 werden genutzt, damit Empty direkt in der Mitte liegt
        // ... macht die Drehung der Türrahmen leichter
        // oben
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, height / doorwayFactor, -wallThickness));
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, height / doorwayFactor, -wallThickness));
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, height / doorwayFactor, 0));
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, height / doorwayFactor, 0));
        // links
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, 0,  -wallThickness));
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, height / doorwayFactor,  -wallThickness));
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, 0,  0));
        doorwayVertices.Add(new Vector3(-doorwayThickness / 2, height / doorwayFactor,  0));
        // rechts
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, 0,  -wallThickness));
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, height / doorwayFactor,  -wallThickness));
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, 0,  0));
        doorwayVertices.Add(new Vector3(doorwayThickness / 2, height / doorwayFactor,  0));

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

        meshDoorway.triangles = doorwayTriangles.ToArray();

        // Eingang grün zu lila
        // oben
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(1, 1));
        doorwayUvs.Add(new Vector2(1, 0));
        // links
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(1, 1));
        doorwayUvs.Add(new Vector2(1, 0));
        // rechts
        doorwayUvs.Add(new Vector2(0, 1));
        doorwayUvs.Add(new Vector2(0, 0));
        doorwayUvs.Add(new Vector2(1, 1));
        doorwayUvs.Add(new Vector2(1, 0));

        meshDoorway.uv = doorwayUvs.ToArray();

        meshDoorway.RecalculateNormals();

        MeshCollider doorwayCollider = doorway.AddComponent<MeshCollider>();
        Rigidbody doorwayBody = doorway.AddComponent<Rigidbody>();
        doorwayBody.isKinematic = true;
        meshDoorway = doorwayCollider.sharedMesh;

        // wenn Türrahmen im Gegensatz zum "Standard"-Türrahmen gedreht werden muss, wird true angegeben
        if (rotate == true) {
            doorway.transform.Rotate(0, 90, 0);
        }
        // schiebe Türrahmen auf richtige Position
        doorway.transform.position = new Vector3(posX, 0, posZ);
        // Empty doorways wird zu building hinzugefügt
        doorways.transform.parent = building.transform;
        // einzelne Türrahmen werden zum Empty doorways hinzugefügt
        doorway.transform.parent = doorways.transform;
    }

    /*FUNKTION, DIE ALLE TÜRRAHMEN ERSTELLT*/
    static void CreateAllDoorways() {
        CreateDoorway(22.0f + doorwayThickness / 2, 50.0f, false);
        CreateDoorway(42.0f, 20.0f + doorwayThickness / 2, true);
        CreateDoorway(-12.0f + wallThickness, 20.0f + doorwayThickness / 2, true);
        CreateDoorway(5.0f + doorwayThickness / 2, 0.0f + wallThickness, false);
        CreateDoorway(-50.0f - doorwayThickness / 2, 0.0f + wallThickness, false);
        CreateDoorway(-30.0f + wallThickness, -30.0f - doorwayThickness / 2, true);
        CreateDoorway(-12.0f + wallThickness, 100.0f + doorwayThickness / 2, true);
        CreateDoorway(-30.0f - doorwayThickness / 2, 78.0f + wallThickness, false);
        CreateDoorway(60.0f + wallThickness, 70.0f + doorwayThickness / 2, true);
        CreateDoorway(95.0f - doorwayThickness / 2, 48.0f + wallThickness, false);
        CreateDoorway(95.0f - doorwayThickness / 2, 0.0f + wallThickness, false);
        CreateDoorway(42.0f, -50.0f - doorwayThickness / 2, true);
    }

    /* FUNKTION, DIE EINGANGSTÜR ERSTELLT */
    static void CreateFrontDoor() {
        Mesh meshDoor = new Mesh();
        GameObject door = new GameObject("Front Door", typeof(MeshFilter), typeof(MeshRenderer));
        // füge door zum Empty "Building"
        door.transform.parent = building.transform;

        Renderer rend = door.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Standard"));
        Texture texture = Resources.Load("FrontDoor") as Texture;
        rend.material.mainTexture = texture;

        meshDoor = door.GetComponent<MeshFilter>().mesh;
        meshDoor.Clear();

        List<Vector3> doorVertices = new List<Vector3>();
        List<int> doorTriangles = new List<int>();
        List<Vector2> doorUvs = new List<Vector2>();

        // Wie weit reicht Eingangstür in Szene hinein, sodass sie ein wenig Tiefe besitzt
        float doorDepth = 0.5f;

        // Wie viel höher ist Eingangstür im Vergleich zu den "normalen" Durchgängen
        float doorHeight = 4.0f;

        // Wie viel breiter ist Eingangstür im Vergleich zu den "normalen" Durchgängen
        float doorThickness = 6.0f;

        // Eingangstür
        // 26 + ((30 - doorwayThickness - doorThickness) / 2)) und 26 + ((30 + doorwayThickness + doorThickness) / 2)) sorgen dafür, dass ...
        // ... die Tür immer in der Mitte des Raumes steht, auch wenn man die Variable doorThickness ändert
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, 0, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, 0, 26 + ((30 + doorwayThickness + doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 + doorwayThickness + doorThickness) / 2)));

        // Seite oben
        doorVertices.Add(new Vector3(-95 + wallThickness, height / doorwayFactor + doorHeight, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness, height / doorwayFactor + doorHeight, 26 + ((30 + doorwayThickness + doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 + doorwayThickness + doorThickness) / 2)));

        // Seite rechts
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, 0, 26 + ((30 + doorwayThickness + doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness, 0, 26 + ((30 + doorwayThickness + doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 + doorwayThickness + doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness, height / doorwayFactor + doorHeight, 26 + ((30 + doorwayThickness + doorThickness) / 2)));

        // Seite links
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, 0, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness, 0, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness + doorDepth, height / doorwayFactor + doorHeight, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        doorVertices.Add(new Vector3(-95 + wallThickness, height / doorwayFactor + doorHeight, 26 + ((30 - doorwayThickness - doorThickness) / 2)));
        
        meshDoor.vertices = doorVertices.ToArray();

        // Einganstür -> 0 bis 3
        doorTriangles.Add(1);
        doorTriangles.Add(0);
        doorTriangles.Add(2);
        doorTriangles.Add(3);
        doorTriangles.Add(1);
        doorTriangles.Add(2);

        // Seite oben -> 4 bis 7
        doorTriangles.Add(4);
        doorTriangles.Add(5);
        doorTriangles.Add(6);
        doorTriangles.Add(6);
        doorTriangles.Add(5);
        doorTriangles.Add(7);

        // Seite rechts -> 8 bis 11
        doorTriangles.Add(8);
        doorTriangles.Add(10);
        doorTriangles.Add(9);
        doorTriangles.Add(9);
        doorTriangles.Add(10);
        doorTriangles.Add(11);

        // Seite links -> 12 bis 15
        doorTriangles.Add(12);
        doorTriangles.Add(13);
        doorTriangles.Add(14);
        doorTriangles.Add(13);
        doorTriangles.Add(15);
        doorTriangles.Add(14);
        
        meshDoor.triangles = doorTriangles.ToArray();

        // Eingangstür
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(1, 0));
        doorUvs.Add(new Vector2(0, 1));
        doorUvs.Add(new Vector2(1, 1));

        // alle UV-Werte der Seiten bekommen Wert 0, sodass sie die dunklere Farbe bekommen
        // dunklere Farbe -> dunkleres Braun, mit dem Muster umrandet sind
        // Seite oben
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));

        // Seite rechts
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));

        // Seite links
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        doorUvs.Add(new Vector2(0, 0));
        
        meshDoor.uv = doorUvs.ToArray();

        // wird zusätzlich benötigt, damit Material sichtbar wird
        //meshGround.normals = new Vector3[] {new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0)};
        meshDoor.RecalculateNormals(); // berechnet Normalen automatisch

        // MeshCollider erst hinzufügen, nachdem Mesh kreiert wurde, ansonsten macht der Collider gar nichts, da kein Mesh zugewiesen wird
        MeshCollider doorCollider = door.AddComponent<MeshCollider>();
        meshDoor = doorCollider.sharedMesh;
    }


    /* FUNKTION, DIE ZWISCHENWÄNDE ERSTELLT */
    static void CreateDividingWall() {
        float wallFactor = 3.75f;
        float upUV = (height / wallFactor) / height;

        Mesh meshWall1 = new Mesh();
        GameObject wall1 = new GameObject("Dividing Wall Room 2 (1)", typeof(MeshFilter), typeof(MeshRenderer));
        // füge wall1 zum Empty "Building"
        wall1.transform.parent = building.transform;

        Renderer rend1 = wall1.GetComponent<Renderer>();
        rend1.material = new Material(Shader.Find("Standard"));
        // Texture texture1 = Resources.Load("TexturePurple") as Texture;
        rend1.material.mainTexture = texture2;

        meshWall1 = wall1.GetComponent<MeshFilter>().mesh;
        meshWall1.Clear();

        List<Vector3> wall1Vertices = new List<Vector3>();
        List<int> wall1Triangles = new List<int>();
        List<Vector2> wall1Uvs = new List<Vector2>();

        // Seite
        wall1Vertices.Add(new Vector3(-0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(-0.5f, height / wallFactor, 29 - wallThickness));
        wall1Vertices.Add(new Vector3(-0.5f, 0, -27));
        wall1Vertices.Add(new Vector3(-0.5f, 0, 29 - wallThickness));
        // Seite
        wall1Vertices.Add(new Vector3(0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(0.5f, height / wallFactor, 29 - wallThickness));
        wall1Vertices.Add(new Vector3(0.5f, 0, -27));
        wall1Vertices.Add(new Vector3(0.5f, 0, 29 - wallThickness));
        // zwischen den Seiten
        wall1Vertices.Add(new Vector3(-0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(-0.5f, 0, -27));
        wall1Vertices.Add(new Vector3(0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(0.5f, 0, -27));
        // oben
        wall1Vertices.Add(new Vector3(-0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(-0.5f, height / wallFactor, 29 - wallThickness));
        wall1Vertices.Add(new Vector3(0.5f, height / wallFactor, -27));
        wall1Vertices.Add(new Vector3(0.5f, height / wallFactor, 29 - wallThickness));

        meshWall1.vertices = wall1Vertices.ToArray();

        // Seite -> 0 bis 3
        wall1Triangles.Add(1);
        wall1Triangles.Add(0);
        wall1Triangles.Add(2);
        wall1Triangles.Add(3);
        wall1Triangles.Add(1);
        wall1Triangles.Add(2);

        // Seite -> 4 bis 7
        wall1Triangles.Add(4);
        wall1Triangles.Add(5);
        wall1Triangles.Add(6);
        wall1Triangles.Add(7);
        wall1Triangles.Add(6);
        wall1Triangles.Add(5);

        // zwischen den Seiten -> 8 bis 11
        wall1Triangles.Add(9);
        wall1Triangles.Add(8);
        wall1Triangles.Add(10);
        wall1Triangles.Add(11);
        wall1Triangles.Add(9);
        wall1Triangles.Add(10);

        // oben -> 12 bis 15
        wall1Triangles.Add(12);
        wall1Triangles.Add(13);
        wall1Triangles.Add(14);
        wall1Triangles.Add(15);
        wall1Triangles.Add(14);
        wall1Triangles.Add(13);

        meshWall1.triangles = wall1Triangles.ToArray();

        // Seite
        wall1Uvs.Add(new Vector2((29.0f - wallThickness + 27.0f) / 80.0f, upUV));
        wall1Uvs.Add(new Vector2(0, upUV));
        wall1Uvs.Add(new Vector2((29.0f - wallThickness + 27.0f) / 80.0f, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        // Seite
        wall1Uvs.Add(new Vector2((29.0f - wallThickness + 27.0f) / 80.0f, upUV));
        wall1Uvs.Add(new Vector2(0, upUV));
        wall1Uvs.Add(new Vector2((29.0f - wallThickness + 27.0f) / 80.0f, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        // zwischen den Seiten
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        // oben
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        wall1Uvs.Add(new Vector2(0, 0));
        
        meshWall1.uv = wall1Uvs.ToArray();

        meshWall1.RecalculateNormals();

        wall1.transform.position = new Vector3(119, 0, 62);

        MeshCollider wall1Collider = wall1.AddComponent<MeshCollider>();
        Rigidbody wall1Body = wall1.AddComponent<Rigidbody>();
        wall1Body.isKinematic = true;
        meshWall1 = wall1Collider.sharedMesh;

        // verschieben nötig, da es an Empty "Building" gehängt wird, was erst später eingefügt wurde
        wall1.transform.Translate(-82, 0, 41);

        // erstelle separates GameObject für wall2, um es Instantiate direkt zuzuweisen -> um wall2 selbst benennen zu können
        GameObject wall2;
        // nimm wall1 und kopiere es -> setze es dann an andere Position
        Vector3 newPosition = new Vector3(95, 0, 62);
        wall2 = Instantiate(wall1, newPosition, wall1.transform.rotation);
        wall2.name = "Dividing Wall Room 2 (2)";
        // füge wall2 zum Empty "Building"
        wall2.transform.parent = building.transform;

        // verschieben nötig, da es an Empty "Building" gehängt wird, was erst später eingefügt wurde
        wall2.transform.Translate(-82, 0, 41);

        /* DUNKELBLAUE WAND */

        Mesh meshwall3 = new Mesh();
        GameObject wall3 = new GameObject("Dividing Wall Room 9", typeof(MeshFilter), typeof(MeshRenderer));
        // füge wall3 zum Empty "Building"
        wall3.transform.parent = building.transform;

        Renderer rend2 = wall3.GetComponent<Renderer>();
        rend2.material = new Material(Shader.Find("Standard"));
        // Texture texture2 = Resources.Load("TextureDarkBlue") as Texture;
        rend2.material.mainTexture = texture9;

        meshwall3 = wall3.GetComponent<MeshFilter>().mesh;
        meshwall3.Clear();

        List<Vector3> wall3Vertices = new List<Vector3>();
        List<int> wall3Triangles = new List<int>();
        List<Vector2> wall3Uvs = new List<Vector2>();

        // Seite
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(-0.5f, 0, -17));
        wall3Vertices.Add(new Vector3(-0.5f, 0, 19 - wallThickness));
        // Seite
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(0.5f, 0, -17));
        wall3Vertices.Add(new Vector3(0.5f, 0, 19 - wallThickness));
        // zwischen den Seiten
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(-0.5f, 0, -17));
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(0.5f, 0, -17));
        // zwischen den Seiten
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(-0.5f, 0, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(0.5f, 0, 19 - wallThickness));
        // oben
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(-0.5f, height / wallFactor, 19 - wallThickness));
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, -17));
        wall3Vertices.Add(new Vector3(0.5f, height / wallFactor, 19 - wallThickness));

        meshwall3.vertices = wall3Vertices.ToArray();

        // Seite -> 0 bis 3
        wall3Triangles.Add(1);
        wall3Triangles.Add(0);
        wall3Triangles.Add(2);
        wall3Triangles.Add(3);
        wall3Triangles.Add(1);
        wall3Triangles.Add(2);

        // Seite -> 4 bis 7
        wall3Triangles.Add(4);
        wall3Triangles.Add(5);
        wall3Triangles.Add(6);
        wall3Triangles.Add(7);
        wall3Triangles.Add(6);
        wall3Triangles.Add(5);

        // zwischen den Seiten -> 8 bis 11
        wall3Triangles.Add(9);
        wall3Triangles.Add(8);
        wall3Triangles.Add(10);
        wall3Triangles.Add(11);
        wall3Triangles.Add(9);
        wall3Triangles.Add(10);

        // zwischen den Seiten -> 12 bis 15
        wall3Triangles.Add(12);
        wall3Triangles.Add(13);
        wall3Triangles.Add(14);
        wall3Triangles.Add(15);
        wall3Triangles.Add(14);
        wall3Triangles.Add(13);

        // oben -> 16 bis 19
        wall3Triangles.Add(16);
        wall3Triangles.Add(17);
        wall3Triangles.Add(18);
        wall3Triangles.Add(19);
        wall3Triangles.Add(18);
        wall3Triangles.Add(17);

        meshwall3.triangles = wall3Triangles.ToArray();

        // Seite
        wall3Uvs.Add(new Vector2(1.0f - (((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness)), 0));
        wall3Uvs.Add(new Vector2(((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness), 0));
        wall3Uvs.Add(new Vector2(1.0f - (((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness)), upUV));
        wall3Uvs.Add(new Vector2(((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness), upUV));
        // Seite
        wall3Uvs.Add(new Vector2(1.0f - (((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness)), 0));
        wall3Uvs.Add(new Vector2(((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness), 0));
        wall3Uvs.Add(new Vector2(1.0f - (((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness)), upUV));
        wall3Uvs.Add(new Vector2(((19 - wallThickness + 17.0f) / 2) / (70.0f + wallThickness + wallThickness), upUV));
        // zwischen den Seiten
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        // zwischen den Seiten
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        // oben
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        wall3Uvs.Add(new Vector2(0, 0));
        
        meshwall3.uv = wall3Uvs.ToArray();

        meshwall3.RecalculateNormals();

        wall3.transform.position = new Vector3(158, 0, -75);
        // verschieben und dann rotieren -> nötig, da es an Empty "Building" gehängt wird, was erst später eingefügt wurde
        wall3.transform.Translate(-82, 0, 41);
        wall3.transform.Rotate(0, 90, 0);

        MeshCollider wall3Collider = wall3.AddComponent<MeshCollider>();
        Rigidbody wall3Body = wall3.AddComponent<Rigidbody>();
        wall3Body.isKinematic = true;
        meshwall3 = wall3Collider.sharedMesh;
    }

}
