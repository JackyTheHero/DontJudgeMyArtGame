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
    public Button score;
    public Button message;

    public GameObject player;
    float playerPos;

    // erreicht man diese Punktzahl, gewinnt man das Spiel
    int scoreWon = 50;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform.position.y;
        
        checkMenu();
        canvas.gameObject.SetActive(true);

        message.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
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

        // Funktion, die den EndScreen aufruft, wenn das Spiel gewonnen oder verloren wurde
        endScreen();
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

        // Spiel wurde noch nicht gestartet -> Button "Neues Spiel"
        if (MW_buttonOnClick.gameStarted == false) {
            // wenn Anfangsposition nicht abweicht, wurde Spiel noch nicht gestartet -> "Neues Spiel"
            continueGame.gameObject.SetActive(false);
            newGame.gameObject.SetActive(true);
        } else {
            // Spiel wurde bereits gestartet -> Button "Fortsetzen"
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

    // Funktion, die den EndScreen aufruft, wenn das Spiel gewonnen oder verloren wurde
    void endScreen() {
        // JH_scoreMaster.gameover = true; // -> zu schlechter Ruf
        // DE_guardBehaviour.caught = true // -> Wächter hat den Player geschnappt
        if (JH_scoreMaster.gameover == true || DE_guardBehaviour.caught == true || DE_guardBehaviour1.caught == true || DE_guardBehaviour2.caught == true) {
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
            newGame.gameObject.SetActive(false);
            continueGame.gameObject.SetActive(false);

            if (JH_scoreMaster.gameover == true) {
                // Message, wenn man zu wenig Punkte hat
                message.GetComponentInChildren<Text>().text = "Du hast leider verloren! :(";
                message.gameObject.SetActive(true);
            }
            if (DE_guardBehaviour.caught == true || DE_guardBehaviour1.caught == true || DE_guardBehaviour2.caught == true) {
                // Message, wenn man erwischt wurde
                message.GetComponentInChildren<Text>().text = "Du wurdest erwischt! :(";
                message.gameObject.SetActive(true);
            }

            // Punkteanzeige
            score.GetComponentInChildren<Text>().text = "Deine Punkte: " + JH_scoreMaster.getGeneralScore();
            score.gameObject.SetActive(true);
        }

        // Spiel gewonnen bei Erreichen von x Punkten (Punktzahl steht in Variable scoreWon)
        if (JH_scoreMaster.getGeneralScore() >= scoreWon) {
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
            newGame.gameObject.SetActive(false);
            continueGame.gameObject.SetActive(false);

            // Message, wenn man gewonnen hat
            message.GetComponentInChildren<Text>().text = "Du hast GEWONNEN! :)";
            message.gameObject.SetActive(true);

            // Punkteanzeige
            score.GetComponentInChildren<Text>().text = "Deine Punkte: " + JH_scoreMaster.getGeneralScore();
            score.gameObject.SetActive(true);
        }
    }
}
