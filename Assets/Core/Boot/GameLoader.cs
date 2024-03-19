using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    //Check if CD is in the drive.
    public static (string CDGameID, bool CDInDriver) GetCDGameID()
    {
        string systemCNF;
        bool CDDriver;

        try
        {
            //Search for game SYSTEM.CNF and read to find Playstation game ID.
            systemCNF = File.ReadAllText("E:\\SYSTEM.CNF");

            CDDriver = true;

            systemCNF = systemCNF.Replace("BOOT = cdrom:\\", "");
            systemCNF = systemCNF.Replace("EVENT = 20", "");
            systemCNF = systemCNF.Replace("TCB = 5", "");
            systemCNF = systemCNF.Replace("STACK = 801FFFF0", "");
            systemCNF = systemCNF.Trim();

            systemCNF = systemCNF.Substring(0, systemCNF.Length - 2);

            //Replace underline to hyphen and remove dot for better comunication with database images.
            systemCNF = systemCNF.Replace("_", "-");
            systemCNF = systemCNF.Replace(".", "");
        }

        catch
        {
            //Set empty and false if there's no Playstation CD in the drive.
            systemCNF = "";
            CDDriver = false;
        }

        return (systemCNF, CDDriver);
    }

    public void LoadGame(string gamePath)
    {

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
