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
        createVase(-8,-12);
        createVase(-8,12);
        createVase(75,-36);
        createVase(75,4);
        createVase(119,4);
        createVase(119,-36);
        createVase(189,-106);
        createVase(189,86);
        createVase(147,86);

    }

    //SÄULE================================================================================================================
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

    //VASE===================================================================================================================
    void createVase(float posX, float posZ){

        //Variablen für Sockelhöhe und Vasenhöhe
        float heightBasis = 0.5f;
        float heightVaseBig = 2 + heightBasis;
        float heightVaseSmall = 4 + heightBasis;
        float heightVaseTop = 6 + heightBasis;
        
        //halbe Breiten der Vasen
        float widthBottom = 0.6f;
        float widthBig = 1.5f;
        float widthSmall = 0.4f;
        float widthTop = 0.8f;

        //halbe Seitenlängen
        float sideBottom = widthBottom / (1 + Mathf.Sqrt(2f));
        float sideTop = widthTop / (1 + Mathf.Sqrt(2f));
        float sideSmall = widthSmall / (1 + Mathf.Sqrt(2f));
        float sideBig = widthBig / (1 + Mathf.Sqrt(2f));

        //Säulenschaft===================================================
        GameObject vaseBody = new GameObject();
        vaseBody.name = "Vasenkörper";
        vaseBody.AddComponent<MeshFilter>();
        vaseBody.AddComponent<MeshRenderer>();

        //Säulenschaft erzeugen
        Mesh vaseBodyMesh = vaseBody.GetComponent<MeshFilter>().mesh;
        
        //Arrays
        vaseBodyMesh.vertices = new Vector3[] {
            new Vector3(-widthBottom, heightBasis, -sideBottom),
            new Vector3(-widthBottom, heightBasis, -sideBottom),  
            new Vector3(-widthBottom, heightBasis, sideBottom),
            new Vector3(-widthBottom, heightBasis, sideBottom), 
            new Vector3(-sideBottom, heightBasis, widthBottom), 
            new Vector3(-sideBottom, heightBasis, widthBottom), 
            new Vector3(sideBottom, heightBasis, widthBottom), 
            new Vector3(sideBottom, heightBasis, widthBottom),  
            new Vector3(widthBottom, heightBasis, sideBottom), 
            new Vector3(widthBottom, heightBasis, sideBottom), 
            new Vector3(widthBottom, heightBasis, -sideBottom), 
            new Vector3(widthBottom, heightBasis, -sideBottom), 
            new Vector3(sideBottom, heightBasis, -widthBottom), 
            new Vector3(sideBottom, heightBasis, -widthBottom), 
            new Vector3(-sideBottom, heightBasis, -widthBottom), 
            new Vector3(-sideBottom, heightBasis, -widthBottom),
            new Vector3(-widthBig, heightVaseBig, -sideBig),
            new Vector3(-widthBig, heightVaseBig, -sideBig),  
            new Vector3(-widthBig, heightVaseBig, sideBig),
            new Vector3(-widthBig, heightVaseBig, sideBig), 
            new Vector3(-sideBig, heightVaseBig, widthBig), 
            new Vector3(-sideBig, heightVaseBig, widthBig), 
            new Vector3(sideBig, heightVaseBig, widthBig), 
            new Vector3(sideBig, heightVaseBig, widthBig),  
            new Vector3(widthBig, heightVaseBig, sideBig), 
            new Vector3(widthBig, heightVaseBig, sideBig), 
            new Vector3(widthBig, heightVaseBig, -sideBig), 
            new Vector3(widthBig, heightVaseBig, -sideBig), 
            new Vector3(sideBig, heightVaseBig, -widthBig), 
            new Vector3(sideBig, heightVaseBig, -widthBig), 
            new Vector3(-sideBig, heightVaseBig, -widthBig), 
            new Vector3(-sideBig, heightVaseBig, -widthBig),
            new Vector3(-widthBig, heightVaseBig, -sideBig),
            new Vector3(-widthBig, heightVaseBig, -sideBig),  
            new Vector3(-widthBig, heightVaseBig, sideBig),
            new Vector3(-widthBig, heightVaseBig, sideBig), 
            new Vector3(-sideBig, heightVaseBig, widthBig), 
            new Vector3(-sideBig, heightVaseBig, widthBig), 
            new Vector3(sideBig, heightVaseBig, widthBig), 
            new Vector3(sideBig, heightVaseBig, widthBig),  
            new Vector3(widthBig, heightVaseBig, sideBig), 
            new Vector3(widthBig, heightVaseBig, sideBig), 
            new Vector3(widthBig, heightVaseBig, -sideBig), 
            new Vector3(widthBig, heightVaseBig, -sideBig), 
            new Vector3(sideBig, heightVaseBig, -widthBig), 
            new Vector3(sideBig, heightVaseBig, -widthBig), 
            new Vector3(-sideBig, heightVaseBig, -widthBig), 
            new Vector3(-sideBig, heightVaseBig, -widthBig),
            new Vector3(-widthSmall, heightVaseSmall, -sideSmall),
            new Vector3(-widthSmall, heightVaseSmall, -sideSmall),  
            new Vector3(-widthSmall, heightVaseSmall, sideSmall),
            new Vector3(-widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(-sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, widthSmall),  
            new Vector3(widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, -sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, -sideSmall), 
            new Vector3(sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, -widthSmall),
            new Vector3(-widthSmall, heightVaseSmall, -sideSmall),
            new Vector3(-widthSmall, heightVaseSmall, -sideSmall),  
            new Vector3(-widthSmall, heightVaseSmall, sideSmall),
            new Vector3(-widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(-sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, widthSmall),  
            new Vector3(widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, -sideSmall), 
            new Vector3(widthSmall, heightVaseSmall, -sideSmall), 
            new Vector3(sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, -widthSmall), 
            new Vector3(-sideSmall, heightVaseSmall, -widthSmall),
            new Vector3(-widthTop, heightVaseTop, -sideTop),
            new Vector3(-widthTop, heightVaseTop, -sideTop),  
            new Vector3(-widthTop, heightVaseTop, sideTop),
            new Vector3(-widthTop, heightVaseTop, sideTop), 
            new Vector3(-sideTop, heightVaseTop, widthTop), 
            new Vector3(-sideTop, heightVaseTop, widthTop), 
            new Vector3(sideTop, heightVaseTop, widthTop), 
            new Vector3(sideTop, heightVaseTop, widthTop),  
            new Vector3(widthTop, heightVaseTop, sideTop), 
            new Vector3(widthTop, heightVaseTop, sideTop), 
            new Vector3(widthTop, heightVaseTop, -sideTop), 
            new Vector3(widthTop, heightVaseTop, -sideTop), 
            new Vector3(sideTop, heightVaseTop, -widthTop), 
            new Vector3(sideTop, heightVaseTop, -widthTop), 
            new Vector3(-sideTop, heightVaseTop, -widthTop), 
            new Vector3(-sideTop, heightVaseTop, -widthTop),
            new Vector3(-widthTop, heightVaseTop, -sideTop),
            new Vector3(-widthTop, heightVaseTop, -sideTop),  
            new Vector3(-widthTop, heightVaseTop, sideTop),
            new Vector3(-widthTop, heightVaseTop, sideTop), 
            new Vector3(-sideTop, heightVaseTop, widthTop), 
            new Vector3(-sideTop, heightVaseTop, widthTop), 
            new Vector3(sideTop, heightVaseTop, widthTop), 
            new Vector3(sideTop, heightVaseTop, widthTop),  
            new Vector3(widthTop, heightVaseTop, sideTop), 
            new Vector3(widthTop, heightVaseTop, sideTop), 
            new Vector3(widthTop, heightVaseTop, -sideTop), 
            new Vector3(widthTop, heightVaseTop, -sideTop), 
            new Vector3(sideTop, heightVaseTop, -widthTop), 
            new Vector3(sideTop, heightVaseTop, -widthTop), 
            new Vector3(-sideTop, heightVaseTop, -widthTop), 
            new Vector3(-sideTop, heightVaseTop, -widthTop),
            new Vector3(0, heightVaseTop - 1, 0)
        }; 

        vaseBodyMesh.triangles = new int[] {
            1,2,18,1,18,17, 3,4,20,3,20,19, 5,6,22,5,22,21, 7,8,24,7,24,23, 9,10,26,9,26,25, 11,12,28,11,28,27, 13,14,30,13,30,29, 15,0,16,15,16,31,
            33,34,50,33,50,49, 35,36,52,35,52,51, 37,38,54,37,54,53, 39,40,56,39,56,55, 41,42,58,41,58,57, 43,44,60,43,60,59, 45,46,62,45,62,61, 47,32,48,47,48,63,
            65,66,82,65,82,81, 67,68,84,67,84,83, 69,70,86,69,86,85, 71,72,88,71,88,87, 73,74,90,73,90,89, 75,76,92,75,92,91, 77,78,94,77,94,93, 79,64,80,79,80,95,
            97,98,112, 99,100,112, 101,102,112, 103,104,112, 105,106,112, 107,108,112, 109,110,112, 111,96,112
        };

        vaseBodyMesh.uv = new Vector2[] {
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0.3f,0),
            new Vector2(0.7f,0),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f),
            new Vector2(0,0.3f),
            new Vector2(1,0.3f), 
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.3666f,0.6f),
            new Vector2(0.6333f,0.6f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.2333f,0.9f),
            new Vector2(0.7666f,0.9f),
            new Vector2(0.5f,1)
        };

        vaseBodyMesh.RecalculateBounds();

        //Renderer
        Renderer vaseBodyRend = vaseBody.GetComponent<Renderer>();
        vaseBodyRend.material= new Material(Shader.Find("Standard"));
        vaseBodyRend.material.mainTexture = Resources.Load("vase") as Texture;

        vaseBodyMesh.RecalculateNormals();

        //Sockel für Vase ===============================================
        GameObject basis = new GameObject();
        basis.name = "Sockel";
        basis.AddComponent<MeshFilter>();
        basis.AddComponent<MeshRenderer>();

        //Sockel erzeugen
        Mesh basisMesh = basis.GetComponent<MeshFilter>().mesh;

        //Arrays
        basisMesh.vertices = new Vector3[] {
            new Vector3(-2, 0, -2),
            new Vector3(-2, 0, -2),  
            new Vector3(-2, 0, 2),
            new Vector3(-2, 0, 2),  
            new Vector3(2, 0, 2),
            new Vector3(2, 0, 2), 
            new Vector3(2, 0, -2),
            new Vector3(2, 0, -2),
            new Vector3(-2, heightBasis, -2),
            new Vector3(-2, heightBasis, -2),
            new Vector3(-2, heightBasis, -2),
            new Vector3(-2, heightBasis, 2),
            new Vector3(-2, heightBasis, 2),
            new Vector3(-2, heightBasis, 2),
            new Vector3(2, heightBasis, 2),
            new Vector3(2, heightBasis, 2),
            new Vector3(2, heightBasis, 2),
            new Vector3(2, heightBasis, -2),
            new Vector3(2, heightBasis, -2),
            new Vector3(2, heightBasis, -2)         
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
        GameObject vase = new GameObject();
        vase.name = "Vase";

        //Parent setzen
        vaseBody.transform.parent = vase.transform;
        basis.transform.parent = vase.transform;

        //Translation
        vase.transform.Translate(posX, 0, posZ);

        BoxCollider boxCollider = vase.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(4,heightVaseTop + heightBasis,4);
        boxCollider.center =  new Vector3(0,(heightVaseTop + heightBasis) / 2,0);

    }

    //FENSTER===========================================================================================================
    void createWindow(float posX, float posZ, int open){

    }

}
