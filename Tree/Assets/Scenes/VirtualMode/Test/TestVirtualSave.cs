using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class TestVirtualSave
{

    public static void SaveTestVirtualData(TestWater water, TestHealth health, TestRain rain)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/test_virtual.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        TestVirtualData data = new TestVirtualData(water, health, rain);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TestVirtualData LoadTestVirtualData()
    {
        string path = Application.persistentDataPath + "/test_virtual.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TestVirtualData data = formatter.Deserialize(stream) as TestVirtualData;
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
