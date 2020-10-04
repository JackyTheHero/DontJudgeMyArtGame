using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_buttonOnClick : MonoBehaviour
{
    public GameObject canvas;

    public static bool gameStarted = false;
    
    public void NewGame() {
        // Menü wird geschlossen, wenn man auf Button "Neues Spiel"
        canvas.gameObject.SetActive(false);
        // Spiel wurde gestartet -> true, da danach nur noch Button "Fortsetzen" erscheint
        gameStarted = true;
    }

    public void ContinueGame() {
        // Menü wird geschlossen, wenn man auf Button "Fortsetzen"
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame() {
        // Spiel wird geschlossen, wenn man auf Button "Ende" klickt
        Application.Quit();
    }
}
