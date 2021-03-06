using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*DIESES SKRIPT KÜMMERT SICH UM DIE KOLLISION DES SPIELERS UND TRACKT ZUSÄTZLICH VIA
  ONTRIGGERENTER, OB EIN OBJEKT UNMITTELBAR VOR DEM SPIELER IST, UM SO MIT DIESEM ZU INTERAGIEREN.*/
public class MW_playerColliderInteraction : MonoBehaviour
{
    // speichere in dieser Variablen, ob ein interagierbares Gameobject in der Nähe ist
    public static bool isInWindowRange = false;

    // speichere hier das GameObject, das ein OnTriggerEnter mit dem Player hat
    GameObject inFocus;

    // Rigidbody des Players
    public Rigidbody playerRig;

    public ParticleSystem smoke;
    public ParticleSystem splinter1;
    public ParticleSystem splinter2;

    GameObject stolenPicture;

    // checke, ob ein Bild bereits gestohlen wurde, da man immer nur eines zur gleichen Zeit stehlen können soll
    public static bool steal = false;

    // prüfe mit dieser Variable, ob es ein eigenes Bild ist
    public static bool owned = false;

    // Variable, die speichert, ob Player schon am 
    public static bool hitGround = false;

    AudioSource sound;
    AudioClip wood;
    AudioClip throwing;
    AudioClip stealing;

    // Start is called before the first frame update
    void Start()
    {
        playerRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        
        // setze Partkelsystem anfangs auf Pause, damit es nicht beim Start des Spiels ebenso startet
        smoke.Pause();
        splinter1.Pause();
        splinter2.Pause();

        //Audio-Daten holen
        sound = GameObject.FindWithTag("Sound").GetComponent<AudioSource>();  
        wood = Resources.Load("wood") as AudioClip;
        throwing = Resources.Load("throw") as AudioClip;
        stealing = Resources.Load("steal") as AudioClip;
    }

    // Update is called once per frame
    void Update () {
        // prüfe, ob focusPicture auf "owned" endet, da nur eigene Bilder zerstört und gestohlen werden können
        // prüfe nur, wenn focusPicture nicht null ist
        if (DE_pictureCollision.focusPicture != null) {
            if (DE_pictureCollision.focusPicture.name.Contains("owned")) {
                owned = true;
            } else {
                owned = false;
            }
        }

        // wenn es eigenes Bild ist, erlaube das Zerstören und das Stehlen
        if (owned == true && DE_cameraPan.inMotion == false && DE_cameraPan.inMenu == true) {
            destroyPicture();
            stealPicture();
        }

        // wenn man Bild unter dem Arm hat und vor einem Fenster steht, kann man es durch Drücken der Taste E rausschmuggeln
        if (steal == true && isInWindowRange == true && Input.GetKeyDown(KeyCode.E)) {
            throwPictureOutWindow();
        }
    }

    void destroyPicture() {
        // wenn das bestimmte GameObject in der Reichweite ist, kann es durch Drücken der Taste 1 gelöscht werden
        if (DE_pictureCollision.isInPictureRange == true && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
            // speichere Index des focusPicture
            int index = JH_scoreMaster.getPaintingIndex(DE_pictureCollision.focusPicture);
            // setze Score dieses Paintings auf -1000, damit es in JH_scoreMaster nicht berücksichtigt wird
            JH_scoreMaster.paintingScore[index] = -1000;
            // lösche GameObject, das im Fokus steht
            Destroy(DE_pictureCollision.focusPicture);
            // isInWindowRange wird wieder auf false gesetzt, da das GameObject nicht mehr existiert
            isInWindowRange = false;

            // setze ParticleSystem auf Position des zu zerstörenden Objektes
            smoke.transform.position = DE_pictureCollision.focusPicture.transform.position;
            splinter1.transform.position = DE_pictureCollision.focusPicture.transform.position;
            splinter2.transform.position = DE_pictureCollision.focusPicture.transform.position;
            // setze PartikelSystem zurück und spiele es danach von vorne ab
            smoke.Clear(); splinter1.Clear(); splinter2.Clear();
            smoke.Play(); splinter1.Play(); splinter2.Play();

            sound.PlayOneShot(wood, 0.8F);
            
            // setze isInPictureRange zurück auf false, da das Gemälde nicht länger existiert
            DE_pictureCollision.isInPictureRange = false;
            // erhöhe Punktzahl nach erfolgreichem Zerstören -> false bedeutet, Gemälde wurde zerstört
            JH_scoreMaster.raiseGeneralScore(false);

            DE_pictureCollision.focusPicture = null;
        }
    }

    void stealPicture() {
        // wenn das bestimmte GameObject in der Reichweite ist, kann es durch Drücken der Taste 2 gestohlen werden
        // nur wenn man zum jetzigen Zeitpunkt nicht ein Bild unter dem Arm hat, kann man ein Bild stehlen -> nur eines zum gleichen Zeitpunkt
        if (DE_pictureCollision.isInPictureRange == true && (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && steal == false) {
            steal = true;
            // speichere gestohlenes Gemälde in stolenPicture, damit sich Variable nicht mehr ändern kann
            stolenPicture = DE_pictureCollision.focusPicture;

            sound.PlayOneShot(stealing, 0.3F);
        }
    }

    void throwPictureOutWindow() {
        // wenn man ein Gemälde bereits unter dem Arm hat und vor einem offenen Fenster steht, kann man es dort hinausschmuggeln
        // setze steal wieder auf false, da das Stehlen erfolgreich war und man nun ein anderes stehlen kann bzw. "darf"
        steal = false;
        // speichere Index des focusPicture
        int index = JH_scoreMaster.getPaintingIndex(stolenPicture);
        // setze Score dieses Paintings auf -1000, damit es in JH_scoreMaster nicht berücksichtigt wird
        JH_scoreMaster.paintingScore[index] = -1000;
        // zerstöre das stolenPicture und setze Referenz auf null
        Destroy(stolenPicture);
        stolenPicture = null;

        DE_pictureCollision.focusPicture = null;

        sound.PlayOneShot(throwing, 0.5F);
        
        // isInWindowRange wird wieder auf false gesetzt, da man kein gestohlenes Objekt mehr hat
        isInWindowRange = false;
        // erhöhe Punktzahl nach erfolgreichem Zerstören -> true bedeutet, Gemälde wurde gestohlen
        JH_scoreMaster.raiseGeneralScore(true);
        // Debug.Log(DE_pictureCollision.focusPicture);
        // Debug.Log(stolenPicture);
    }

    void OnCollisionEnter(Collision other) {
        // gib folgende Zeile für alle Kollisionen aus
        // Debug.Log(this.name + " has an OnCollisionEnter with " + other.gameObject.name);

        // wenn Player mit dem Boden kollidiert und somit der Fall beendet ist, wird Tasteneingabe freigegeben
        if (other.gameObject.name.Contains("Ground")) {
            // Rigidbody des Players erhält position und rotation constraints, sodass er sich auf diesen Achsen nicht verändert
            // ... wenn z.B. Y nicht gesperrt ist, kann es sein, dass der Player auf die Bänke kommt (position) oder sich nach Interaktion leicht dreht (rotation)
            // constraint für position Y wird hier erst eingefügt, da Player zuvor auf dem Boden aufgekommen sein muss
            playerRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            // Player wird bei Zusammenstoß mit Collidern nicht ein Stück zurückgeschleudert
            playerRig.drag = Mathf.Infinity;
            MW_playerMovement.keyboardEnabled = true;
            hitGround = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        // prüfe zunächst, ob der Name des GameObjects größer oder gleich 7 ist, da Fenster 7 Zeichen besitzt
        if (other.gameObject.name.Length >= 7) {
            // prüfe, ob "Fenster" im Namen steht, da nur offene Collider haben -> wenn ja, wird es erlaubt, das Bild zu löschen
            if (other.gameObject.name.Contains("Fenster")) {
                // Debug.Log(this.name + "is able to interact with " + other.gameObject.name);
                isInWindowRange = true;
                // speichere das GameObject, das zum Löschen freigegeben wird, im Gameobject inFocus
                inFocus = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        // prüfe zunächst, ob der Name des GameObjects größer oder gleich 7 ist, da Fenster 7 Zeichen besitzt
        if (other.gameObject.name.Length >= 7) {
            // prüfe, ob "Fenster" im Namen steht, da nur offene Collider haben -> wenn ja, wird es nun nicht mehr erlaubt, das Bild zu löschen
            if (other.gameObject.name.Contains("Fenster")) {
                // Debug.Log(this.name + "is no longer able to interact with " + other.gameObject.name);
                isInWindowRange = false;
            }
        }
    }

    /*
    // GUI für Testzwecke
    // mit Variable collectedItems werden die eingesammelten Items gezählt
    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        // Färbe Schrift rot, um die besser lesen zu können
        style.normal.textColor = Color.red;
        if (isInWindowRange == true && steal == true) {
            GUI.Label(new Rect(60,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4,
                                (Screen.height) / 4),
                                "Drücke E, um das Bild aus dem Fenster zu schmuggeln", style);
        }

        if (isInWindowRange == false) {
            GUI.Label(new Rect(0, 0, 0, 0), "", style);
        }

        if (DE_pictureCollision.isInPictureRange == true && DE_cameraPan.inMenu == false && DE_cameraPan.inMotion == false) {
            GUI.Label(new Rect(150,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4,
                                (Screen.height) / 4),
                                "Drücke E, um das Bild genauer anzusehen", style);
        }

        if (DE_pictureCollision.isInPictureRange == true && owned == true && DE_cameraPan.inMotion == false && DE_cameraPan.inMenu == true) {
            GUI.Label(new Rect(50,
                                (Screen.height) / 2 - (Screen.height) / 8,
                                (Screen.width) / 4,
                                (Screen.height) / 4),
                                "Drücke 1, um das Bild zu löschen oder 2, um das Bild zu stehlen", style);
        }
        
        if (DE_pictureCollision.isInPictureRange == false) {
            GUI.Label(new Rect(0, 0, 0, 0), "", style);
        }
    }
    */
}


//wood hit by VitaWrap
//Licensed under Creative Commons: By Attribution 3.0
//https://freesound.org/people/VitaWrap/sounds/345679/

//cartoon-long-throw by copyc4t
//Licensed under Creative Commons: By Attribution 3.0
//https://freesound.org/people/copyc4t/sounds/482735/

//FX swanee whistle down by v0idation
//Licensed under Creative Commons: By CC0 1.0
//https://freesound.org/people/v0idation/sounds/497093/

