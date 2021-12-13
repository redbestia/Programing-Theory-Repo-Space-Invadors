using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

//ABSTRACTION
public static class FileHandler 
{
    public static void SaveToJson<T>(T toSave, string filename)
    {
        T data = toSave;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + filename, json);
    }
    public static void SaveToJson<T>(List<T> toSave,string filename)
    {
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WritrFile(GetPath(filename),content);
    }

    public static T ReadFromJson<T>(string filename) where T : class
    {
        string path = GetPath(filename);
        if (!File.Exists(path))
        {
            Debug.LogWarning("File dosn't exist, path: " + path);
            return null;
        }

        string json = File.ReadAllText(path);

        if (string.IsNullOrEmpty(path) || path == "{}")
        {
            Debug.LogWarning("T is null or empty or {}");
            return null;
        }
        
        T res = JsonUtility.FromJson<T>(json);

        return res;
    }

    public static List<T> ReadFromJsonToList<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            Debug.LogWarning("T is null or empty or {}");
            return new List<T>(); 
        }

        if (string.IsNullOrEmpty(content)  || content == "{}")
        {
            return new List<T>();
        }
        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;
    }

    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    private static void WritrFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }
    private static string ReadFile(string path)
    {
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
