
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //public static void SavePlayer(PlayerData data)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Path.Combine(Application.persistentDataPath, "/player.txt");

    //    Debug.Log(path);

    //    FileStream stream = new FileStream(path, FileMode.Create);


    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    public static void SavePlayer(PlayerData data)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.txt");

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }

    //public static PlayerData LoadPlayer() {

    //    string path = Path.Combine(Application.persistentDataPath, "/player.txt");
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //        stream.Close();

    //        return data;
    //    }
    //    else
    //    {
    //        PlayerData defaultdata = new PlayerData(0,20,100,2); 

    //        //Debug.LogError("Save File Not Found" + path);
    //        return defaultdata;
    //    }
    //}

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.txt");

        if (File.Exists(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }
        }
        else
        {
            PlayerData defaultData = new PlayerData(0, 20, 100, 2);
            return defaultData;
        }


    }

    public static void UpdateCoins(int coinsToAdd)
    {
        PlayerData data = LoadPlayer();
        data.coins = data.coins + coinsToAdd; // Update the coins
        SavePlayer(data); // Save the updated data
    }
}
