using Crosstales.FB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LoadFromFile : MonoBehaviour
{
    string baseDir = "DATA";
    public void Awake()
    {
        LoadColors();
        LoadEnvelope();
        LoadLines();
    }
    public void LoadColors()
    {
        string path = $"{baseDir}/colors.txt";
        IEnumerable<string> lines;
        try
        {
            lines = File.ReadLines(path);
        }
        catch { return; }
        int linecount = 0;
        foreach (var line in lines)
        {
            if (line[0] == '#')
                continue;

            string[] rgbtext = line.Split(',');
            if (rgbtext.Length != 3)
                continue;

            byte[] rgb = new byte[3];
            for (int i = 0; i < rgbtext.Length; i++)
            {
                rgb[i] = Convert.ToByte(rgbtext[i]);
            }

            Color tmp = new Color32(rgb[0], rgb[1], rgb[2], 255);
            switch (linecount)
            {
                case 0:
                    Static_Data.primaryColor = tmp;
                    break;
                case 1:
                    Static_Data.secondaryColor = tmp;
                    break;
                case 2:
                    Static_Data.thirteenColor = tmp;
                    break;
                case 3:
                    Static_Data.bordersColor = tmp;
                    break;
                case 4:
                    Static_Data.arrowColor = tmp;
                    break;
                case 5:
                    Static_Data.spinColor = tmp;
                    break;
                case 6:
                    Static_Data.domeColor = tmp;
                    break;
            }
            linecount++;
        }
    }
    public void LoadEnvelope()
    {
        string path = $"{baseDir}/envelope.png";
        byte[] bytes = null;
        try
        {
            bytes = File.ReadAllBytes(path);
        }
        catch { return; }
        Texture2D tex = new Texture2D(800, 450);
        tex.LoadImage(bytes);
        Static_Data.customLetter = tex;
    }
    public void LoadLines()
    {
        string path = $"{baseDir}/lines.txt";
        var lines = File.ReadAllLines(path);

        Static_Data.whiteFont = lines[0].Contains("0") ? false : true;

        string[] l = new string[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++)
        {
            l[i - 1] = lines[i];
        }

        lines = new string[l.Length];
        lines = l;

        Static_Data.segments = lines.Length + 1;
        List<string> segmentOptions = new List<string>();

        if (lines.Length < 13)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                segmentOptions.Add(lines[i]);
            }
            segmentOptions.Add("13");
        }
        else
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 12)
                    segmentOptions.Add("13");
                segmentOptions.Add(lines[i]);
            }
        }

        Static_Data.segmentOptions = segmentOptions;
    }

}
