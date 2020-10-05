using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_cameraPan : MonoBehaviour
{
    //Timer für die Dauer der Bewegung
    static float duration = 2f;
    static float time = 0f;

    //Positionen und Rotationen============================

    //Kamera Ursprung
    static Vector3 originPosCam;
    static Quaternion originRotCam;

    //Gemälde Ursprung
    static Vector3 originPosPic; 
    static Quaternion originRotPic;
    static GameObject originPic;

    //Spieler Ursprung
    static Vector3 originPosPlayer;
    static Quaternion originRotPlayer;

    //Kamera Ziel
    static Vector3 targetPosCam; 
    static Quaternion targetRotCam;

    //Kamera Ziel bei Ende
    static Vector3 newPosCam;

    //Spieler Bewegungsziel 
    static Vector3 targetPosPlayer;
    static Quaternion targetRotPlayer;
    
    //Spieler Blickziel 
    static Quaternion lookRotPlayer;

    //Bild Größe
    static Vector3 originSize;
    static Vector3 newSize = new Vector3(0.3f,0.3f,0.3f);

    //Bools für Ablauf========================================

    //Speicher ob Bewegung startet
    public static bool inMotion = false;

    //Speichert ob Auswahl getätigt
    public static bool inMenu = false;

    //Checkt ob Bewegung gestartet werden kann und führt diese dann aus, läuft durch alle vier Schritte, setzt sich selbst zurück
    public static void checkCameraPan()
    {
        //Start der Bewegung zum Gemälde, nur wenn IN Reichweite, NICHT im Menü und NICHT in Bewegung
        if ((Input.GetKeyDown(KeyCode.E)) && DE_pictureCollision.isInPictureRange && !inMenu && !inMotion) {
            inMotion = true;
            inMenu = true;

            //Vorbereitung für Bewegung
            getCoords();
        }

        //Führt Bewegung zum Gemälde durch, nur wenn IN Bewegung und IN Menü, start = false am Ende der Bewegung
        if(inMotion && inMenu){
            inMotion = panCamera();
        }

        //Start der Bewegung zum Gemälde, nur wenn IN Menü und NICHT in Bewegung
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2)) && inMenu && !inMotion) {
            inMotion = true;
            inMenu = false;
        }

        //Führt Bewegung weg vom Gemälde durch, nur wenn IN Bewegung und NICHT im Menü, start = false am Ende der Bewegung
        if(inMotion && !inMenu){
            if(MW_playerColliderInteraction.steal){
                stealPic();
            } 
            inMotion = panCameraBack();  
                    
        }
    }

    //Vorbereitung
    static void getCoords()
    {
        //UMKEHREN BEI ENDE DES VERLASSENS DER BILDANSICHT!================================================
        //locked Spieler Movement
        MW_playerMovement.keyboardEnabled = false;
        
        //Verhindert Kamerazittern
        Camera.main.transform.parent = null;
        //rückgängig: Camera.main.transform.parent = GameObject.FindWithTag("Player").transform;

        //Verhindert Kollisionsbewegung am Ende
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        //================================================================================================

        //Initialisiert Positionen und Rotationen

        originPosCam = Camera.main.transform.position;
        originRotCam = Camera.main.transform.rotation;

        originPosPic = DE_pictureCollision.focusPicture.transform.position;
        originRotPic = DE_pictureCollision.focusPicture.transform.rotation;

        originPosPlayer= GameObject.FindWithTag("Player").transform.position;
        originRotPlayer = GameObject.FindWithTag("Player").transform.rotation;

        //Berechnet Abstände und Rotationen
        targetPosCam = originPosPic + originRotPic * new Vector3(-0.5f,-0.3f,-5.7f);

        targetPosPlayer = originPosPic + originRotPic * new Vector3(4f, 0,-2.5f);

        targetPosPlayer = new Vector3(targetPosPlayer.x, 0, targetPosPlayer.z);

        targetRotPlayer = Quaternion.LookRotation(originPosPlayer - targetPosPlayer, Vector3.up);

        targetRotCam = originRotPic * Quaternion.AngleAxis(10f, Vector3.up);

        lookRotPlayer = originRotPic * Quaternion.AngleAxis(140f, Vector3.up);

        newPosCam = originPosCam + (targetPosPlayer - originPosPlayer);    
    }
    
    //Kamerabewegung zum Gemälde
    static bool panCamera()
    {
        //Nur falls Dauer nicht erreicht
        if(time < duration){

            //Addiert verstrichene Zeit
            time += Time.deltaTime;

            //Mathematische Funktion für weiche Kamerabewegung
            float t = time/duration;
            t = t*t*t * (t * (6f*t - 15f) + 10f);

            //Interpoliert Position und Rotation der Kamera zum Gemälde
            Camera.main.transform.position = Vector3.Lerp(originPosCam, targetPosCam, t);
            Camera.main.transform.rotation = Quaternion.Lerp(originRotCam, targetRotCam, t);

            //Interpoliert Position des Spielers zur Zielposition, Beginn: 25% der Gesamtdauer, Dauer: 50% der Gesamtdauer
            GameObject.FindWithTag("Player").transform.position = Vector3.Lerp(originPosPlayer, targetPosPlayer, (time - duration/4) / (duration/2));

            //Wechselt nach 50% der Gesamtdauer auf zweite Rotation um Konflikt zu vermeiden
            if(time < duration/2){
                //Interpoliert Rotation des Spielers zur Zielposition, Beginn: 0% der Gesamtdauer, Dauer: 25% der Gesamtdauer
                GameObject.FindWithTag("Player").transform.rotation = Quaternion.Lerp(originRotPlayer, targetRotPlayer, time/(duration/4));
                
            } else{
                //Interpoliert Rotation des Spielers zum Gemälde, Beginn: 75% der Gesamtdauer, Dauer: 25% der Gesamtdauer
                GameObject.FindWithTag("Player").transform.rotation = Quaternion.Lerp(targetRotPlayer, lookRotPlayer, (time - 3*duration/4) / (duration/4));    
            }

            //gibt true zurück, damit Bewegung weiter geht
            return true;
        } else //Bewegung fertig
        {
            //Setzt Position und Rotation zum Ziel, falls float Ungenauigkeiten
            Camera.main.transform.position = targetPosCam;
            Camera.main.transform.rotation = targetRotCam;
            GameObject.FindWithTag("Player").transform.position = targetPosPlayer;
            GameObject.FindWithTag("Player").transform.rotation = lookRotPlayer;

            //Zeit zurücksetzen
            time = 0;

            //gibt false zurück bei fertiger Bewegung
            return false;
        }     
    }

    //Bewegung weg vom Gemälde
    static bool panCameraBack()
    {
        //Nur falls Dauer nicht erreicht
        if(time < duration){

            //Addiert verstrichene Zeit
            time += Time.deltaTime;

            //Mathematische Funktion für weiche Kamerabewegung
            float t = time/duration;
            t = t*t*t * (t * (6f*t - 15f) + 10f);

            //Interpoliert Position und Rotation der Kamera zur Ursprungsrichtung
            Camera.main.transform.position = Vector3.Lerp(targetPosCam, newPosCam, t);
            Camera.main.transform.rotation = Quaternion.Lerp(targetRotCam, originRotCam, t);

            //gibt true zurück, damit Bewegung weiter geht
            return true;
        } else //Bewegung fertig
        {
            //Setzt Position und Rotation zum Ziel, falls float Ungenauigkeiten
            Camera.main.transform.position = newPosCam;
            Camera.main.transform.rotation = originRotCam;

            //UMKEHRUNG!=================================================================================
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
            Camera.main.transform.parent = GameObject.FindWithTag("Player").transform;
            MW_playerMovement.keyboardEnabled = true;
            //===========================================================================================

            //Zeit zurücksetzen
            time = 0;

            //Owned here auf false setzten um Probleme zu verhindern
            MW_playerColliderInteraction.owned = false;

            //gibt false zurück bei fertiger Bewegung
            return false;
        }     
    } 

    //Bewegung des Stehlens
    static void stealPic()
    {
        if(time == 0){
            Destroy(DE_pictureCollision.focusPicture.transform.Find("Plakette").gameObject);
            originSize = DE_pictureCollision.focusPicture.transform.localScale;
            originPic = DE_pictureCollision.focusPicture;

        }
        if(time < duration)
        {
            //Mathematische Funktion für weiche Bewegung
            float t = time/duration;
            t = t*t*t * (t * (6f*t - 15f) + 10f);

            //Bewegungen
            originPic.transform.localScale = Vector3.Lerp(originSize, newSize, t);

        } else
        {
            //Setzt Spieler als Parent des Gemäldes
            originPic.transform.parent = GameObject.FindWithTag("Player").transform;

            //Setzt Position und Rotation zum Ziel
            originPic.transform.position = lookRotPlayer * new Vector3(0,2,1) + GameObject.FindWithTag("Player").transform.position;
            originPic.transform.rotation = Quaternion.AngleAxis(180f, Vector3.up) * GameObject.FindWithTag("Player").transform.rotation;
            originPic.transform.rotation *= Quaternion.AngleAxis(18f, Vector3.right); 

        }

    }    
}
