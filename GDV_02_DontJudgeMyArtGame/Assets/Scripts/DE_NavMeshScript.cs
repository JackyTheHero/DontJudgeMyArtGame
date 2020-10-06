using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DE_NavMeshScript : MonoBehaviour
{
    
    public NavMeshSurface surface;

    void Start()
    {
        MW_roomScript.CreateWholeBuilding();
        JH_propScript. createAllBenches();
        JH_propScript.createAllStatues();
        DE_pictureCreation.pictureCreation();
        DE_propsCreation.propsCreation();
        JH_LightCreator.AddWindowLighting();
        surface.BuildNavMesh();
    }

}
