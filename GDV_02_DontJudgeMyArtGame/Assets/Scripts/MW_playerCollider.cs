using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerCollider : MonoBehaviour
{

    // Keyboard wird bei Start der Szene gesperrt, da Player aus einer gewissen Höhe auf den Boden fällt ...
    // ... während dieses Falles soll sich der Player nicht bewegen können
    public static bool keyboardEnabled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
      
    }

    void OnCollisionEnter(Collision other) {
        // gib folgende Zeile für alle Kollisionen aus
        Debug.Log(this.name + " has an OnCollisionEnter with " + other.gameObject.name);

        // wenn Player mit dem Boden kollidiert und somit der Fall beendet ist, wird Tasteneingabe freigegeben
        if (other.gameObject.name == "Ground") {
            keyboardEnabled = true;
        }
    }
}