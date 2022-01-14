using System.Collections.Generic;
using UnityEngine;

public class Localizator : MonoBehaviour
{
    public delegate void LanguageChanged();
    public static event LanguageChanged OnLanguageChanged;

    private static Localizator sInstance;
    public static Dictionary<string, string[]> uID = new Dictionary<string, string[]>();
    public static int LANG = 0;

    public TextAsset data;
    public Sprite[] icons;

    void Awake()
    {
        if (sInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            sInstance = this;

            LANG = PlayerPrefs.GetInt("Language_id", 0);

            Parse();
        }
    }

    void Parse()
    {
        string[] rows = data.text.Split('\n');

        foreach (string row in rows)
        {
            string[] fields = row.Split('\t');

            if (!uID.ContainsKey(fields[0]))
            {
                uID.Add(fields[0], fields);
            }
        }
    }

    public static void SetLanguage(int id)
    {
        LANG = id;
        PlayerPrefs.SetInt("Language_id", id);
        OnLanguageChanged?.Invoke();
    }

    public static string GetString(string key)
    {
        try
        {
            var val = uID[key];
            string result = val[LANG + 1].Replace("\\n", "\n");
            return result;
        }
        catch
        {
            Debug.Log("Translation not found for key: " + key);
        }

        return string.Empty;
    }

    public static Sprite GetImage(int languageId)
    {
        return sInstance.icons[languageId];
    }

    public static Sprite GetImage()
    {
        return sInstance.icons[LANG];
    }
}
