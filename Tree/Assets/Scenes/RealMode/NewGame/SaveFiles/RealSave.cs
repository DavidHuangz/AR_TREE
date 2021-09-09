using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class RealSave
{
    public static void SaveRealDataNutrient(Nutrient nutrient)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/real_nutrient.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        RealData data = new RealData(nutrient);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static RealData LoadRealDataNutrient() {
        string path = Application.persistentDataPath + "/real_nutrient.txt";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RealData data = formatter.Deserialize(stream) as RealData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file has not been found in " + path);
            return null;
        }
    }

    public static void SaveRealData(Water water)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/real_water.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        RealData data = new RealData(water);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static RealData LoadRealData()
    {
        string path = Application.persistentDataPath + "/real_water.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RealData data = formatter.Deserialize(stream) as RealData;
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
