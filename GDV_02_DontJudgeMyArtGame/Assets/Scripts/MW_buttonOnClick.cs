using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_buttonOnClick : MonoBehaviour
{
    public GameObject canvas;
    
    public void ContinueGame() {
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
