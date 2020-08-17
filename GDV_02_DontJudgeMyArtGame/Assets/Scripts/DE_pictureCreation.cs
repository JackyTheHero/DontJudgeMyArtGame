using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_pictureCreation : MonoBehaviour
{
    //Liste der Bilder
    public List<Picture> gallery = new List<Picture>();

    //Bilderklasse
    public class Picture
    {
        //Globale Variablen
        float posX, posZ, sizeX, sizeY, height, rotation;
        //textureID aktuell unbenutzt, wichtig für unterschiedliche Bilder
        int owned, textureID;

        //KONSTRUKTOR
        // @param posX : X-Koordinate der Bildmitte
        // @param posZ : Z-Koordinate der Bildmitte
        // @param sizeX : Breite des Bildes ausgehend von Bildmitte
        // @param sizeY : Höhe des Bildes ausgehend von unterem Bildrand
        // @param height : Abstand des unteren Bildrandes zum Boden
        // @param rotation: Ausrichtung
        // @param owned: Ob das Bild dem Spieler gehört, legt außerdem fest ob Plakette erzeugt wird und auf welcher Seite (0: keine Plakette, 1: links, 2: rechts)
        public Picture(float posX, float posZ, float sizeX, float sizeY, float height, float rotation, int owned/*, int textureID*/){
            this.posX = posX;
            this.posZ = posZ;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.height = height;
            this.rotation = rotation;
            this.owned = owned;
            //this.textureID = textureID;
        }
    
        //Funktion zum Erzeugen von Bildern (Bild, Rahmen, Plakette)
        public void createPicture(int i){

            //Breite des Bilderrahmens an den Rändern (Thickness)
            float thick = 0.3f;
            //Tiefe des inneren Bilderrahmens, zusammen mit Abstand ergibt es Gesamtdicke des Bilderrahmens 
            float depth = -0.3f;
            //Abstand des Bildes zur Wand
            float dist = -0.2f;

            //GameObject erzeugen
            GameObject pic = new GameObject();
            pic.name = "Bild" + i;
            pic.AddComponent<MeshFilter>();
            pic.AddComponent<MeshRenderer>();

            //Bild erzeugen
            Mesh picMesh = pic.GetComponent<MeshFilter>().mesh;
            
            //Arrays für Bildfläche
            picMesh.vertices = new Vector3[] {new Vector3(-sizeX / 2, -sizeY / 2, dist), new Vector3(sizeX / 2, -sizeY / 2, dist), new Vector3(sizeX / 2, sizeY / 2, dist), new Vector3(-sizeX / 2, sizeY / 2, dist)};
            picMesh.triangles = new int[] {3, 2, 1, 3, 1, 0};
            picMesh.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(1,1), new Vector2(0,1)};

            picMesh.RecalculateBounds();

            //Renderer
            Renderer picRend = pic.GetComponent<Renderer>();
            picRend.material= new Material(Shader.Find("Standard"));
            picRend.material.mainTexture = Resources.Load("testbild") as Texture;

            picMesh.RecalculateNormals();

            //Rahmen erzeugen
            GameObject frame = new GameObject();
            frame.name = "Rahmen" + i;
            frame.AddComponent<MeshFilter>();
            frame.AddComponent<MeshRenderer>();

            //Mesh erzeugen
            Mesh frameMesh = frame.GetComponent<MeshFilter>().mesh;
                   
            //Arrays für Rahmen
            frameMesh.vertices = new Vector3[] {
                new Vector3(-sizeX / 2 - thick, -sizeY / 2 -thick, depth),
                new Vector3(-sizeX / 2 - thick, -sizeY / 2 -thick, depth), 
                new Vector3(-sizeX / 2 - thick, -sizeY / 2 -thick, depth), 
                new Vector3(sizeX / 2 + thick, -sizeY / 2 -thick, depth),
                new Vector3(sizeX / 2 + thick, -sizeY / 2 -thick, depth),
                new Vector3(sizeX / 2 + thick, -sizeY / 2 -thick, depth),
                new Vector3(sizeX / 2 + thick, sizeY / 2 + thick, depth),
                new Vector3(sizeX / 2 + thick, sizeY / 2 + thick, depth),
                new Vector3(sizeX / 2 + thick, sizeY / 2 + thick, depth),
                new Vector3(-sizeX / 2 - thick, sizeY / 2 + thick, depth),
                new Vector3(-sizeX / 2 - thick, sizeY / 2 + thick, depth),
                new Vector3(-sizeX / 2 - thick, sizeY / 2 + thick, depth),
                new Vector3(-sizeX / 2 - thick, -sizeY / 2 -thick, 0),
                new Vector3(-sizeX / 2 - thick, -sizeY / 2 -thick, 0), 
                new Vector3(sizeX / 2 + thick, -sizeY / 2 -thick, 0),
                new Vector3(sizeX / 2 + thick, -sizeY / 2 -thick, 0),
                new Vector3(sizeX / 2 + thick, sizeY / 2 + thick, 0),
                new Vector3(sizeX / 2 + thick, sizeY / 2 + thick, 0),
                new Vector3(-sizeX / 2 - thick, sizeY / 2 + thick, 0),
                new Vector3(-sizeX / 2 - thick, sizeY / 2 + thick, 0),
                new Vector3(-sizeX / 2, -sizeY / 2, depth),
                new Vector3(-sizeX / 2, -sizeY / 2, depth),
                new Vector3(-sizeX / 2, -sizeY / 2, depth),
                new Vector3(sizeX / 2, -sizeY / 2, depth),
                new Vector3(sizeX / 2, -sizeY / 2, depth),
                new Vector3(sizeX / 2, -sizeY / 2, depth), 
                new Vector3(sizeX / 2, sizeY / 2 , depth),
                new Vector3(sizeX / 2, sizeY / 2 , depth),
                new Vector3(sizeX / 2, sizeY / 2 , depth),
                new Vector3(-sizeX / 2, sizeY / 2 , depth),
                new Vector3(-sizeX / 2, sizeY / 2 , depth),
                new Vector3(-sizeX / 2, sizeY / 2 , depth),
                new Vector3(-sizeX / 2, -sizeY / 2, dist),
                new Vector3(-sizeX / 2, -sizeY / 2, dist),  
                new Vector3(sizeX / 2 , -sizeY / 2, dist), 
                new Vector3(sizeX / 2 , -sizeY / 2, dist),  
                new Vector3(sizeX / 2 , sizeY / 2 , dist), 
                new Vector3(sizeX / 2 , sizeY / 2 , dist),  
                new Vector3(-sizeX / 2, sizeY / 2 , dist),
                new Vector3(-sizeX / 2, sizeY / 2 , dist)
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
            painting.name = "Gemälde" + i;

            //Prüfen ob Spielergemälde
            if(owned != 0){

                //Plakette erzeugen
                GameObject sign = new GameObject();
                sign.name = "Plakette" + i;
                sign.AddComponent<MeshFilter>();
                sign.AddComponent<MeshRenderer>();

                //Besitz im Namen festlegen
                painting.name = "Gemälde" + i + "owned";

                //Mesh erzeugen
                Mesh signMesh = sign.GetComponent<MeshFilter>().mesh;
                
                //Abstand der Plakette zum Bild
                float links = (-sizeX / 2) - thick - 1.7f;
                float rechts = (sizeX / 2) + thick + 1.7f;

                //Arrays für Plakette
                //Tenärer Operator für links oder rechts
                signMesh.vertices = new Vector3[] {
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
            painting.transform.Translate(posX, height + sizeY / 2, posZ);
            painting.transform.Rotate(0, rotation, 0); 
            
            //Collider hinzufügen
            BoxCollider boxCollider = painting.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(sizeX,sizeY,1);
            boxCollider.isTrigger = true; 
        }
    }

    void Start()
    {
        //Erzeugt Bilder bei Start und füge Liste hinzu

        gallery.Add(new Picture(30f, 37f, 6f, 4f, 2f, 0f, 0)); 
        gallery.Add(new Picture(63f, 37f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(70f, 27f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(70f, 14f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(70f, 1f, 6f, 4f, 2f, 90f, 1));
        gallery.Add(new Picture(70f, -30f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(50f, -39f, 6f, 4f, 2f, 180f, 0));

        gallery.Add(new Picture(28f, 39f, 6f, 4f, 2f, 180f, 2));
        gallery.Add(new Picture(14f, 49f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(14f, 79f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(26f, 89f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(58f, 89f, 6f, 4f, 2f, 0f, 1));
        gallery.Add(new Picture(70f, 49f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(70f, 79f, 6f, 4f, 2f, 90f, 0));

        gallery.Add(new Picture(43f, -41f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(52f, -57f, 6f, 4f, 2f, 90f, 1));
        gallery.Add(new Picture(52f, -95f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(20f, -109f, 6f, 4f, 2f, 180f, 1));
        gallery.Add(new Picture(46f, -109f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(14f, -82f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(14f, -68f, 6f, 4f, 2f, 270f, 0));

        gallery.Add(new Picture(70f, -41f, 6f, 4f, 2f, 0, 0));
        gallery.Add(new Picture(110f, -41f, 6f, 4f, 2f, 0, 0));
        gallery.Add(new Picture(122f, -53f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(122f, -66f, 6f, 4f, 2f, 90f, 2));
        gallery.Add(new Picture(122f, -79f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(88f, -109f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(54f, -95f, 6f, 4f, 2f, 270f, 2));
        gallery.Add(new Picture(54f, -55f, 6f, 4f, 2f, 270f, 0));
        
        gallery.Add(new Picture(91f, 7f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(122f, -4f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(122f, -28f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(108f, -39f, 6f, 4f, 2f, 180f, 2));
        gallery.Add(new Picture(72f, -4f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(72f, -28f, 6f, 4f, 2f, 270f, 0));

        gallery.Add(new Picture(138f, -41f, 6f, 4f, 2f, 0f, 1));
        gallery.Add(new Picture(184f, -41f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(192f, -66f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(192f, -84f, 6f, 4f, 2f, 90f, 2));
        gallery.Add(new Picture(158f, -109f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(131f, -109f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(124f, -53f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(124f, -66f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(124f, -79f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(150f, -74.5f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(166f, -74.5f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(166f, -75.5f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(150f, -75.5f, 6f, 4f, 2f, 0f, 2));

        gallery.Add(new Picture(137f, 7f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(153f, 7f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(192f, -29f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(192f, -3f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(153f, -39f, 6f, 4f, 2f, 180f, 2));
        gallery.Add(new Picture(137f, -39f, 6f, 4f, 2f, 180f, 0));
        gallery.Add(new Picture(124f, -30f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(124f, -2f, 6f, 4f, 2f, 270f, 1));

        gallery.Add(new Picture(168f, 89f, 6f, 4f, 2f, 0f, 0));
        gallery.Add(new Picture(192f, 37.5f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(192f, 49f, 6f, 4f, 2f, 90f, 1));
        gallery.Add(new Picture(192f, 61f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(144f, 49f, 6f, 4f, 2f, 270f, 2));
        gallery.Add(new Picture(144f, 72f, 6f, 4f, 2f, 270f, 0));

        gallery.Add(new Picture(142f, 80f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(142f, 65f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(142f, 50f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(72f, 28f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(72f, 45f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(72f, 79f, 6f, 4f, 2f, 270f, 0));       
        gallery.Add(new Picture(118.5f, 46f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(118.5f, 62f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(118.5f, 78f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(119.5f, 46f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(119.5f, 62f, 6f, 4f, 2f, 270f, 1));
        gallery.Add(new Picture(119.5f, 78f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(94.5f, 46f, 6f, 4f, 2f, 90f, 2));
        gallery.Add(new Picture(94.5f, 62f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(94.5f, 78f, 6f, 4f, 2f, 90f, 0));
        gallery.Add(new Picture(95.5f, 46f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(95.5f, 62f, 6f, 4f, 2f, 270f, 0));
        gallery.Add(new Picture(95.5f, 78f, 6f, 4f, 2f, 270f, 1));

        for(int i = 0; i < gallery.Count; i++){
            gallery[i].createPicture(i);
        }       
    }

    // Update bis jetzt leer
    void Update()
    {
        
    }
    
}