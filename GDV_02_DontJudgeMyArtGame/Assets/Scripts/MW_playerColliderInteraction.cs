using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*DIESES SKRIPT KÜMMERT SICH UM DIE KOLLISION DES SPIELERS UND TRACKT ZUSÄTZLICH VIA
  ONTRIGGERENTER, OB EIN OBJEKT UNMITTELBAR VOR DEM SPIELER IST, UM SO MIT DIESEM ZU INTERAGIEREN.*/
public class MW_playerColliderInteraction : MonoBehaviour
{
    // speichere in dieser Variablen, ob ein interagierbares Gameobject in der Nähe ist
    bool isInRange = false;

    // speichere hier das GameObject, das ein OnTriggerEnter mit dem Player hat
    GameObject inFocus;

    // Keyboard wird bei Start der Szene gesperrt, da Player aus einer gewissen Höhe auf den Boden fällt ...
    // ... während dieses Falles soll sich der Player nicht bewegen können
    public static bool keyboardEnabled = false;
    // Rigidbody des Players
    public Rigidbody playerRig;

    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        playerRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        smoke.Pause();
    }

    // Update is called once per frame
    void Update () {
        // wenn das bestimmte GameObject in der Reichweite ist, kann es durch Drücken der Taste E gelöscht werden
        if (isInRange == true && Input.GetKeyDown(KeyCode.E)) {
            // lösche GameObject, das im Fokus steht
            Destroy(inFocus);
            // isInRange wird wieder auf false gesetzt, da das GameObject nicht mehr existiert
            isInRange = false;

            // setze ParticleSystem auf Position des zu zerstörenden Objektes
            smoke.transform.position = inFocus.transform.position;
            // setze PartikelSystem zurück und spiele es danach von vorne ab
            smoke.Clear();
            smoke.Play();
        }
    }

    void OnCollisionEnter(Collision other) {
        // gib folgende Zeile für alle Kollisionen aus
        // Debug.Log(this.name + " has an OnCollisionEnter with " + other.gameObject.name);

        // wenn Player mit dem Boden kollidiert und somit der Fall beendet ist, wird Tasteneingabe freigegeben
        if (other.gameObject.name == "Ground") {
            // Rigidbody des Players erhält position und rotation constraints, sodass er sich auf diesen Achsen nicht verändert
            // constraint für position y wird hier erst eingefügt, da Player zuvor auf dem Boden aufgekommen sein muss
            playerRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            keyboardEnabled = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        // prüfe zunächst, ob der Name des GameObjects größer oder gleich 7 ist, da Fenster 7 Zeichen besitzt
        if (other.gameObject.name.Length >= 7) {
            // prüfe, ob die ersten 7 Zeichen des Namens "Fenster" ergeben -> wenn ja, wird es erlaubt, das Bild zu löschen
            if (other.gameObject.name.Substring(0, 7) == "Fenster") {
                // Debug.Log(this.name + "is able to interact with " + other.gameObject.name);
                isInRange = true;
                // speichere das GameObject, das zum Löschen freigegeben wird, im Gameobject inFocus
                inFocus = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        // prüfe zunächst, ob der Name des GameObjects größer oder gleich 7 ist, da Fenster 7 Zeichen besitzt
        if (other.gameObject.name.Length >= 7) {
            // prüfe, ob die ersten 7 Zeichen des Namens "Fenster" ergeben -> wenn ja, wird es nun nicht mehr erlaubt, das Bild zu löschen
            if (other.gameObject.name.Substring(0, 7) == "Fenster") {
                // Debug.Log(this.name + "is no longer able to interact with " + other.gameObject.name);
                isInRange = false;
            }
        }
    }

// Text erscheint oben links in der Ecke
    // mit Variable collectedItems werden die eingesammelten Items gezählt
    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        // Färbe Schrift rot, um die besser lesen zu können
        style.normal.textColor = Color.red;
        // collectedItems wird in triggerEnter (Skript am Schlangenkopf) deklariert und hochgezählt
        if (isInRange == true) {
            GUI.Label(new Rect((Screen.width) / 2 - (Screen.width) / 4,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4,
                                (Screen.height) / 4),
                                "Drücke E, um das Fenster zu löschen", style);
        }
        if (isInRange == false) {
            GUI.Label(new Rect(0, 0, 0, 0), "", style);
        }
    }
}