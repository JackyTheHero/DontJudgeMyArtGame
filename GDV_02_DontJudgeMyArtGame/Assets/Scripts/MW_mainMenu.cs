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
    public Button quitGame;

    // Start is called before the first frame update
    void Start()
    {
        checkMenu();
        canvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        mouseCursor();

        checkMenu();

        startMenu();
    }

    void checkMenu() {
        if (canvas.gameObject.activeSelf == true) {
            isInMenu = true;
        } else {
            isInMenu = false;
        }
    }

    void startMenu() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isInMenu == false) {
                canvas.gameObject.SetActive(true);
            }
            if (isInMenu == true) {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    void mouseCursor() {
        // Maus-Cursor wird ausgeblendet, wenn man sich nicht im Menü befindet
        if (isInMenu == true) {
            Cursor.visible = true;
            Time.timeScale = 0;
        } else {
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
