using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DE_simpleGUIScript : MonoBehaviour
{
    
    public Font font;

    GUIStyle style;
    GUIStyle styleChase;
    GUIStyle styleMenu;
    
    Rect rectText;
    Rect rectScore;
    Rect rectChase;
    Rect rectDestroy;
    Rect rectSteal;
    Rect rectBack;
    Rect rectPicScore;
    Rect rectPicImage;
    

    void Start(){

        //Neue Stile anlegen
        style = new GUIStyle();
        style.font = font;
        style.fontSize = 25;
        style.alignment = TextAnchor.UpperCenter;
        style.normal.textColor = Color.black;

        styleChase = new GUIStyle();
        styleChase.font = font;
        styleChase.fontSize = 30;
        styleChase.alignment = TextAnchor.UpperCenter;
        styleChase.normal.textColor = Color.red;

        //Text-Rechtecke setzen
        rectText = new Rect(0,0, 50, 50);
        rectText.center = new Vector2(Screen.width / 2, 4 * Screen.height / 12);

        rectScore = new Rect(0,0, 50, 50);
        rectScore.center = new Vector2(11 * Screen.width / 12, 1 * Screen.height / 12);

        rectChase = new Rect(0,0, 50, 50);
        rectChase.center = new Vector2(Screen.width / 2, 2 * Screen.height / 12);

        rectDestroy = new Rect(0,0, 50, 50);
        rectDestroy.center = new Vector2(3 * Screen.width / 12, 11 * Screen.height / 12);

        rectSteal = new Rect(0,0, 50, 50);
        rectSteal.center = new Vector2(6 * Screen.width / 12, 11 * Screen.height / 12);

        rectBack = new Rect(0,0, 50, 50);
        rectBack.center = new Vector2(9 * Screen.width / 12, 11 * Screen.height / 12);

        rectPicScore = new Rect(0,0, 50, 50);
        rectPicScore.center = new Vector2(10 * Screen.width / 12, 5 * Screen.height / 12);

        rectPicImage = new Rect(0,0, Screen.width / 8, Screen.width / 8);
        rectPicImage.center = new Vector2(10 * Screen.width / 12, 5 * Screen.height / 24);

    }

    void OnGUI(){

        //Nur wenn nicht im Hauptmenü
        if (!MW_mainMenu.isInMenu){
            
            //Score, nicht im Bildmenü)
            if(!DE_cameraPan.inMenu){
                GUI.Label(rectScore, "Score: " + JH_scoreMaster.getGeneralScore().ToString(), style);
            }

            //Fenster-Hinweis
            if (MW_playerColliderInteraction.isInWindowRange == true && MW_playerColliderInteraction.steal == true){
                
                GUI.Label(rectText, "Drücke 'E', um das Bild aus dem Fenster zu schmuggeln", style);
            }

            //Bild-Hinweis
            if (DE_pictureCollision.isInPictureRange == true && DE_cameraPan.inMenu == false && DE_cameraPan.inMotion == false){
                
                GUI.Label(rectText, "Drücke 'E', um das Bild zu betrachten", style);
            }

            //Wächter-Warnung
            if(DE_guardBehaviour.chase || DE_guardBehaviour1.chase || DE_guardBehaviour2.chase){
                GUI.Label(rectChase, "Ein Wächter Verfolgt Dich!", styleChase);   
            }
        }

        //Bildmenü, nur wenn nicht in Hauptmenü
        if(DE_cameraPan.inMenu && !DE_cameraPan.inMotion && !MW_mainMenu.isInMenu){
                GUI.Label(rectBack, "'E' - Verlassen", style);   

            //nur wenn Spieler-Bild
            if(MW_playerColliderInteraction.owned){
                GUI.Label(rectDestroy, "'1' - Zerstören", style);
                GUI.Label(rectSteal, "'2' - Stehlen", style);

                GUI.Label(rectPicScore, "Bewertung: " + JH_scoreMaster.getPaintingScore(DE_pictureCollision.focusPicture).ToString(), style);

                //Unterschiedliche Grafik je nach positiver und negativer Bewertung, kein Bild bei 0
                Texture img;
                if(JH_scoreMaster.getPaintingScore(DE_pictureCollision.focusPicture) > 0){
                    img = Resources.Load("thumbsUpMenu") as Texture;
                    GUI.Label(rectPicImage, img, style);
                } 
                if(JH_scoreMaster.getPaintingScore(DE_pictureCollision.focusPicture) < 0){
                    img = Resources.Load("thumbsDownMenu") as Texture;
                    GUI.Label(rectPicImage, img, style);
                }

            }   
        }
        

    }
}
