using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_propsCreation : MonoBehaviour
{

    static GameObject pillar;
    static GameObject vase;
    static GameObject window;
    
    // Start is called before the first frame update
    public static void propsCreation()
    {
        
        GameObject pillarParent = new GameObject();
        pillarParent.name = "pillarParent";
        createPillar();
        Instantiate(pillar, new Vector3(29, 0, 54), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(29, 0, 74), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(55, 0, 54), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(55, 0, 74), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(146.5f, 0, -16), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(169.5f, 0, -16), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(33, 0, -86.5f), Quaternion.identity, pillarParent.transform);
        Instantiate(pillar, new Vector3(33, 0, -63.5f), Quaternion.identity, pillarParent.transform);
        Destroy(pillar);

        
        GameObject vaseParent = new GameObject();
        vaseParent.name = "vaseParent";
        createVase();
        Instantiate(vase, new Vector3(-8, 0, -12), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(-8, 0, 12), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(75, 0, -36), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(75, 0, 4), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(119, 0, 4), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(119, 0, -36), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(189, 0, -106), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(189, 0, 86), Quaternion.identity, vaseParent.transform);
        Instantiate(vase, new Vector3(147, 0, 86), Quaternion.identity, vaseParent.transform);
        Destroy(vase);

        
        GameObject windowParent = new GameObject();
        windowParent.name = "windowParent";
        createWindow(false);
        Instantiate(window, new Vector3(3, 6, 15), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(3, 6, -15),  Quaternion.Euler(0,180,0), windowParent.transform);
        Instantiate(window, new Vector3(14, 6, 26), Quaternion.Euler(0,270,0), windowParent.transform);
        Instantiate(window, new Vector3(14, 6, -26),  Quaternion.Euler(0,270,0), windowParent.transform);
        Instantiate(window, new Vector3(14, 6, -99),  Quaternion.Euler(0,270,0), windowParent.transform);
        Instantiate(window, new Vector3(14, 6, 64),  Quaternion.Euler(0,270,0), windowParent.transform);
        Instantiate(window, new Vector3(192, 6, -97),  Quaternion.Euler(0,90,0), windowParent.transform);
        Instantiate(window, new Vector3(192, 6, -53),  Quaternion.Euler(0,90,0), windowParent.transform);
        Instantiate(window, new Vector3(192, 6, -16),  Quaternion.Euler(0,90,0), windowParent.transform);
        Instantiate(window, new Vector3(192, 6, 75),  Quaternion.Euler(0,90,0), windowParent.transform);
        Instantiate(window, new Vector3(192, 6, 23),  Quaternion.Euler(0,90,0), windowParent.transform);
        Instantiate(window, new Vector3(42, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(83, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(131, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(157, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(179, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(33, 6, -109), Quaternion.Euler(0,180,0), windowParent.transform);
        Instantiate(window, new Vector3(70, 6, -109), Quaternion.Euler(0,180,0), windowParent.transform);
        Instantiate(window, new Vector3(106, 6, -109), Quaternion.Euler(0,180,0), windowParent.transform);
        Instantiate(window, new Vector3(144, 6, -109), Quaternion.Euler(0,180,0), windowParent.transform);
        Destroy(window);

        createWindow(true);
        Instantiate(window, new Vector3(14, 6, -51),  Quaternion.Euler(0,270,0), windowParent.transform);
        Instantiate(window, new Vector3(107, 6, 89), Quaternion.identity, windowParent.transform);
        Instantiate(window, new Vector3(172, 6, -109), Quaternion.Euler(0,180,0), windowParent.transform);
        Destroy(window);


        createDesk();

    }

    //SÄULE================================================================================================================
    static void createPillar(){

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
        pillar = new GameObject();
        pillar.name = "Säule";

        //Parent setzen
        shaft.transform.parent = pillar.transform;
        basis.transform.parent = pillar.transform;

        pillar.transform.Translate(-20, 0, -20);

        BoxCollider boxCollider = pillar.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(5,45,5);
        boxCollider.center =  new Vector3(0,45/2,0);

    }

    //VASE===================================================================================================================
    static void createVase(){

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
        vase = new GameObject();
        vase.name = "Vase";

        //Parent setzen
        vaseBody.transform.parent = vase.transform;
        basis.transform.parent = vase.transform;

        //Translation
        vase.transform.Translate(-20, 0, -20);

        BoxCollider boxCollider = vase.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(4,heightVaseTop + heightBasis,4);
        boxCollider.center =  new Vector3(0,(heightVaseTop + heightBasis) / 2,0);

    }

    //FENSTER===========================================================================================================
    static void createWindow(bool open){
        
        //Breite des Fensterrahmens an den Rändern (Thickness)
        float thick = 0.5f;
        float thickHalf = thick / 2;
        float thickExtra = thick + thickHalf;
        //Tiefe des Fensterrahmens
        float depth = -0.4f;
        float depthInner = -0.3f;
        //Abstand der Scheibe zur Wand
        float dist = -0.01f;

        //Halbe Größen des Fensters
        float sizeXhalf = 4;
        float sizeYhalf = 4;

        //GameObject erzeugen
        GameObject pane = new GameObject();
        pane.name = "Scheine";
        pane.AddComponent<MeshFilter>();
        pane.AddComponent<MeshRenderer>();

        //Scheibe erzeugen
        Mesh paneMesh = pane.GetComponent<MeshFilter>().mesh;
        
        //Arrays für Scheibe
        paneMesh.vertices = new Vector3[] {new Vector3(-sizeXhalf, -sizeYhalf, dist), new Vector3(sizeXhalf, -sizeYhalf, dist), new Vector3(sizeXhalf, sizeYhalf, dist), new Vector3(-sizeXhalf, sizeYhalf, dist)};
        paneMesh.triangles = new int[] {3, 2, 1, 3, 1, 0};
        paneMesh.uv = new Vector2[] {new Vector2(0,0), new Vector2(1,0), new Vector2(1,1), new Vector2(0,1)};

        paneMesh.RecalculateBounds();

        //Renderer
        Renderer paneRend = pane.GetComponent<Renderer>();
        paneRend.material= new Material(Shader.Find("Legacy Shaders/Self-Illumin/Diffuse"));
        if(open){
            paneRend.material.mainTexture = Resources.Load("open") as Texture;
        } else{
            paneRend.material.mainTexture = Resources.Load("closed") as Texture;
        }
    
        paneRend.material.SetColor("_Color", new Color(0.5f,0.5f,0.5f));

        paneMesh.RecalculateNormals();

        //Rahmen erzeugen
        GameObject frame = new GameObject();
        frame.name = "Rahmen";
        frame.AddComponent<MeshFilter>();
        frame.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh frameMesh = frame.GetComponent<MeshFilter>().mesh;
                
        if(open){
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
                new Vector3(-sizeXhalf, sizeYhalf , dist),
                new Vector3(-sizeXhalf, -thickHalf, dist),
                new Vector3(-sizeXhalf, thickHalf, dist),
                new Vector3(sizeXhalf, -thickHalf, dist),
                new Vector3(sizeXhalf, thickHalf, dist),
                new Vector3(-sizeXhalf, -thickHalf, depthInner),
                new Vector3(-sizeXhalf, -thickHalf, depthInner),
                new Vector3(-sizeXhalf, thickHalf, depthInner),
                new Vector3(-sizeXhalf, thickHalf, depthInner),
                new Vector3(sizeXhalf, -thickHalf, depthInner),
                new Vector3(sizeXhalf, -thickHalf, depthInner),
                new Vector3(sizeXhalf, thickHalf, depthInner),
                new Vector3(sizeXhalf, thickHalf, depthInner),
                new Vector3(-thickHalf, sizeYhalf, dist),
                new Vector3(thickHalf, sizeYhalf, dist),
                new Vector3(-thickHalf, thickHalf, dist),
                new Vector3(thickHalf, thickHalf, dist),
                new Vector3(-thickHalf, sizeYhalf, depthInner),
                new Vector3(-thickHalf, sizeYhalf, depthInner),
                new Vector3(thickHalf, sizeYhalf, depthInner),
                new Vector3(thickHalf, sizeYhalf, depthInner),
                new Vector3(-thickHalf, thickHalf, depthInner),
                new Vector3(-thickHalf, thickHalf, depthInner),
                new Vector3(thickHalf, thickHalf, depthInner),
                new Vector3(thickHalf, thickHalf, depthInner),
                new Vector3(-sizeXhalf, -thickExtra,  dist),
                new Vector3(sizeXhalf, -thickExtra,  dist),
                new Vector3(-sizeXhalf, -thickExtra, depth),
                new Vector3(sizeXhalf, -thickExtra, depth),
                new Vector3(-sizeXhalf, -thickExtra, depth),
                new Vector3(sizeXhalf, -thickExtra, depth),
                new Vector3(-sizeXhalf, -thickHalf, depth),
                new Vector3(sizeXhalf, -thickHalf, depth),
                new Vector3(-sizeXhalf, -thickHalf, depth),
                new Vector3(sizeXhalf, -thickHalf, depth),
                new Vector3(-sizeXhalf, -thickHalf,  dist),
                new Vector3(sizeXhalf, -thickHalf,  dist),


            };

            frameMesh.triangles = new int[] {0,20,23,0,23,3, 3,23,26,3,26,6, 6,26,29,6,29,9, 0,9,29,0,29,20, 1,5,14,1,14,13, 4,8,16,4,16,15, 7,11,18,7,18,17, 10,2,12,10,12,19, 22,33,34,22,34,24, 25,35,36,25,36,27, 28,37,38,28,38,30, 21,31,39,21,39,32,
            40,44,48,40,48,42, 46,41,43,46,43,50, 45,47,51,45,51,49, 52,56,60,52,60,54, 58,53,55,58,55,62, 57,59,63,57,63,61, 64,66,67,64,67,65, 68,70,71,68,71,69, 72,74,75,72,75,73 };

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
                new Vector2(1,0), new Vector2(1,0),
                new Vector2(0,0),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(1,1)
            };

        } else{
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
                new Vector3(-sizeXhalf, sizeYhalf , dist),
                new Vector3(-sizeXhalf, -thickHalf, dist),
                new Vector3(-sizeXhalf, thickHalf, dist),
                new Vector3(sizeXhalf, -thickHalf, dist),
                new Vector3(sizeXhalf, thickHalf, dist),
                new Vector3(-sizeXhalf, -thickHalf, depthInner),
                new Vector3(-sizeXhalf, -thickHalf, depthInner),
                new Vector3(-sizeXhalf, thickHalf, depthInner),
                new Vector3(-sizeXhalf, thickHalf, depthInner),
                new Vector3(sizeXhalf, -thickHalf, depthInner),
                new Vector3(sizeXhalf, -thickHalf, depthInner),
                new Vector3(sizeXhalf, thickHalf, depthInner),
                new Vector3(sizeXhalf, thickHalf, depthInner),
                new Vector3(-thickHalf, sizeYhalf, dist),
                new Vector3(thickHalf, sizeYhalf, dist),
                new Vector3(-thickHalf, thickHalf, dist),
                new Vector3(thickHalf, thickHalf, dist),
                new Vector3(-thickHalf, sizeYhalf, depthInner),
                new Vector3(-thickHalf, sizeYhalf, depthInner),
                new Vector3(thickHalf, sizeYhalf, depthInner),
                new Vector3(thickHalf, sizeYhalf, depthInner),
                new Vector3(-thickHalf, thickHalf, depthInner),
                new Vector3(-thickHalf, thickHalf, depthInner),
                new Vector3(thickHalf, thickHalf, depthInner),
                new Vector3(thickHalf, thickHalf, depthInner),
                new Vector3(thickHalf, -sizeYhalf, dist),
                new Vector3(-thickHalf, -sizeYhalf, dist),
                new Vector3(thickHalf, -thickHalf, dist),
                new Vector3(-thickHalf, -thickHalf, dist),
                new Vector3(thickHalf, -sizeYhalf, depthInner),
                new Vector3(thickHalf, -sizeYhalf, depthInner),
                new Vector3(-thickHalf, -sizeYhalf, depthInner),
                new Vector3(-thickHalf, -sizeYhalf, depthInner),
                new Vector3(thickHalf, -thickHalf, depthInner),
                new Vector3(thickHalf, -thickHalf, depthInner),
                new Vector3(-thickHalf, -thickHalf, depthInner),
                new Vector3(-thickHalf, -thickHalf, depthInner)  
            };

            frameMesh.triangles = new int[] {0,20,23,0,23,3, 3,23,26,3,26,6, 6,26,29,6,29,9, 0,9,29,0,29,20, 1,5,14,1,14,13, 4,8,16,4,16,15, 7,11,18,7,18,17, 10,2,12,10,12,19, 22,33,34,22,34,24, 25,35,36,25,36,27, 28,37,38,28,38,30, 21,31,39,21,39,32,
            40,44,48,40,48,42, 46,41,43,46,43,50, 45,47,51,45,51,49, 52,56,60,52,60,54, 58,53,55,58,55,62, 57,59,63,57,63,61, 64,68,72,64,72,66, 70,65,67,70,67,74, 69,71,75,69,75,73};

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
                new Vector2(1,0), new Vector2(1,0),
                new Vector2(0,0),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(1,1),
                new Vector2(0,0),
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(1,1)
            };
        }

        frameMesh.RecalculateBounds();

        //Renderer
        Renderer frameRend = frame.GetComponent<Renderer>();
        frameRend.material= new Material(Shader.Find("Standard"));
        frameRend.material.mainTexture = Resources.Load("holz") as Texture;

        frameMesh.RecalculateNormals();

        //Parent Fenster erzeugen
        window = new GameObject();
        window.name = "Fenster";

         if(open){
            window.name = "FensterOffen"; 
        } 
    	
        //Parent setzen
        pane.transform.parent = window.transform;
        frame.transform.parent = window.transform;

        window.transform.Translate(-20,0,-20);
        
        if(open){
        //Collider hinzufügen
        BoxCollider boxCollider = window.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(sizeXhalf * 2,sizeYhalf * 2,2);
        boxCollider.center =  new Vector3(0,0,-1);
        boxCollider.isTrigger = true;
        }

    }

    //SCHALTER===========================================================================================================

    static void createDesk(){

         float height = 2;

        //GameObject für Schalter
        GameObject desk = new GameObject();
        desk.name = "desk";
        desk.AddComponent<MeshFilter>();
        desk.AddComponent<MeshRenderer>();

        //Schaltermesh erzeugen
        Mesh deskMesh = desk.GetComponent<MeshFilter>().mesh;
        
        //Arrays
        deskMesh.vertices = new Vector3[] {
            new Vector3(-12.5f,0,-5),
            new Vector3(-12.5f,0,-5),
            new Vector3(-12.5f,0,5),
            new Vector3(-12.5f,0,5),
            new Vector3(-7.5f,0,5),
            new Vector3(-7.5f,0,5),
            new Vector3(-7.5f,0,0),
            new Vector3(-7.5f,0,0),
            new Vector3(7.5f,0,0),
            new Vector3(7.5f,0,0),
            new Vector3(7.5f,0,5),
            new Vector3(7.5f,0,5),
            new Vector3(12.5f,0,5),
            new Vector3(12.5f,0,5),
            new Vector3(12.5f,0,-5),
            new Vector3(12.5f,0,-5),
            new Vector3(-12.5f,height,-5),
            new Vector3(-12.5f,height,-5),
            new Vector3(-12.5f,height,-5),
            new Vector3(-12.5f,height,5),
            new Vector3(-12.5f,height,5),
            new Vector3(-12.5f,height,5),
            new Vector3(-7.5f,height,5),
            new Vector3(-7.5f,height,5),
            new Vector3(-7.5f,height,5),
            new Vector3(-7.5f,height,0),
            new Vector3(-7.5f,height,0),
            new Vector3(-7.5f,height,0),
            new Vector3(7.5f,height,0),
            new Vector3(7.5f,height,0),
            new Vector3(7.5f,height,0),
            new Vector3(7.5f,height,5),
            new Vector3(7.5f,height,5),
            new Vector3(7.5f,height,5),
            new Vector3(12.5f,height,5),
            new Vector3(12.5f,height,5),
            new Vector3(12.5f,height,5),
            new Vector3(12.5f,height,-5),
            new Vector3(12.5f,height,-5),
            new Vector3(12.5f,height,-5)
        }; 

        deskMesh.triangles = new int[] {1,2,19,1,19,17, 3,4,22,3,22,20, 5,6,25,5,25,23, 7,8,28,7,28,26, 9,10,31,9,31,29, 11,12,34,11,34,32, 13,14,37,13,37,35, 15,0,16,15,16,38, 
        18,21,24,18,24,27,18,27,30,18,30,39,30,33,36,30,36,39};

        deskMesh.uv = new Vector2[] {
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
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,2), 
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(1,2), 
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,2), 
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(1,2),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(1,0)   
        };

        deskMesh.RecalculateBounds();

        //Renderer
        Renderer deskRend = desk.GetComponent<Renderer>();
        deskRend.material= new Material(Shader.Find("Standard"));
        deskRend.material.mainTexture = Resources.Load("holz") as Texture;

        deskMesh.RecalculateNormals();

        desk.transform.Translate(42.5f,0,0);
        desk.transform.Rotate(0,90,0);

        BoxCollider boxColliderCenter = desk.AddComponent<BoxCollider>();
        boxColliderCenter.size = new Vector3(25,2,5);
        boxColliderCenter.center =  new Vector3(0,1,-2.5f);

        BoxCollider boxColliderLeft = desk.AddComponent<BoxCollider>();
        boxColliderLeft.size = new Vector3(5,2,5);
        boxColliderLeft.center =  new Vector3(10,1,2.5f);

        BoxCollider boxColliderRight = desk.AddComponent<BoxCollider>();
        boxColliderRight.size = new Vector3(5,2,5);
        boxColliderRight.center =  new Vector3(-10,1,2.5f);

    }

}
