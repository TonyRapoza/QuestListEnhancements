/*  ------------------------------
*   DatabaseHandler.cs
*   ------------------------------
*   This script handles all the background processes for saving and loading the database file.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class DatabaseHandler
{
    // Saves Lists to JSON.
    public static void SaveToJSON<T>(List<T> toSave, string filename)
    {
        Debug.Log(GetPath(filename));
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath(filename), content);
    }

    // Saves data types handled by Unity's JSON Utility to JSON.
    public static void SaveToJSON<T>(T toSave, string filename)
    {
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    // Reads JSON files containing lists.
    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;

    }

    // Reads JSON files containing data types handled by Unity's JSON Utility.
    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }

        T res = JsonUtility.FromJson<T>(content);

        return res;

    }

    // Returns path in which JSON files will be stored and read from.
    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    // Writes file to path using Unity's IO package.
    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    // Reads files from path using Unity's IO package.
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}

// This class serves to allow the List specific functions above to work.
public static class JsonHelper
{
    // Takes wrapper from JSON and returns it.
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    // Takes array and creates wrapper.
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    // Takes array and creates wrapper.
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    // Defines wrapper.
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}