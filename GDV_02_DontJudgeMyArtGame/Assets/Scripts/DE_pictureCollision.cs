using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_pictureCollision : MonoBehaviour
{
    //Variable für Aufenthalt in Bereich
    public static bool isInPictureRange = false;

    //Variable für aktuelles Gemälde
    public static GameObject focusPicture;

    //Prüft ob Spieler in Gemäldebereich
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Length >= 7){
            //Check ob vom Typ Gemälde
            if (other.gameObject.name.Substring(0, 7) == "Gemälde") {
                //Jetzt im Bereich
                isInPictureRange = true;
                //speichere Referenz auf das Gemälde
                focusPicture = other.gameObject;
            } 
        }  
    }

     //Prüft ob Spieler nicht mehr in Gemäldebereich
    void OnTriggerExit(Collider other) {
        //Check ob vom Typ Gemälde
        if (other.gameObject.name.Length >= 7){
            if (other.gameObject.name.Substring(0, 7) == "Gemälde") {
                //Nicht mehr im Bereich
                isInPictureRange = false;
                //Lösche Referenz auf das Gemälde
                focusPicture = null;
            }
        }
    }

    //Aufruf für Kameraschwenk
    
    void Update () 
    { 
        DE_cameraPan.checkCameraPan();
    }
    
}
