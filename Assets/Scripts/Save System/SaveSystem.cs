using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    static string path = Application.persistentDataPath + "/data.save";
    public static void SaveGame(int data) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path,FileMode.Create);

        SaveModel saveData = new SaveModel(data);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveModel LoadGame() {
        if(File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            SaveModel saveData = formatter.Deserialize(stream) as SaveModel;
            stream.Close();

            return saveData;
        } else {
            Debug.Log("No Save File");
            return null;
        }
   }
}