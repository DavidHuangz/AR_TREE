using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class VirtualSave
{
    public static void SaveVirtualDataNutrient(VirtualNutrient nutrient)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/nutrient.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        VirtualData data = new VirtualData(nutrient);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static VirtualData LoadVirtualDataNutrient() {
        string path = Application.persistentDataPath + "/nutrient.txt";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            VirtualData data = formatter.Deserialize(stream) as VirtualData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file has not been found in " + path);
            return null;
        }
    }

    public static void SaveVirtualData(VirtualWater water)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/virtual.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        VirtualData data = new VirtualData(water);

        formatter.Serialize(stream, data);
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
