using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public int coins = 0;
    public void SaveFile(int lose = 0)
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        
        BinaryFormatter bf = new BinaryFormatter();
        if(Singleton.Instance.coins >= 5)
            bf.Serialize(file, Singleton.Instance.coins - lose);
        else
            bf.Serialize(file, 0);
        file.Close();
        SceneManager.LoadScene("FirstScene");
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            file = File.Create(destination); 

            BinaryFormatter bf2 = new BinaryFormatter();
            bf2.Serialize(file, 0);
            file.Close();
        }
        Debug.Log(destination);
        BinaryFormatter bf = new BinaryFormatter();
        coins = (int)bf.Deserialize(file);
        file.Close();

    }


}
