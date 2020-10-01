using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerMovement : MonoBehaviour
{

    float speed = 15f;
    float slowSpeed = 10f;

    Vector3 cameraView;

    Vector3 lookDirection;
    Vector3 camForward;
    Vector3 camRight;

    // Keyboard wird bei Start der Szene gesperrt, da Player aus einer gewissen Höhe auf den Boden fällt ...
    // ... während dieses Falles soll sich der Player nicht bewegen können
    public static bool keyboardEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        // ohne freeLookCamera
        // Kamera folgt player
        Camera.main.transform.position = this.transform.position;
        Camera.main.transform.parent = this.transform;

        // Setze Anfangssicht der Kamera in Relation zum Spieler
        // da Spieler zu Beginn auf 0|0|0 steht, kann mit festen Werten gearbeitet werden, anstelle bspw. this.transform.position.x - 10.0f
        // nur in Start() setzen, da sich cameraView in Update fortlaufend ändert
        cameraView = new Vector3(-10, 8, 0);

        // addiere Kameraposition mit cameraView, damit Kamera immer gleichen Abstand zum Player aufweist
        Camera.main.transform.position = this.transform.position + cameraView;
        // Kamera sieht immer zum Player
        Camera.main.transform.LookAt(this.transform.position);
        // Verändere Rotation der Kamera, sodass eine bessere Kamerasicht entsteht -> ansonsten zu viel Fokus auf Player durch Transform.LookAt(target)
        Camera.main.transform.Rotate(-25, 0, 0);

        lookDirection = this.transform.forward;
        camForward = Camera.main.transform.forward;
        camRight = Camera.main.transform.right;

    }

    // Update is called once per frame
    void Update () {
        // jegliche Bewegungen erst möglich, wenn Keyboard freigegeben wird
        if (keyboardEnabled == true && MW_mainMenu.isInMenu == false) {
            // Funktion, die die Blickrichtung des Players je nach Tastendruck und Kameraposititon ändert
            Rotation();

            // Funktion, die den Player bei Tastendruck in die jeweilige Blickrichtung laufen lässt
            Move();

            // Funktion, die Steuerung der Kamera nach links und rechts ermöglicht ...
            // ... zusätzlich kann man die Kamera um den Player um 360 Grad herumdrehen, wenn dieser an einer Stelle steht
            // ... limitierte Bewegung nach oben und unten
            freeLookCamera();
        }  
    }

    // Funktion, die die Blickrichtung des Players je nach Tastendruck und Kameraposititon ändert
    void Rotation() {
        // Richtung, in die Player sich drehen soll, soll hier nach Tastendruck gespeichert werden
        // Zuweisung der momentanten Blickrichtung des Players
        // Speicherung bei Tastendruck, damit die Kamera-Positionen nicht per frame verändert werden -> freeLookCamera beim Laufen
        // Figur läuft nur bei Drücken der Taste W kontinuierlich in Richtung der Kamera (besseres Weglaufen vor dem Wächter, besserer Überblick)
        if (Input.anyKeyDown) {
            camForward = Camera.main.transform.forward;
            camRight = Camera.main.transform.right;
        }

        // da Kamera nicht exakt geradeaus schaut, muss Player-Position nachjustiert werden
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
        
        // GetKey läuft kontinuierlich in jeweilige Richtung, solange Button gedrückt wird
        // GetKeyDown führt Aktion bei einem Tastendruck jeweils nur einmal aus
        if (Input.GetKey(KeyCode.W)) {
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            // lookDirection += -camForward;
            // this.transform.forward = lookDirection;
            // Drücken der Taste W und A -> Berechnung der Bewegungsrichtung
            if (Input.GetKey(KeyCode.A)) {
                lookDirection = -camForward + camRight;
            }
            // Drücken der Taste W und D -> Berechnung der Bewegungsrichtung
            else if (Input.GetKey(KeyCode.D)) {
                lookDirection = -camForward - camRight;
            }
            // ausschließliches Drücken der Taste W -> kontinuierliche Neu-Berechnung der Kamera-Position
            // Figur läuft stets in Richtung, in die der Spieler sieht
            else if (Input.GetKey(KeyCode.W)) {
                camForward = Camera.main.transform.forward;
                camRight = Camera.main.transform.right;
                camForward.y = 0;
                camRight.y = 0;
                camForward = camForward.normalized;
                camRight = camRight.normalized;

                lookDirection = -camForward;
            }
            // bei Loslassen einer Taste (außer W) -> Neuberechnung der Bewegungsrichtung
            else if (Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
                lookDirection = -camForward;
            }
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 0.1f);
        }
        if (Input.GetKey(KeyCode.A)) {
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            // lookDirection += camRight;
            // this.transform.forward = lookDirection;
            // bei Loslassen einer Taste (außer A) -> Neuberechnung der Bewegungsrichtung
            if (Input.GetKey(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
                lookDirection = camRight;
            }
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 0.1f);
        }
        if (Input.GetKey(KeyCode.S)) {
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            // lookDirection += camForward;
            // this.transform.forward = lookDirection;
            // Drücken der Taste S und A -> Berechnung der Bewegungsrichtung
            if (Input.GetKey(KeyCode.A)) {
                lookDirection = camForward + camRight;
            }
            // Drücken der Taste S und D -> Berechnung der Bewegungsrichtung
            else if (Input.GetKey(KeyCode.D)) {
                lookDirection = camForward - camRight;
            }
            // bei Loslassen einer Taste (außer S) -> Neuberechnung der Bewegungsrichtung
            else if (Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
                lookDirection = camForward;
            }
                Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 0.1f);
        }
        if (Input.GetKey(KeyCode.D)){
            // Setze Blickrichtung des Players auf Blickrichtung der Kamera und addiere vorheriges Player-Forward ...
            // ... sodass die Mitte zwischen zwei Vektoren als Blickrichtung dient, wenn zwei Tasten gedrückt werden
            // lookDirection += -camRight;
            // this.transform.forward = lookDirection;
            // bei Loslassen einer Taste (außer D) -> Neuberechnung der Bewegungsrichtung
            if (Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
                lookDirection = -camRight;
            }
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 0.1f);
        }
    }

    // Funktion, die den Player bei Tastendruck in die jeweilige Blickrichtung laufen lässt
    void Move() {
        // slowMode wird aktiviert, wenn Shift gedrückt wird (links oder rechts)
        var slowMode = MW_playerColliderInteraction.steal == true;
        // var slowMode = MW_playerColliderInteraction.steal == true || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        // wenn slowMode aktiv ist, nutze slowSpeed, ansonsten "normalen" speed
        // player läuft also langsamer, wenn er ein Bild gestohlen hat

        var speed = slowMode ? this.slowSpeed : this.speed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            this.transform.position += this.transform.localRotation * new Vector3(0, 0, -speed * Time.deltaTime);
        }
    }

    // Funktion, die Steuerung der Kamera nach links und rechts ermöglicht ...
    // ... zusätzlich kann man die Kamera um den Spieler um 360 Grad herumdrehen, wenn dieser an einer Stelle steht
    void freeLookCamera() {
        float mouseSpeed = 3.0f;
        /*float minYAngle = 8.0f;
        float maxYAngle = 8.0f;

        float minXAngle = 10.0f;
        float maxXAngle = 10.0f;*/
       
        // Drehung um y-Achse (Vector3.up) in Relation zur Drehbewegung der Maus -> Input.GetAxis("Mouse X")
        // mit mouseSpeed multiplizieren, da Bewegung sonst sehr langsam ist
        // Rotation (Quaternion.AngleAxis()) mit cameraView multiplizieren, sodass cameraView neue Position der Kamera speichert
        cameraView = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * cameraView; // Drehung links/rechts

        // Kamerabewegung nach oben und unten
        //Camera.main.transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.forward); // Drehung oben/unten
        //cameraView.y = Mathf.Clamp(cameraView.y, minXAngle, maxXAngle);
        // cameraView.y = Mathf.Clamp(cameraView.x, minYAngle, maxYAngle);

        // addiere Kameraposition mit cameraView, damit Kamera immer gleichen Abstand zum Player aufweist
        Camera.main.transform.position = this.transform.position + cameraView;
        // Kamera sieht immer zum Player
        Camera.main.transform.LookAt(this.transform.position);
        // Verändere Rotation der Kamera, sodass eine bessere Kamerasicht entsteht -> ansonsten zu viel Fokus auf Player durch Transform.LookAt(target)
        Camera.main.transform.Rotate(-25, 0, 0);
    }
}