using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerScript : MonoBehaviour
{
    public GameObject player;

    float speed = 0.1f;
    float slowSpeed = 0.03f;

    Vector3 cameraView;

    // Start is called before the first frame update
    void Start()
    {
        // Maus-Cursor wird ausgeblendet
        Cursor.visible = false;
        
        // ohne freeLookCamera
        // Kamera folgt player
        Camera.main.transform.position = player.transform.position;
        Camera.main.transform.parent = player.transform;
        /*Camera.main.transform.Translate(0, 8.0f, -10.0f);
        Camera.main.transform.Rotate(15.0f, 0, 0);*/

        // Setze Anfangssicht der Kamera in Relation zum Spieler
        // da Spieler zu Beginn auf 0|0|0 steht, kann mit festen Werten gearbeitet werden, anstelle bspw. player.transform.position.x - 10.0f
        // nur in Start() setzen, da sich cameraView in Update fortlaufend ändert
        cameraView = new Vector3(-10.0f, 8.0f, 0);
    }

    // Quaternion lastRotation;
    // Quaternion targetRotation;

    // Update is called once per frame
    void Update () {
        // lastRotation = player.transform.rotation;
        // player.transform.rotation = Quaternion.Lerp(lastRotation, targetRotation, Time.time * moveTime);

        freeLookCamera();

        // Blockiere S, wenn W gedrückt wird - und umgekehrt
        bool keyLocked = false;
        
        // float mouseSpeed = 2.0f;

        // slowMode wird aktiviert, wenn Shift gedrückt wird (links oder rechts)
        var slowMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        // langsameres Laufen mit Strg
        // var slowMode = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // wenn slowMode aktiv ist, nutze slowSpeed, ansonsten "normalen" speed
        // player läuft also bei gedrückter Shift-Taste langsamer
        var speed = slowMode ? this.slowSpeed : this.speed;

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        // da Kamera nicht exakt geradeaus schaut, muss Player-Position nachjustiert werden
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        // ohne freeLookCamera
        // Mausbewegung nach links
        /*if(Input.GetAxis("Mouse X") < 0) {
            player.transform.rotation *= Quaternion.AngleAxis(-mouseSpeed, Vector3.up);
        }
        // Mausbewegung nach rechts
        if(Input.GetAxis("Mouse X") > 0) {
            player.transform.rotation *= Quaternion.AngleAxis(mouseSpeed, Vector3.up);
        }*/

        // GetKey läuft kontinuierlich in jeweilige Richtung, solange Button gedrückt wird
        // GetKeyDown führt Aktion bei einem Tastendruck jeweils nur einmal aus
        if (Input.GetKey(KeyCode.W) && keyLocked == false) {
            keyLocked = true;
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            player.transform.forward += -camForward;
            // player.transform.rotation = Quaternion.LookRotation(-player.transform.position);
        }
        if (Input.GetKey(KeyCode.A)) {
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            player.transform.forward += camRight;
            // player.transform.rotation = Quaternion.LookRotation(-player.transform.position);
        }

        if (Input.GetKey(KeyCode.S) && keyLocked == false) {
            keyLocked = true;
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            player.transform.forward += camForward;
            // player.transform.rotation = Quaternion.LookRotation(player.transform.position);
        }
        if (Input.GetKey(KeyCode.D)) {
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            player.transform.forward += -camRight;
            // player.transform.rotation = Quaternion.LookRotation(player.transform.position);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            player.transform.position += player.transform.localRotation * new Vector3(0, 0, -speed);
        }
    }

    void freeLookCamera() {
        float mouseSpeed = 2.0f;
       
       // Drehung um y-Achse (Vector3.up) in Relation zur Drehbewegung der Maus -> Input.GetAxis("Mouse X")
       // mit mouseSpeed multiplizieren, da Bewegung sonst sehr langsam ist
       // Rotation (Quaternion.AngleAxis()) mit cameraView multiplizieren, sodass cameraView neue Position der Kamera speichert
        cameraView = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * cameraView;
        // addiere Kameraposition mit cameraView, damit Kamera immer gleichen Abstand zum Player aufweist
        Camera.main.transform.position = player.transform.position + cameraView;
        // Kamera sieht immer zum Player
        Camera.main.transform.LookAt(player.transform.position);
        // Verändere Rotation der Kamera, sodass eine bessere Kamerasicht entsteht -> ansonsten zu viel Fokus auf Player durch Transform.LookAt(target)
        Camera.main.transform.Rotate(-15.0f, 0, 0);
    }
}