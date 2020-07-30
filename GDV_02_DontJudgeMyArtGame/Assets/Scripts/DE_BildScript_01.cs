using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_BildScript_01 : MonoBehaviour
{

    void Start()
    {
        //Erzeugt Bilder bei Start

        createBild(30f, 37f, 6f, 4f, 2f, 0f, 0); 
        createBild(63f, 37f, 6f, 4f, 2f, 0f, 0);
        createBild(70f, 27f, 6f, 4f, 2f, 90f, 0);
        createBild(70f, 14f, 6f, 4f, 2f, 90f, 0);
        createBild(70f, 1f, 6f, 4f, 2f, 90f, 1);
        createBild(70f, -30f, 6f, 4f, 2f, 90f, 0);
        createBild(50f, -39f, 6f, 4f, 2f, 180f, 0);

        createBild(28f, 39f, 6f, 4f, 2f, 180f, 2);
        createBild(14f, 49f, 6f, 4f, 2f, 270f, 0);
        createBild(14f, 79f, 6f, 4f, 2f, 270f, 0);
        createBild(26f, 89f, 6f, 4f, 2f, 0f, 0);
        createBild(58f, 89f, 6f, 4f, 2f, 0f, 1);
        createBild(70f, 49f, 6f, 4f, 2f, 90f, 0);
        createBild(70f, 79f, 6f, 4f, 2f, 90f, 0);

        createBild(43f, -41f, 6f, 4f, 2f, 0f, 0);
        createBild(52f, -57f, 6f, 4f, 2f, 90f, 1);
        createBild(52f, -95f, 6f, 4f, 2f, 90f, 0);
        createBild(20f, -109f, 6f, 4f, 2f, 180f, 1);
        createBild(46f, -109f, 6f, 4f, 2f, 180f, 0);
        createBild(14f, -82f, 6f, 4f, 2f, 270f, 0);
        createBild(14f, -68f, 6f, 4f, 2f, 270f, 0);

        createBild(70f, -41f, 6f, 4f, 2f, 0, 0);
        createBild(110f, -41f, 6f, 4f, 2f, 0, 0);
        createBild(122f, -53f, 6f, 4f, 2f, 90f, 0);
        createBild(122f, -66f, 6f, 4f, 2f, 90f, 2);
        createBild(122f, -79f, 6f, 4f, 2f, 90f, 0);
        createBild(88f, -109f, 6f, 4f, 2f, 180f, 0);
        createBild(54f, -95f, 6f, 4f, 2f, 270f, 2);
        createBild(54f, -55f, 6f, 4f, 2f, 270f, 0);
        
        createBild(91f, 7f, 6f, 4f, 2f, 0f, 0);
        createBild(122f, -4f, 6f, 4f, 2f, 90f, 0);
        createBild(122f, -28f, 6f, 4f, 2f, 90f, 0);
        createBild(108f, -39f, 6f, 4f, 2f, 180f, 2);
        createBild(72f, -4f, 6f, 4f, 2f, 270f, 0);
        createBild(72f, -28f, 6f, 4f, 2f, 270f, 0);

        createBild(138f, -41f, 6f, 4f, 2f, 0f, 1);
        createBild(184f, -41f, 6f, 4f, 2f, 0f, 0);
        createBild(192f, -66f, 6f, 4f, 2f, 90f, 0);
        createBild(192f, -84f, 6f, 4f, 2f, 90f, 2);
        createBild(158f, -109f, 6f, 4f, 2f, 180f, 0);
        createBild(131f, -109f, 6f, 4f, 2f, 180f, 0);
        createBild(124f, -53f, 6f, 4f, 2f, 270f, 0);
        createBild(124f, -66f, 6f, 4f, 2f, 270f, 0);
        createBild(124f, -79f, 6f, 4f, 2f, 270f, 0);
        createBild(150f, -74.5f, 6f, 4f, 2f, 180f, 0);
        createBild(166f, -74.5f, 6f, 4f, 2f, 180f, 0);
        createBild(166f, -75.5f, 6f, 4f, 2f, 0f, 0);
        createBild(150f, -75.5f, 6f, 4f, 2f, 0f, 2);

        createBild(137f, 7f, 6f, 4f, 2f, 0f, 0);
        createBild(153f, 7f, 6f, 4f, 2f, 0f, 0);
        createBild(192f, -29f, 6f, 4f, 2f, 90f, 0);
        createBild(192f, -3f, 6f, 4f, 2f, 90f, 0);
        createBild(153f, -39f, 6f, 4f, 2f, 180f, 2);
        createBild(137f, -39f, 6f, 4f, 2f, 180f, 0);
        createBild(124f, -30f, 6f, 4f, 2f, 270f, 0);
        createBild(124f, -2f, 6f, 4f, 2f, 270f, 1);

        createBild(168f, 89f, 6f, 4f, 2f, 0f, 0);
        createBild(192f, 37.5f, 6f, 4f, 2f, 90f, 0);
        createBild(192f, 49f, 6f, 4f, 2f, 90f, 1);
        createBild(192f, 61f, 6f, 4f, 2f, 90f, 0);
        createBild(144f, 49f, 6f, 4f, 2f, 270f, 2);
        createBild(144f, 72f, 6f, 4f, 2f, 270f, 0);

        createBild(142f, 80f, 6f, 4f, 2f, 90f, 0);
        createBild(142f, 65f, 6f, 4f, 2f, 90f, 0);
        createBild(142f, 50f, 6f, 4f, 2f, 90f, 0);
        createBild(72f, 28f, 6f, 4f, 2f, 270f, 0);
        createBild(72f, 45f, 6f, 4f, 2f, 270f, 0);
        createBild(72f, 79f, 6f, 4f, 2f, 270f, 0);       
        createBild(118.5f, 46f, 6f, 4f, 2f, 90f, 0);
        createBild(118.5f, 62f, 6f, 4f, 2f, 90f, 0);
        createBild(118.5f, 78f, 6f, 4f, 2f, 90f, 0);
        createBild(119.5f, 46f, 6f, 4f, 2f, 270f, 0);
        createBild(119.5f, 62f, 6f, 4f, 2f, 270f, 1);
        createBild(119.5f, 78f, 6f, 4f, 2f, 270f, 0);
        createBild(94.5f, 46f, 6f, 4f, 2f, 90f, 2);
        createBild(94.5f, 62f, 6f, 4f, 2f, 90f, 0);
        createBild(94.5f, 78f, 6f, 4f, 2f, 90f, 0);
        createBild(95.5f, 46f, 6f, 4f, 2f, 270f, 0);
        createBild(95.5f, 62f, 6f, 4f, 2f, 270f, 0);
        createBild(95.5f, 78f, 6f, 4f, 2f, 270f, 1);
        
    }

    // Update bis jetzt leer
    void Update()
    {
        
    }

    //Funktion zum Erzeugen von Bildern (Bild, Rahmen, Plakette)
    // @param posX : X-Koordinate der Bildmitte
    // @param posZ : Z-Koordinate der Bildmitte
    // @param sizeX : Breite des Bildes ausgehend von Bildmitte
    // @param sizeY : Höhe des Bildes ausgehend von unterem Bildrand
    // @param height : Abstand des unteren Bildrandes zum Boden
    // @param rotation: Ausrichtung
    // @param owned: Ob das Bild dem Spieler gehört, legt außerdem fest ob Plakette erzeugt wird und auf welcher Seite (0: keine Plakette, 1: links, 2: rechts)
    void createBild(float posX, float posZ, float sizeX, float sizeY, float height, float rotation, int owned){

        //Breite des Bilderrahmens an den Rändern (Thickness)
        float thick = 0.3f;
        //Tiefe des inneren Bilderrahmens, zusammen mit Abstand ergibt es Gesamtdicke des Bilderrahmens 
        float depth = -0.3f;
        //Abstand des Bildes zur Wand
        float abstand = -0.2f;

        //GameObject erzeugen
        GameObject bild = new GameObject();

        bild.name = "Bild";

        bild.AddComponent<MeshFilter>();
        bild.AddComponent<MeshRenderer>();

        //Bild erzeugen
        Mesh bildflaeche = bild.GetComponent<MeshFilter>().mesh;
        
        //Arrays für Bildfläche
        bildflaeche.vertices = new Vector3[] {new Vector3(-sizeX / 2, 0, abstand), new Vector3(sizeX / 2, 0, abstand), new Vector3(sizeX / 2, sizeY, abstand), new Vector3(-sizeX / 2, sizeY, abstand)};
        bildflaeche.triangles = new int[] {3, 2, 1, 3, 1, 0};

        bildflaeche.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(1,1), new Vector2(0,1)};

        bildflaeche.RecalculateBounds();

        //Renderer
        Renderer rendB = bild.GetComponent<Renderer>();
        rendB.material= new Material(Shader.Find("Standard"));
        rendB.material.mainTexture = Resources.Load("testbild") as Texture;

        bildflaeche.RecalculateNormals();

        //Rahmen erzeugen
        GameObject rahmen = new GameObject();

        rahmen.name = "Rahmen";

        rahmen.AddComponent<MeshFilter>();
        rahmen.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh rahmenflaeche = rahmen.GetComponent<MeshFilter>().mesh;
        
        
        //Arrays für Rahmen
        rahmenflaeche.vertices = new Vector3[] {
            new Vector3(-sizeX / 2 - thick, -thick, depth),
            new Vector3(-sizeX / 2 - thick, -thick, depth), 
            new Vector3(-sizeX / 2 - thick, -thick, depth), 
            new Vector3(sizeX / 2 + thick, -thick, depth),
            new Vector3(sizeX / 2 + thick, -thick, depth),
            new Vector3(sizeX / 2 + thick, -thick, depth),
            new Vector3(sizeX / 2 + thick, sizeY + thick, depth),
            new Vector3(sizeX / 2 + thick, sizeY + thick, depth),
            new Vector3(sizeX / 2 + thick, sizeY + thick, depth),
            new Vector3(-sizeX / 2 - thick, sizeY + thick, depth),
            new Vector3(-sizeX / 2 - thick, sizeY + thick, depth),
            new Vector3(-sizeX / 2 - thick, sizeY + thick, depth),
            new Vector3(-sizeX / 2 - thick, -thick, 0),
            new Vector3(-sizeX / 2 - thick, -thick, 0), 
            new Vector3(sizeX / 2 + thick, -thick, 0),
            new Vector3(sizeX / 2 + thick, -thick, 0),
            new Vector3(sizeX / 2 + thick, sizeY + thick, 0),
            new Vector3(sizeX / 2 + thick, sizeY + thick, 0),
            new Vector3(-sizeX / 2 - thick, sizeY + thick, 0),
            new Vector3(-sizeX / 2 - thick, sizeY + thick, 0),
            new Vector3(-sizeX / 2, 0, depth),
            new Vector3(-sizeX / 2, 0, depth),
            new Vector3(-sizeX / 2, 0, depth),
            new Vector3(sizeX / 2, 0, depth),
            new Vector3(sizeX / 2, 0, depth),
            new Vector3(sizeX / 2, 0, depth), 
            new Vector3(sizeX / 2, sizeY, depth),
            new Vector3(sizeX / 2, sizeY, depth),
            new Vector3(sizeX / 2, sizeY, depth),
            new Vector3(-sizeX / 2, sizeY, depth),
            new Vector3(-sizeX / 2, sizeY, depth),
            new Vector3(-sizeX / 2, sizeY, depth),
            new Vector3(-sizeX / 2, 0, abstand),
            new Vector3(-sizeX / 2, 0, abstand),  
            new Vector3(sizeX / 2 , 0, abstand), 
            new Vector3(sizeX / 2 , 0, abstand),  
            new Vector3(sizeX / 2 , sizeY, abstand), 
            new Vector3(sizeX / 2 , sizeY, abstand),  
            new Vector3(-sizeX / 2, sizeY, abstand),
            new Vector3(-sizeX / 2, sizeY, abstand)
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

        //Parent Gemälde erzeugen
        GameObject gemaelde = new GameObject();

        gemaelde.name = "Gemälde";

        if(owned != 0){
            //Plakette erzeugen
            GameObject plakette = new GameObject();

            plakette.name = "Plakette";

            plakette.AddComponent<MeshFilter>();
            plakette.AddComponent<MeshRenderer>();

            //Mesh erzeugen
            Mesh plaketteflaeche = plakette.GetComponent<MeshFilter>().mesh;
            
            float links = (-sizeX / 2) - thick - 1.7f;
            float rechts = (sizeX / 2) + thick + 1.7f;

            //Arrays für Plakette
            plaketteflaeche.vertices = new Vector3[] {
                new Vector3((owned == 1) ? links + 1 : rechts, 0.5f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 0.5f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 0.5f, -0.1f),
                new Vector3((owned == 1) ? links : rechts - 1, 0.5f, -0.1f),
                new Vector3((owned == 1) ? links : rechts - 1, 0.5f, -0.1f), 
                new Vector3((owned == 1) ? links : rechts - 1, 0.5f, -0.1f), 
                new Vector3((owned == 1) ? links : rechts - 1, 2f, -0.1f),
                new Vector3((owned == 1) ? links : rechts - 1, 2f, -0.1f),
                new Vector3((owned == 1) ? links : rechts - 1, 2f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 2f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 2f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 2f, -0.1f),
                new Vector3((owned == 1) ? links + 1 : rechts, 0.5f, 0),
                new Vector3((owned == 1) ? links + 1 : rechts, 0.5f, 0),
                new Vector3((owned == 1) ? links : rechts - 1, 0.5f, 0),
                new Vector3((owned == 1) ? links : rechts - 1, 0.5f, 0),
                new Vector3((owned == 1) ? links : rechts - 1, 2f, 0),
                new Vector3((owned == 1) ? links : rechts - 1, 2f, 0),
                new Vector3((owned == 1) ? links + 1 : rechts, 2f, 0),
                new Vector3((owned == 1) ? links + 1 : rechts, 2f, 0)
            };

            plaketteflaeche.triangles = new int[] {0,3,6,0,6,9, 1,12,14,1,14,5, 4,15,16,4,16,8, 7,17,18,7,18,11, 2,10,19,2,19,13};

            plaketteflaeche.uv = new Vector2[] {
                new Vector2(0,0), new Vector2(0,0), new Vector2(0,0), 
                new Vector2(1,0), new Vector2(0,0), new Vector2(0,1), 
                new Vector2(1,1), new Vector2(0,0), new Vector2(0,1), 
                new Vector2(0,1), new Vector2(0,1), new Vector2(0,1),
                new Vector2(0.2f,0), new Vector2(0.2f,0), 
                new Vector2(0.2f,1), new Vector2(0.2f,0),
                new Vector2(0.2f,1), new Vector2(0.2f,0), 
                new Vector2(0.2f,1), new Vector2(0.2f,1)
                };

            plaketteflaeche.RecalculateBounds();

            //Renderer
            Renderer rendP = plakette.GetComponent<Renderer>();
            rendP.material= new Material(Shader.Find("Standard"));
            rendP.material.mainTexture = Resources.Load("plakette") as Texture;
            rendP.material.SetFloat("_Metallic", 0.7f); 

            plaketteflaeche.RecalculateNormals();

            plakette.transform.parent = gemaelde.transform;

        }


        //Parent setzen
        bild.transform.parent = gemaelde.transform;
        rahmen.transform.parent = gemaelde.transform;

        //Rotation und Translation
        gemaelde.transform.Translate(posX, height, posZ);
        gemaelde.transform.Rotate(0, rotation, 0);
        
    }
}