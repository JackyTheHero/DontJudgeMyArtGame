using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_buttonOnClick : MonoBehaviour
{
    public GameObject canvas;

    public static bool gameStarted = false;

    AudioSource sound;
    AudioClip click;

    void Start()
    {
        //Audio-Daten holen
        sound = GameObject.FindWithTag("Sound").GetComponent<AudioSource>();  
        click = Resources.Load("click") as AudioClip;
    }
    
    public void NewGame() {
        // Menü wird geschlossen, wenn man auf Button "Neues Spiel"
        canvas.gameObject.SetActive(false);
        // Spiel wurde gestartet -> true, da danach nur noch Button "Fortsetzen" erscheint
        gameStarted = true;
        sound.PlayOneShot(click, 1.0F); 
    }

    public void ContinueGame() {
        // Menü wird geschlossen, wenn man auf Button "Fortsetzen"
        canvas.gameObject.SetActive(false);
        sound.PlayOneShot(click, 1.0F); 
    }

    public void QuitGame() {
        // Spiel wird geschlossen, wenn man auf Button "Ende" klickt
        Application.Quit();
    }
}

//Button Click 3 by Mellau
//Licensed under Creative Commons: By Attribution-NonCommercial 3.0 
//https://freesound.org/people/Mellau/sounds/506052/
