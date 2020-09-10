using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_propsCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createPillar(29, 54);
        createPillar(29, 74);
        createPillar(55, 54);
        createPillar(55, 74);
        createPillar(146.5f, -16);
        createPillar(169.5f, -16);
        createPillar(33, -86.5f);
        createPillar(33, -63.5f);

    }

    void createPillar(float posX, float posZ){

        //Variablen für Sockelhöhe und Säulenhöhe
        float heightBasis = 1;
        float heightPillar = 45 - heightBasis;

        //halbe Breite des Säulenschafts
        float width = 2;

        //halbe Seitenlänge
        float side = width / (1 + Mathf.Sqrt(2f));

        //Säulenschaft===================================================
        GameObject shaft = new GameObject();
        shaft.name = "Säulenschaft";
        shaft.AddComponent<MeshFilter>();
        shaft.AddComponent<MeshRenderer>();

        //Säulenschaft erzeugen
        Mesh shaftMesh = shaft.GetComponent<MeshFilter>().mesh;
        
        //Arrays
        shaftMesh.vertices = new Vector3[] {
            new Vector3(-width, heightBasis, -side),
            new Vector3(-width, heightBasis, -side),  
            new Vector3(-width, heightBasis, side),
            new Vector3(-width, heightBasis, side), 
            new Vector3(-side, heightBasis, width), 
            new Vector3(-side, heightBasis, width), 
            new Vector3(side, heightBasis, width), 
            new Vector3(side, heightBasis, width),  
            new Vector3(width, heightBasis, side), 
            new Vector3(width, heightBasis, side), 
            new Vector3(width, heightBasis, -side), 
            new Vector3(width, heightBasis, -side), 
            new Vector3(side, heightBasis, -width), 
            new Vector3(side, heightBasis, -width), 
            new Vector3(-side, heightBasis, -width), 
            new Vector3(-side, heightBasis, -width),
            new Vector3(-width, heightPillar, -side),
            new Vector3(-width, heightPillar, -side),  
            new Vector3(-width, heightPillar, side),
            new Vector3(-width, heightPillar, side), 
            new Vector3(-side, heightPillar, width), 
            new Vector3(-side, heightPillar, width), 
            new Vector3(side, heightPillar, width), 
            new Vector3(side, heightPillar, width),  
            new Vector3(width, heightPillar, side), 
            new Vector3(width, heightPillar, side), 
            new Vector3(width, heightPillar, -side), 
            new Vector3(width, heightPillar, -side), 
            new Vector3(side, heightPillar, -width), 
            new Vector3(side, heightPillar, -width), 
            new Vector3(-side, heightPillar, -width), 
            new Vector3(-side, heightPillar, -width)
        }; 

        shaftMesh.triangles = new int[] {1,2,18,1,18,17, 3,4,20,3,20,19, 5,6,22,5,22,21, 7,8,24,7,24,23, 9,10,26,9,26,25, 11,12,28,11,28,27, 13,14,30,13,30,29, 15,0,16,15,16,31};

        shaftMesh.uv = new Vector2[] {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12),
            new Vector2(0,12),
            new Vector2(1,12)
        };

        shaftMesh.RecalculateBounds();

        //Renderer
        Renderer shaftRend = shaft.GetComponent<Renderer>();
        shaftRend.material= new Material(Shader.Find("Standard"));
        shaftRend.material.mainTexture = Resources.Load("marbleTexture") as Texture;
        shaftRend.material.mainTextureOffset = new Vector2(Random.value, Random.value);

        shaftMesh.RecalculateNormals();

        //Sockel für Säule===============================================
        GameObject basis = new GameObject();
        basis.name = "Sockel";
        basis.AddComponent<MeshFilter>();
        basis.AddComponent<MeshRenderer>();

        //Sockel erzeugen
        Mesh basisMesh = basis.GetComponent<MeshFilter>().mesh;

        //Arrays
        basisMesh.vertices = new Vector3[] {
            new Vector3(-2.5f, 0, -2.5f),
            new Vector3(-2.5f, 0, -2.5f),  
            new Vector3(-2.5f, 0, 2.5f),
            new Vector3(-2.5f, 0, 2.5f),  
            new Vector3(2.5f, 0, 2.5f),
            new Vector3(2.5f, 0, 2.5f), 
            new Vector3(2.5f, 0, -2.5f),
            new Vector3(2.5f, 0, -2.5f),
            new Vector3(-2.5f, heightBasis, -2.5f),
            new Vector3(-2.5f, heightBasis, -2.5f),
            new Vector3(-2.5f, heightBasis, -2.5f),
            new Vector3(-2.5f, heightBasis, 2.5f),
            new Vector3(-2.5f, heightBasis, 2.5f),
            new Vector3(-2.5f, heightBasis, 2.5f),
            new Vector3(2.5f, heightBasis, 2.5f),
            new Vector3(2.5f, heightBasis, 2.5f),
            new Vector3(2.5f, heightBasis, 2.5f),
            new Vector3(2.5f, heightBasis, -2.5f),
            new Vector3(2.5f, heightBasis, -2.5f),
            new Vector3(2.5f, heightBasis, -2.5f)         
        };

        basisMesh.triangles = new int[] {0,8,18,0,18,7, 1,2,11,1,11,9, 3,4,14,3,14,12, 5,6,17,5,17,15, 10,13,16,10,16,19};

        basisMesh.uv = new Vector2[] {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)         
        };

        basisMesh.RecalculateBounds();

        //Renderer
        Renderer basisRend = basis.GetComponent<Renderer>();
        basisRend.material= new Material(Shader.Find("Standard"));
        basisRend.material.mainTexture = Resources.Load("marbleTexture") as Texture;
        basisRend.material.mainTextureOffset = new Vector2(Random.value, Random.value);

        basisMesh.RecalculateNormals();

        //Parent erzeugen=================================================
        GameObject pillar = new GameObject();
        pillar.name = "Säule";

        //Parent setzen
        shaft.transform.parent = pillar.transform;
        basis.transform.parent = pillar.transform;

        //Translation
        pillar.transform.Translate(posX, 0, posZ);

        BoxCollider boxCollider = pillar.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(5,45,5);
        boxCollider.center =  new Vector3(0,45/2,0);

    }

    void createVase(float posX, float posZ){

    }

    void createWindow(float posX, float posZ, int open){

    }

}
