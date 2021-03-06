﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
class GameData
{
    public int bestScore;
    public int totalPlays;
}

public class SaveLoadData : MonoBehaviour {

    static string GAME_DATA_FILE_NAME = "/gameData.dat";

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + GAME_DATA_FILE_NAME);
        GameData data = new GameData();

        if (GameManager.bestScore > data.bestScore)
            data.bestScore = GameManager.bestScore;
        data.totalPlays = GameManager.totalPlays;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + GAME_DATA_FILE_NAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + GAME_DATA_FILE_NAME, FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            GameManager.bestScore = data.bestScore;
            GameManager.totalPlays = data.totalPlays;
        }
    }
}
