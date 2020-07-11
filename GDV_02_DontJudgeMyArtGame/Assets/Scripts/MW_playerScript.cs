using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_playerScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Kamera folgt player
        Camera.main.transform.position = player.transform.position;
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.Translate(0, 2, -6);
    }

    // Quaternion lastRotation;
    // Quaternion targetRotation;

    // Update is called once per frame
    void Update () {
        // lastRotation = player.transform.rotation;
        // float moveTime = 1.5f;
        // player.transform.rotation = Quaternion.Lerp(lastRotation, targetRotation, Time.time * moveTime);

        // Mausbewegung nach links
        if(Input.GetAxis("Mouse X") < 0) {
            player.transform.rotation *= Quaternion.AngleAxis(-5.0f, Vector3.up);
        }
        // Mausbewegung nach rechts
        if(Input.GetAxis("Mouse X") > 0) {
            player.transform.rotation *= Quaternion.AngleAxis(5.0f, Vector3.up);
        }

        // GetKey läuft kontinuierlich in jeweilige Richtung, solange Button gedrückt wird
        // GetKeyDown führt Aktion bei einem Tastendruck jeweils nur einmal aus
        if (Input.GetKey(KeyCode.W)) {
            player.transform.position += player.transform.localRotation * new Vector3(0, 0, -1.0f);
        }
        if (Input.GetKey(KeyCode.A)) {
            player.transform.position += player.transform.localRotation * new Vector3(1.0f, 0, 0);
            // Drehung ohne Maus um -90 Grad:
            // player.transform.rotation *= Quaternion.AngleAxis(-90.0f, Vector3.up);
        }
        if (Input.GetKey(KeyCode.S)) {
            player.transform.position += player.transform.localRotation * new Vector3(0, 0, 1.0f);
        }
        if (Input.GetKey(KeyCode.D)) {
            player.transform.position += player.transform.localRotation * new Vector3(-1.0f, 0, 0);
            // Drehung ohne Maus um 90 Grad:
            // player.transform.rotation *= Quaternion.AngleAxis(90.0f, Vector3.up);
        }
    }
     
}