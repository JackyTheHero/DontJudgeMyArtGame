using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerScript : MonoBehaviour
{
    public GameObject player;


    float speed = 0.1f;
    float slowSpeed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        // Maus-Cursor wird ausgeblendet
        Cursor.visible = false;
        
        // Kamera folgt player
        Camera.main.transform.position = player.transform.position;
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.Translate(0, 8.0f, -10.0f);
        Camera.main.transform.Rotate(15.0f, 0, 0);
    }

    // Quaternion lastRotation;
    // Quaternion targetRotation;

    // Update is called once per frame
    void Update () {
        // lastRotation = player.transform.rotation;
        // player.transform.rotation = Quaternion.Lerp(lastRotation, targetRotation, Time.time * moveTime);

        
        float mouseSpeed = 2.0f;

        // slowMode wird aktiviert, wenn Shift gedrückt wird (links oder rechts)
        var slowMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        // langsameres Laufen mit Strg
        // var slowMode = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // wenn slowMode aktiv ist, nutze slowSpeed, ansonsten "normalen" speed
        // player läuft also bei gedrückter Shift-Taste langsamer
        var speed = slowMode ? this.slowSpeed : this.speed;

        // Mausbewegung nach links
        if(Input.GetAxis("Mouse X") < 0) {
            player.transform.rotation *= Quaternion.AngleAxis(-mouseSpeed, Vector3.up);
        }
        // Mausbewegung nach rechts
        if(Input.GetAxis("Mouse X") > 0) {
            player.transform.rotation *= Quaternion.AngleAxis(mouseSpeed, Vector3.up);
        }

        // GetKey läuft kontinuierlich in jeweilige Richtung, solange Button gedrückt wird
        // GetKeyDown führt Aktion bei einem Tastendruck jeweils nur einmal aus
        if (Input.GetKey(KeyCode.W)) {
            player.transform.position += player.transform.localRotation * new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            player.transform.position += player.transform.localRotation * new Vector3(speed, 0, 0);
            // player.transform.rotation *= Quaternion.AngleAxis(-speed * 10, Vector3.up);
        }
        if (Input.GetKey(KeyCode.S)) {
            player.transform.position += player.transform.localRotation * new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            player.transform.position += player.transform.localRotation * new Vector3(-speed, 0, 0);
            // player.transform.rotation *= Quaternion.AngleAxis(speed * 150, Vector3.up);
        }
    }
     
}