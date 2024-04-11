using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    //Check if CD is in the drive.
    public static (string CDGameID, bool CDInDriver) GetCDGameID()
    {
        //string systemCNF;
        string[] systemCNF;
        string cnfLine;
        bool CDDriver;

        try
        {
            //Search for game SYSTEM.CNF and read to find Playstation game ID.
            systemCNF = File.ReadAllLines("E:\\SYSTEM.CNF");

            CDDriver = true;

            cnfLine = systemCNF[0];

            cnfLine = cnfLine.Replace("BOOT = cdrom:\\", "");
            cnfLine = cnfLine.Trim();

            cnfLine = cnfLine.Substring(0, cnfLine.Length - 2);

            //Replace underline to hyphen and remove dot for better comunication with database images.
            cnfLine = cnfLine.Replace("_", "-");
            cnfLine = cnfLine.Replace(".", "");
        }

        catch
        {
            //Set empty and false if there's no Playstation CD in the drive.
            cnfLine = "";
            CDDriver = false;
        }

        return (cnfLine, CDDriver);
    }

    public string GetGameID(string gamePath)
    {
        try
        {
            using (FileStream fs = new FileStream(gamePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
            {
                // Defina o offset e o tamanho conforme necessário
                long offset = 54134; // Offset em decimal
                int tamanho = 11; // Duração em decimal

                // Posiciona o leitor no offset desejado
                fs.Seek(offset, SeekOrigin.Begin);

                // Lê os bytes do arquivo e converte para string usando a codificação ANSI
                byte[] bytes = br.ReadBytes(tamanho);
                string gameID = Encoding.Default.GetString(bytes);

                // Retorna a string extraída
                return gameID;
            }
        }
        catch (Exception ex)
        {
            // Trata a exceção e retorna uma string vazia ou mensagem de erro
            Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            return string.Empty;
        }
    }

    public static void CreateGamesList(string gamePath)
    {
        // Obtém todos os arquivos com a extensão .bin na pasta especificada
        string[] idList;
        string[] filesList = Directory.GetFiles(gamePath, "*.bin");

        idList = new string[filesList.Length];

        //Pega ID de cada jogo carregado na filesList
        for (int i = 0; i < filesList.Length; i++)
        {
            idList.SetValue((string)filesList.GetValue(i), i);
        }
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
