using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_Data : MonoBehaviour
{
    public static int segments = 10;
    public static List<string> segmentOptions = null;
    public static GameObject[] letters;
    public static GameObject[] nexts;
    public static int selectedSector = -1;
    public static List<int> scriptedSectors = new List<int>();

    public bool colorsLoaded = false;
    public static Color primaryColor = new Color32(156, 153, 153, 1);
    public static Color secondaryColor = new Color32(113, 112, 110, 1);
    public static Color thirteenColor = new Color32(153, 3, 3, 1);
    public static Color bordersColor = new Color32(0, 0, 0, 1);
    public static Color arrowColor = new Color32(255, 0, 0, 1);
    public static Color spinColor = new Color32(255, 33, 0, 1);
    public static Color domeColor = new Color32(255, 255, 255, 1);

    public static Texture2D customLetter = null;
    public static Texture2D customDummy = null;

    public static bool whiteFont = false;
}
