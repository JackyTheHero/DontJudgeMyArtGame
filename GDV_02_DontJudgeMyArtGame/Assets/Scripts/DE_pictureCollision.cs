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

    //Nur zum Testen ===================================================================
    /*
    void Update () 
    { 
        if (isInPictureRange == true && Input.GetKeyDown(KeyCode.E)) {
            
            Destroy(focusPicture);   
        }
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        // Färbe Schrift rot, um die besser lesen zu können
        style.normal.textColor = Color.red;
        // collectedItems wird in triggerEnter (Skript am Schlangenkopf) deklariert und hochgezählt
        if (isInPictureRange == true) {
            GUI.Label(new Rect((Screen.width) / 2 - (Screen.width) / 4,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4,
                                (Screen.height) / 4),
                                "Drücke E, um das Fenster zu löschen", style);
        }
        if (isInPictureRange == false) {
            GUI.Label(new Rect(0, 0, 0, 0), "", style);
        }
    }
    */
}
