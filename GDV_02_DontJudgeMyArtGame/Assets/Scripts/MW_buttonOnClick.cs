using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_buttonOnClick : MonoBehaviour
{
    public GameObject canvas;
    
    public void ContinueGame() {
        // Menü wird geschlossen, wenn man auf Button "Fortsetzen" ...
        // ... oder in unserem Fall ebenso "Neues Spiel" klickt
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame() {
        // Spiel wird geschlossen, wenn man auf Button "Ende" klickt
        Application.Quit();
    }
}
