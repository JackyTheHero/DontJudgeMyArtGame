using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darius_BildScript_01 : MonoBehaviour
{
// Start is called before the first frame update
    void Start()
    {
        createBild(0f, 0f, 6f, 4f, 2f);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBild(float posX, float posZ, float sizeX, float sizeY, float height){

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
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ - depth), 
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ - depth), 
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX - thick, height - thick, posZ), 
            new Vector3(sizeX / 2 + posX + thick, height - thick, posZ), 
            new Vector3(sizeX / 2 + posX + thick, sizeY + height + thick, posZ), 
            new Vector3((0 - sizeX / 2) + posX - thick, sizeY + height + thick, posZ),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - depth),
            new Vector3(sizeX / 2 + posX, height, posZ - depth), 
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - depth), 
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - depth),
            new Vector3((0 - sizeX / 2) + posX, height, posZ - abstand), 
            new Vector3(sizeX / 2 + posX, height, posZ - abstand), 
            new Vector3(sizeX / 2 + posX, sizeY + height, posZ - abstand), 
            new Vector3((0 - sizeX / 2) + posX, sizeY + height, posZ - abstand)
        };

        rahmenflaeche.triangles = new int[] {0,1,5,0,5,4, 0,4,7,0,7,3, 1,2,6,1,6,5, 2,3,7,2,7,6, 0,8,9,0,9,1, 0,3,11,0,11,8, 1,9,10,1,10,2, 10,11,3,10,3,2, 8,12,13,8,13,9, 8,11,15,8,15,12, 9,13,14,9,14,10, 14,15,11,14,11,10};

        rahmenflaeche.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(0,0), new Vector2(1,0), new Vector2(0,1), new Vector2(1,1), new Vector2(0,1), new Vector2(1,1), new Vector2(0,1), new Vector2(1,1), new Vector2(0,1), new Vector2(1,1), new Vector2(0,0), new Vector2(1,0), new Vector2(0,0), new Vector2(1,0)};

        rahmenflaeche.RecalculateBounds();

        //Renderer
        Renderer rendR = rahmen.GetComponent<Renderer>();
        rendR.material= new Material(Shader.Find("Standard"));
        rendR.material.mainTexture = Resources.Load("holz") as Texture;

        rahmenflaeche.RecalculateNormals();
    }
}