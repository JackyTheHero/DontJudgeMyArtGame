using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DE_pictureCreation : MonoBehaviour
{
    //Gibt Bildern eine Nummer
    static int number = 1;
    static int numberOwned = 1;

    static GameObject pictureParent = new GameObject("pictureParent");
        
    public static void pictureCreation()
    {
        //Erzeugt Bilder bei Start

        createPicture(30f, 37f, 6f, 4f, 2f, 0f, 0); 
        createPicture(63f, 37f, 6f, 4f, 2f, 0f, 0);
        createPicture(70f, 27f, 6f, 4f, 2f, 90f, 0);
        createPicture(70f, 14f, 6f, 4f, 2f, 90f, 0);
        createPicture(70f, 1f, 6f, 4f, 2f, 90f, 1);
        createPicture(70f, -30f, 6f, 4f, 2f, 90f, 0);
        createPicture(50f, -39f, 6f, 4f, 2f, 180f, 0);

        createPicture(28f, 39f, 6f, 4f, 2f, 180f, 2);
        createPicture(14f, 49f, 6f, 4f, 2f, 270f, 0);
        createPicture(14f, 79f, 6f, 4f, 2f, 270f, 0);
        createPicture(26f, 89f, 6f, 4f, 2f, 0f, 0);
        createPicture(58f, 89f, 6f, 4f, 2f, 0f, 1);
        createPicture(70f, 49f, 6f, 4f, 2f, 90f, 0);
        createPicture(70f, 79f, 6f, 4f, 2f, 90f, 0);

        createPicture(43f, -41f, 6f, 4f, 2f, 0f, 0);
        createPicture(52f, -57f, 6f, 4f, 2f, 90f, 1);
        createPicture(52f, -95f, 6f, 4f, 2f, 90f, 0);
        createPicture(20f, -109f, 6f, 4f, 2f, 180f, 1);
        createPicture(46f, -109f, 6f, 4f, 2f, 180f, 0);
        createPicture(14f, -82f, 6f, 4f, 2f, 270f, 0);
        createPicture(14f, -68f, 6f, 4f, 2f, 270f, 0);

        createPicture(70f, -41f, 6f, 4f, 2f, 0, 0);
        createPicture(110f, -41f, 6f, 4f, 2f, 0, 0);
        createPicture(122f, -53f, 6f, 4f, 2f, 90f, 0);
        createPicture(122f, -66f, 6f, 4f, 2f, 90f, 2);
        createPicture(122f, -79f, 6f, 4f, 2f, 90f, 0);
        createPicture(88f, -109f, 6f, 4f, 2f, 180f, 0);
        createPicture(54f, -95f, 6f, 4f, 2f, 270f, 2);
        createPicture(54f, -55f, 6f, 4f, 2f, 270f, 0);
            
        createPicture(91f, 7f, 6f, 4f, 2f, 0f, 0);
        createPicture(122f, -4f, 6f, 4f, 2f, 90f, 0);
        createPicture(122f, -28f, 6f, 4f, 2f, 90f, 0);
        createPicture(108f, -39f, 6f, 4f, 2f, 180f, 2);
        createPicture(72f, -4f, 6f, 4f, 2f, 270f, 0);
        createPicture(72f, -28f, 6f, 4f, 2f, 270f, 0);

        createPicture(138f, -41f, 6f, 4f, 2f, 0f, 1);
        createPicture(184f, -41f, 6f, 4f, 2f, 0f, 0);
        createPicture(192f, -66f, 6f, 4f, 2f, 90f, 0);
        createPicture(192f, -84f, 6f, 4f, 2f, 90f, 2);
        createPicture(158f, -109f, 6f, 4f, 2f, 180f, 0);
        createPicture(131f, -109f, 6f, 4f, 2f, 180f, 0);
        createPicture(124f, -53f, 6f, 4f, 2f, 270f, 0);
        createPicture(124f, -66f, 6f, 4f, 2f, 270f, 0);
        createPicture(124f, -79f, 6f, 4f, 2f, 270f, 0);
        createPicture(150f, -74.5f, 6f, 4f, 2f, 180f, 0);
        createPicture(166f, -74.5f, 6f, 4f, 2f, 180f, 0);
        createPicture(166f, -75.5f, 6f, 4f, 2f, 0f, 0);
        createPicture(150f, -75.5f, 6f, 4f, 2f, 0f, 2);

        createPicture(137f, 7f, 6f, 4f, 2f, 0f, 0);
        createPicture(153f, 7f, 6f, 4f, 2f, 0f, 0);
        createPicture(192f, -29f, 6f, 4f, 2f, 90f, 0);
        createPicture(192f, -3f, 6f, 4f, 2f, 90f, 0);
        createPicture(153f, -39f, 6f, 4f, 2f, 180f, 2);
        createPicture(137f, -39f, 6f, 4f, 2f, 180f, 0);
        createPicture(124f, -30f, 6f, 4f, 2f, 270f, 0);
        createPicture(124f, -2f, 6f, 4f, 2f, 270f, 1);

        createPicture(168f, 89f, 6f, 4f, 2f, 0f, 0);
        createPicture(192f, 37.5f, 6f, 4f, 2f, 90f, 0);
        createPicture(192f, 49f, 6f, 4f, 2f, 90f, 1);
        createPicture(192f, 61f, 6f, 4f, 2f, 90f, 0);
        createPicture(144f, 49f, 6f, 4f, 2f, 270f, 2);
        createPicture(144f, 72f, 6f, 4f, 2f, 270f, 0);

        createPicture(142f, 80f, 6f, 4f, 2f, 90f, 0);
        createPicture(142f, 65f, 6f, 4f, 2f, 90f, 0);
        createPicture(142f, 50f, 6f, 4f, 2f, 90f, 0);
        createPicture(72f, 28f, 6f, 4f, 2f, 270f, 0);
        createPicture(72f, 45f, 6f, 4f, 2f, 270f, 0);
        createPicture(72f, 79f, 6f, 4f, 2f, 270f, 0);       
        createPicture(118.5f, 46f, 6f, 4f, 2f, 90f, 0);
        createPicture(118.5f, 62f, 6f, 4f, 2f, 90f, 0);
        createPicture(118.5f, 78f, 6f, 4f, 2f, 90f, 0);
        createPicture(119.5f, 46f, 6f, 4f, 2f, 270f, 0);
        createPicture(119.5f, 62f, 6f, 4f, 2f, 270f, 1);
        createPicture(119.5f, 78f, 6f, 4f, 2f, 270f, 0);
        createPicture(94.5f, 46f, 6f, 4f, 2f, 90f, 2);
        createPicture(94.5f, 62f, 6f, 4f, 2f, 90f, 0);
        createPicture(94.5f, 78f, 6f, 4f, 2f, 90f, 0);
        createPicture(95.5f, 46f, 6f, 4f, 2f, 270f, 0);
        createPicture(95.5f, 62f, 6f, 4f, 2f, 270f, 0);
        createPicture(95.5f, 78f, 6f, 4f, 2f, 270f, 1);   
    }

    //Funktion zum Erzeugen von Bildern (Bild, Rahmen, Plakette)
    // @param posX : X-Koordinate der Bildmitte
    // @param posZ : Z-Koordinate der Bildmitte
    // @param sizeX : Breite des Bildes ausgehend von Bildmitte
    // @param sizeY : Höhe des Bildes ausgehend von unterem Bildrand
    // @param height : Abstand des unteren Bildrandes zum Boden
    // @param rotation: Ausrichtung
    // @param owned: Ob das Bild dem Spieler gehört, legt außerdem fest ob Plakette erzeugt wird und auf welcher Seite (0: keine Plakette, 1: links, 2: rechts)
    // @param number: Iterator Nummer
    public static void createPicture(float posX, float posZ, float sizeX, float sizeY, float height, float rotation, int owned)
    {

        //Textur für später deklarieren
        Texture2D img = new Texture2D(2,2);

        //Wenn Bild nicht eigenes: Normale Bildtextur aus Assets laden
        if(owned == 0){
            img = Resources.Load("Bilder/bild" + number) as Texture2D;
        } else{ //Wenn Bild eigenes: benutzerdefiniertes Bild aus StreamingAssets laden
            //Pfad zu Bild
            string path = Application.streamingAssetsPath + "\\" + numberOwned + ".png";
            //Lädt Bytes des Bildes
            byte[] imgData = System.IO.File.ReadAllBytes(path);
            //Erzeugt neue Textur aus Bytes
            img.LoadImage(imgData);
        }
    
        //Breite und Höhe der Textur für Formatberechnung
        float imgX = img.width;
        float imgY = img.height;

        //Variable maximale Größen je nach Auflösung
        float maxSize = 8;
        if(imgX < 2000 && imgY < 2000){
            maxSize = 7;
            if(imgX < 1000 && imgY < 1000){
                maxSize = 6;
                if(imgX < 500 && imgY < 500){
                    maxSize = 5;
                    if(imgX < 250 && imgY < 250){
                        maxSize = 4;
                        if(imgX < 100 && imgY < 100){
                            //Verhindert starke Unschärfe bei kleinen Bildern (z.B. Pixelart)
                            img.filterMode = FilterMode.Point;
                        }
                    }
                }
            }
        }

        //Berechnet Format
        if(imgX >= imgY){
            sizeX = maxSize;
            sizeY = (imgY / imgX) * maxSize;
        } else{
            sizeY = maxSize;
            sizeX = (imgX / imgY) * maxSize;
        }
        
        //Breite des Bilderrahmens an den Rändern (Thickness)
        float thick = 0.3f;
        //Tiefe des inneren Bilderrahmens, zusammen mit Abstand ergibt es Gesamtdicke des Bilderrahmens 
        float depth = -0.3f;
        //Abstand des Bildes zur Wand
        float dist = -0.2f;

        //Berechnung der verwendeten Maße
        float sizeXhalf = sizeX / 2;
        float sizeYhalf = sizeY / 2;

        //GameObject erzeugen
        GameObject pic = new GameObject();
        pic.name = "Bild";
        pic.AddComponent<MeshFilter>();
        pic.AddComponent<MeshRenderer>();

        //Bild erzeugen
        Mesh picMesh = pic.GetComponent<MeshFilter>().mesh;
        
        //Arrays für Bildfläche
        picMesh.vertices = new Vector3[] {new Vector3(-sizeXhalf, -sizeYhalf, dist), new Vector3(sizeXhalf, -sizeYhalf, dist), new Vector3(sizeXhalf, sizeYhalf, dist), new Vector3(-sizeXhalf, sizeYhalf, dist)};
        picMesh.triangles = new int[] {3, 2, 1, 3, 1, 0};
        picMesh.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(1,1), new Vector2(0,1)};

        picMesh.RecalculateBounds();

        //Renderer
        Renderer picRend = pic.GetComponent<Renderer>();
        picRend.material= new Material(Shader.Find("Standard"));
        picRend.material.mainTexture = img;

        picMesh.RecalculateNormals();

        //Rahmen erzeugen
        GameObject frame = new GameObject();
        frame.name = "Rahmen";
        frame.AddComponent<MeshFilter>();
        frame.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh frameMesh = frame.GetComponent<MeshFilter>().mesh;
                
        //Arrays für Rahmen
        frameMesh.vertices = new Vector3[] {
            new Vector3(-sizeXhalf - thick, -sizeYhalf -thick, depth),
            new Vector3(-sizeXhalf - thick, -sizeYhalf -thick, depth), 
            new Vector3(-sizeXhalf - thick, -sizeYhalf -thick, depth), 
            new Vector3(sizeXhalf + thick, -sizeYhalf -thick, depth),
            new Vector3(sizeXhalf + thick, -sizeYhalf -thick, depth),
            new Vector3(sizeXhalf + thick, -sizeYhalf -thick, depth),
            new Vector3(sizeXhalf + thick, sizeYhalf + thick, depth),
            new Vector3(sizeXhalf + thick, sizeYhalf + thick, depth),
            new Vector3(sizeXhalf + thick, sizeYhalf + thick, depth),
            new Vector3(-sizeXhalf - thick, sizeYhalf + thick, depth),
            new Vector3(-sizeXhalf - thick, sizeYhalf + thick, depth),
            new Vector3(-sizeXhalf - thick, sizeYhalf + thick, depth),
            new Vector3(-sizeXhalf - thick, -sizeYhalf -thick, 0),
            new Vector3(-sizeXhalf - thick, -sizeYhalf -thick, 0), 
            new Vector3(sizeXhalf + thick, -sizeYhalf -thick, 0),
            new Vector3(sizeXhalf + thick, -sizeYhalf -thick, 0),
            new Vector3(sizeXhalf + thick, sizeYhalf + thick, 0),
            new Vector3(sizeXhalf + thick, sizeYhalf + thick, 0),
            new Vector3(-sizeXhalf - thick, sizeYhalf + thick, 0),
            new Vector3(-sizeXhalf - thick, sizeYhalf + thick, 0),
            new Vector3(-sizeXhalf, -sizeYhalf, depth),
            new Vector3(-sizeXhalf, -sizeYhalf, depth),
            new Vector3(-sizeXhalf, -sizeYhalf, depth),
            new Vector3(sizeXhalf, -sizeYhalf, depth),
            new Vector3(sizeXhalf, -sizeYhalf, depth),
            new Vector3(sizeXhalf, -sizeYhalf, depth), 
            new Vector3(sizeXhalf, sizeYhalf , depth),
            new Vector3(sizeXhalf, sizeYhalf , depth),
            new Vector3(sizeXhalf, sizeYhalf , depth),
            new Vector3(-sizeXhalf, sizeYhalf , depth),
            new Vector3(-sizeXhalf, sizeYhalf , depth),
            new Vector3(-sizeXhalf, sizeYhalf , depth),
            new Vector3(-sizeXhalf, -sizeYhalf, dist),
            new Vector3(-sizeXhalf, -sizeYhalf, dist),  
            new Vector3(sizeXhalf , -sizeYhalf, dist), 
            new Vector3(sizeXhalf , -sizeYhalf, dist),  
            new Vector3(sizeXhalf , sizeYhalf , dist), 
            new Vector3(sizeXhalf , sizeYhalf , dist),  
            new Vector3(-sizeXhalf, sizeYhalf , dist),
            new Vector3(-sizeXhalf, sizeYhalf , dist)
        };

        frameMesh.triangles = new int[] {0,20,23,0,23,3, 3,23,26,3,26,6, 6,26,29,6,29,9, 0,9,29,0,29,20, 1,5,14,1,14,13, 4,8,16,4,16,15, 7,11,18,7,18,17, 10,2,12,10,12,19, 22,33,34,22,34,24, 25,35,36,25,36,27, 28,37,38,28,38,30, 21,31,39,21,39,32};

        frameMesh.uv = new Vector2[] {
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

        frameMesh.RecalculateBounds();

        //Renderer
        Renderer frameRend = frame.GetComponent<Renderer>();
        frameRend.material= new Material(Shader.Find("Standard"));
        frameRend.material.mainTexture = Resources.Load("holz") as Texture;

        frameMesh.RecalculateNormals();

        //Parent Gemälde erzeugen
        GameObject painting = new GameObject();
        painting.name = "Gemälde" + number;

        //Prüfen ob Spielergemälde
        if(owned != 0){

            //Plakette erzeugen
            GameObject sign = new GameObject();
            sign.name = "Plakette";
            sign.AddComponent<MeshFilter>();
            sign.AddComponent<MeshRenderer>();

            //Besitz im Namen festlegen
            painting.name = "Gemälde" + numberOwned + "owned";

            //Mesh erzeugen
            Mesh signMesh = sign.GetComponent<MeshFilter>().mesh;
            
            //Abstand der Plakette zum Bild
            float left = (-sizeXhalf) - thick - 1.7f;
            float right = (sizeXhalf) + thick + 1.7f;

            //Arrays für Plakette
            //Tenärer Operator für links oder rechts
            if(owned == 1){
                signMesh.vertices = new Vector3[] {
                new Vector3(left, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(left, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(left, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(left - 1, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(left - 1, -sizeYhalf + 0.5f, -0.1f), 
                new Vector3(left - 1, -sizeYhalf + 0.5f, -0.1f), 
                new Vector3(left - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(left - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(left - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(left, -sizeYhalf + 2f, -0.1f),
                new Vector3(left, -sizeYhalf + 2f, -0.1f),
                new Vector3(left, -sizeYhalf + 2f, -0.1f),
                new Vector3(left, -sizeYhalf + 0.5f, 0),
                new Vector3(left, -sizeYhalf + 0.5f, 0),
                new Vector3(left - 1, -sizeYhalf + 0.5f, 0),
                new Vector3(left - 1, -sizeYhalf + 0.5f, 0),
                new Vector3(left - 1, -sizeYhalf + 2f, 0),
                new Vector3(left - 1, -sizeYhalf + 2f, 0),
                new Vector3(left, -sizeYhalf + 2f, 0),
                new Vector3(left, -sizeYhalf + 2f, 0)
                };
            } else{
                signMesh.vertices = new Vector3[] {
                new Vector3(right, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(right, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(right, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(right - 1, -sizeYhalf + 0.5f, -0.1f),
                new Vector3(right - 1, -sizeYhalf + 0.5f, -0.1f), 
                new Vector3(right - 1, -sizeYhalf + 0.5f, -0.1f), 
                new Vector3(right - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(right - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(right - 1, -sizeYhalf + 2f, -0.1f),
                new Vector3(right, -sizeYhalf + 2f, -0.1f),
                new Vector3(right, -sizeYhalf + 2f, -0.1f),
                new Vector3(right, -sizeYhalf + 2f, -0.1f),
                new Vector3(right, -sizeYhalf + 0.5f, 0),
                new Vector3(right, -sizeYhalf + 0.5f, 0),
                new Vector3(right - 1, -sizeYhalf + 0.5f, 0),
                new Vector3(right - 1, -sizeYhalf + 0.5f, 0),
                new Vector3(right - 1, -sizeYhalf + 2f, 0),
                new Vector3(right - 1, -sizeYhalf + 2f, 0),
                new Vector3(right, -sizeYhalf + 2f, 0),
                new Vector3(right, -sizeYhalf + 2f, 0)
                };
            }

            signMesh.triangles = new int[] {0,3,6,0,6,9, 1,12,14,1,14,5, 4,15,16,4,16,8, 7,17,18,7,18,11, 2,10,19,2,19,13};

            signMesh.uv = new Vector2[] {
                new Vector2(0,0), new Vector2(0,0), new Vector2(0,0), 
                new Vector2(1,0), new Vector2(0,0), new Vector2(0,1), 
                new Vector2(1,1), new Vector2(0,0), new Vector2(0,1), 
                new Vector2(0,1), new Vector2(0,1), new Vector2(0,1),
                new Vector2(0.2f,0), new Vector2(0.2f,0), 
                new Vector2(0.2f,1), new Vector2(0.2f,0),
                new Vector2(0.2f,1), new Vector2(0.2f,0), 
                new Vector2(0.2f,1), new Vector2(0.2f,1)
                };

            signMesh.RecalculateBounds();

            //Renderer
            Renderer signRend = sign.GetComponent<Renderer>();
            signRend.material= new Material(Shader.Find("Standard"));
            signRend.material.mainTexture = Resources.Load("plakette") as Texture;
            signRend.material.SetFloat("_Metallic", 0.7f); 

            signMesh.RecalculateNormals();

            sign.transform.parent = painting.transform;

        }

        //Parent setzen
        pic.transform.parent = painting.transform;
        frame.transform.parent = painting.transform;

        //Rotation und Translation
        painting.transform.Translate(posX, height + sizeYhalf, posZ);
        painting.transform.Rotate(0, rotation, 0); 

        painting.transform.parent = pictureParent.transform;
        
        //Collider hinzufügen
        BoxCollider boxCollider = painting.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(sizeX+2,sizeY,2);
        boxCollider.center =  new Vector3(0,0,-1);
        boxCollider.isTrigger = true;

        if(owned == 0){
            //Erhöht Nummder der Bilder um eins
            number++; 
        } else{
            //Erhöht Nummer der eigenen Bilder um eins
            numberOwned++;
        }

    }
}