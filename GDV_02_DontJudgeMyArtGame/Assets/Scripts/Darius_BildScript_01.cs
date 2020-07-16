using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darius_BildScript_01 : MonoBehaviour
{
// Start is called before the first frame update

    void Start()
    {
        createBild(35f, 37f, 6f, 4f, 2f, 0f); 
        createBild(63f, 37f, 6f, 4f, 2f, 0f);
        createBild(35f, 39f, 6f, 4f, 2f, 180f);
        createBild(14f, 50f, 6f, 4f, 2f, 270f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBild(float posX, float posZ, float sizeX, float sizeY, float height, float rotation){

        float thick = 0.3f;
        float depth = 0.3f;
        float abstand = 0.2f;

        //GameObject erzeugen
        GameObject bild = new GameObject();

        bild.AddComponent<MeshFilter>();
        bild.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh bildflaeche = bild.GetComponent<MeshFilter>().mesh;
        
        //Arrays für Bildfläche
        bildflaeche.vertices = new Vector3[] {new Vector3((0 - sizeX / 2) + posX, height, posZ - abstand), new Vector3(sizeX / 2 + posX, height, posZ - abstand), new Vector3(sizeX / 2 + posX, sizeY + height, posZ - abstand), new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - abstand)};
        bildflaeche.triangles = new int[] {3, 2, 1, 3, 1, 0};

        bildflaeche.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(1,1), new Vector2(0,1)};

        bildflaeche.RecalculateBounds();

        //Renderer
        Renderer rendB = bild.GetComponent<Renderer>();
        rendB.material= new Material(Shader.Find("Standard"));
        rendB.material.mainTexture = Resources.Load("testbild") as Texture;

        bildflaeche.RecalculateNormals();

        //GameObject erzeugen
        GameObject rahmen = new GameObject();

        rahmen.AddComponent<MeshFilter>();
        rahmen.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh rahmenflaeche = rahmen.GetComponent<MeshFilter>().mesh;
        
        
        //Arrays für Bildfläche
        rahmenflaeche.vertices = new Vector3[] {
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ - depth), 
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ - depth),  
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ - depth),
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ - depth), 
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ - depth),  
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ - depth),
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ - depth),
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ),
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ), 
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ),
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ),
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ),
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ),
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ),
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - depth),
            new Vector3(sizeX / 2 + posX, height, posZ - depth),
            new Vector3(sizeX / 2 + posX, height, posZ - depth),
            new Vector3(sizeX / 2 + posX, height, posZ - depth), 
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - depth),
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - depth),
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - abstand),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - abstand),  
            new Vector3(sizeX / 2 + posX, height, posZ - abstand), 
            new Vector3(sizeX / 2 + posX, height, posZ - abstand), 
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - abstand), 
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - abstand), 
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - abstand),
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - abstand)
        };

        rahmenflaeche.triangles = new int[] {0,20,23,0,23,3, 3,23,26,3,26,6, 6,26,29,6,29,9, 0,9,29,0,29,20, 1,5,14,1,14,13, 4,8,16,4,16,15, 7,11,18,7,18,17, 10,2,12,10,12,19, 22,33,34,22,34,24, 25,35,36,25,36,27, 28,37,38,28,38,30, 21,31,39,21,39,32};

        rahmenflaeche.uv = new Vector2[] {
            new Vector2(0,0), new Vector2(0,0), new Vector2(0,0), 
            new Vector2(1,0), new Vector2(1,0), new Vector2(1,0), 
            new Vector2(0,0), new Vector2(0,0), new Vector2(0,0), 
            new Vector2(1,0), new Vector2(1,0), new Vector2(1,0),
            new Vector2(0,1), new Vector2(0,1),  
            new Vector2(1,1), new Vector2(1,1), 
            new Vector2(0,1), new Vector2(0,1), 
            new Vector2(1,1), new Vector2(1,1), 
            new Vector2(0,1), new Vector2(0,1), new Vector2(0,1),
            new Vector2(1,1), new Vector2(1,1), new Vector2(1,1),
            new Vector2(0,1), new Vector2(0,1), new Vector2(0,1),
            new Vector2(1,1), new Vector2(1,1), new Vector2(1,1),
            new Vector2(0,0), new Vector2(0,0),
            new Vector2(1,0), new Vector2(1,0),
            new Vector2(0,0), new Vector2(0,0), 
            new Vector2(1,0), new Vector2(1,0)
            };

        rahmenflaeche.RecalculateBounds();

        //Renderer
        Renderer rendR = rahmen.GetComponent<Renderer>();
        rendR.material= new Material(Shader.Find("Standard"));
        rendR.material.mainTexture = Resources.Load("holz") as Texture;

        rahmenflaeche.RecalculateNormals();

        GameObject gemaelde = new GameObject();

        gemaelde.transform.Translate(posX, 0, posZ);

        bild.transform.parent = gemaelde.transform;
        rahmen.transform.parent = gemaelde.transform;

        gemaelde.transform.Rotate(0, rotation, 0);

    }
}