using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darius_BildScript_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createBild(0f, 0f);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBild(float posX, float posZ){

        //GameObject erzeugen
        GameObject bild = new GameObject();

        bild.AddComponent<MeshFilter>();
        bild.AddComponent<MeshRenderer>();

        //Mesh erzeugen
        Mesh bildflaeche = bild.GetComponent<MeshFilter>().mesh;
        
        //Arrays für Bildfläche
        bildflaeche.vertices = new Vector3[] {new Vector3(0 + posX, 2, 0 + posZ), new Vector3(3 + posX, 2, 0 + posZ), new Vector3(3+ posX, 4, 0 + posZ), new Vector3(0 + posX, 4, 0 + posZ)};
        bildflaeche.triangles = new int[] {3, 2, 1, 3, 1, 0};

        //Berechne uvs
        Vector3[] vertices = bildflaeche.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        bildflaeche.uv = uvs;

        bildflaeche.RecalculateBounds();

        //Renderer
        Renderer rend = bild.GetComponent<Renderer>();
        rend.material= new Material(Shader.Find("Standard"));
        rend.material.color = Color.blue;

        bildflaeche.RecalculateNormals();
    }
}
