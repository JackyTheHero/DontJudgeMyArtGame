using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MW_mainMenu : MonoBehaviour
{

    public GameObject canvas;
    public static bool isInMenu;

    public Button newGame;
    public Button continueGame;

    public GameObject player;
    float playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform.position.y;
        
        checkMenu();
        canvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Funktion, die Mouse-Cursor im Menü ein- und im Spiel ausblendet ...
        // ... und zusätzlich das Spiel pausiert, wenn das Menü geöffnet ist
        pauseGame();

        // Funktion, die checkt, ob man sich gerade im Menü befindet oder nicht ...
        // ... zusätzliche Prüfung, ob das Spiel schon gestartet wurde
        checkMenu();

        // Funktion, die das Menü aufruft oder schließt
        startMenu();
    }

    // Funktion, die checkt, ob man sich gerade im Menü befindet oder nicht ...
    // ... zusätzliche Prüfung, ob das Spiel schon gestartet wurde
    void checkMenu() {
        if (canvas.gameObject.activeSelf == true) {
            // canvas gerade aktiv -> dann setze isInMenu auf true
            isInMenu = true;
        } else {
            // ansonsten auf false
            isInMenu = false;
        }

        // playerPos ist nach direktem Start nicht 5, sondern liegt bei ca. 4.99f
        if (player.transform.position.y >= playerPos - 0.01f) {
            // wenn Anfangsposition nicht abweicht, wurde Spiel noch nicht gestartet -> "Neues Spiel"
            continueGame.gameObject.SetActive(false);
            newGame.gameObject.SetActive(true);
        } else {
            // wenn Anfangsposition abweicht, wurde Spiel schon gestartet -> "Fortsetzen"
            continueGame.gameObject.SetActive(true);
            newGame.gameObject.SetActive(false);
        }
    }

    // Funktion, die das Menü aufruft oder schließt
    void startMenu() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isInMenu == false) {
                // wenn Menü geschlossen ist, wird es mit der Escape-Taste geöffnet
                canvas.gameObject.SetActive(true);
            }
            if (isInMenu == true) {
                // wenn Menü offen ist, wird es mit der Escape-Taste geschlossen
                canvas.gameObject.SetActive(false);
            }
        }
    }

    // Funktion, die Mouse-Cursor im Menü ein- und im Spiel ausblendet ...
    // ... und zusätzlich das Spiel pausiert, wenn das Menü geöffnet ist
    void pauseGame() {
        // Maus-Cursor wird ausgeblendet, wenn man sich nicht im Menü befindet
        if (isInMenu == true) {
            Time.timeScale = 0; // Spiel pausiert
            Cursor.visible = true; // Cursor sichtbar   
        } else {
            Cursor.visible = false; // Cursor unsichtbar
            Time.timeScale = 1; // Spiel geht weiter
        }
    }
}
