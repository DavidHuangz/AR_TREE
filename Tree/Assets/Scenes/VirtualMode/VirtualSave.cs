using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class VirtualSave
{
    public static void SaveVirtualData(
        VirtualWater water,
        VirtualNutrient nutrient,
        VirtualHealth health,
        VirtualWeather weather
    )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/virtual.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        VirtualData data = new VirtualData(water, nutrient, health, weather);

        formatter.Serialize (stream, data);
        stream.Close();
    }

    public static VirtualData LoadVirtualData()
    {
        string path = Application.persistentDataPath + "/virtual.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            VirtualData data = formatter.Deserialize(stream) as VirtualData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file has not been found in " + path);
            return null;
        }
    }
}
