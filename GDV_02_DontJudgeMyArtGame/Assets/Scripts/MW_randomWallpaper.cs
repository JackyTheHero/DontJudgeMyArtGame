using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_randomWallpaper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static Texture texture;
    static int range = 8;
    public static List<Texture> wallpapers = new List<Texture>();

    public static Texture RandomTexture(GameObject room) {
        // nach jedem Aufruf wird range kleiner, da eine Tapete gelöscht wird, um Dopplung zu vermeiden
        int number = Random.Range(0, range--);
        wallpapers.Add(Resources.Load("Tapete1") as Texture);
        wallpapers.Add(Resources.Load("Tapete2") as Texture);
        wallpapers.Add(Resources.Load("Tapete3") as Texture);
        wallpapers.Add(Resources.Load("Tapete4") as Texture);
        wallpapers.Add(Resources.Load("Tapete5") as Texture);
        wallpapers.Add(Resources.Load("Tapete6") as Texture);
        wallpapers.Add(Resources.Load("Tapete7") as Texture);
        wallpapers.Add(Resources.Load("Tapete8") as Texture);
        wallpapers.Add(Resources.Load("Tapete9") as Texture);

        if (number == 0) {
            return wallpapers[0];
        }
        if (number == 1) {
            return wallpapers[1];
        }
        if (number == 2) {
            return wallpapers[2];
        }
        if (number == 3) {
            return wallpapers[3];
        }
        if (number == 4) {
            return wallpapers[4];
        }
        if (number == 5) {
            return wallpapers[5];
        }
        if (number == 6) {
            return wallpapers[6];
        }
        if (number == 7) {
            return wallpapers[7];
        }
        if (number == 8) {
            return wallpapers[8];
        }
        return wallpapers[9];
    }
}
