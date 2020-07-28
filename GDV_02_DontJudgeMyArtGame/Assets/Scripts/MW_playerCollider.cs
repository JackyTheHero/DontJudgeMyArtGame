using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerCollider : MonoBehaviour
{
    // speichere in dieser Variablen, ob ein interagierbares Gameobject in der Nähe ist
    bool isInRange = false;

    // speichere das GameObject, das ein OnTriggerEnter mit dem Player hat
    GameObject inFocus;

    // Keyboard wird bei Start der Szene gesperrt, da Player aus einer gewissen Höhe auf den Boden fällt ...
    // ... während dieses Falles soll sich der Player nicht bewegen können
    public static bool keyboardEnabled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E)) {
            Destroy(inFocus);
            isInRange = false;
        }
    }

    void OnCollisionEnter(Collision other) {
        // gib folgende Zeile für alle Kollisionen aus
        Debug.Log(this.name + " has an OnCollisionEnter with " + other.gameObject.name);

        // wenn Player mit dem Boden kollidiert und somit der Fall beendet ist, wird Tasteneingabe freigegeben
        if (other.gameObject.name == "Ground") {
            keyboardEnabled = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Fenster (1)") {
            Debug.Log(this.name + "is able to interact with" + other.gameObject.name);
            isInRange = true;
            inFocus = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Fenster (1)") {
            Debug.Log(this.name + "is no longer able to interact with" + other.gameObject.name);
            isInRange = false;
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
            GUI.Label(new Rect(10, 0, 0, 0), "Drücke E, um das Fenster zu löschen", style);
        }
        if (isInRange == false) {
            GUI.Label(new Rect(10, 0, 0, 0), "", style);
        }
    }
}