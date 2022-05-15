using UnityEngine;
using System.IO;

public class OptionsData : MonoBehaviour
{
    public Options options;

    /*
    private void Awake()
    {
        SaveOption saveOption = new SaveOption
        {
            setVolume = volume,
            setVibrate = vibrate
        };

        string json = JsonUtility.ToJson(saveOption);

        SaveOption loadedSaveOption = JsonUtility.FromJson<SaveOption>(json);
    }
    */

    public void OptionSave(bool volume, bool vibrate)
    {
        SaveOption saveOption = new SaveOption
        {
            setVolume = volume,
            setVibrate = vibrate
        };

        string path = Application.persistentDataPath + "/option.json";
        string json = JsonUtility.ToJson(saveOption);

        File.WriteAllText(path, json);
    }

    public void OptionLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/option.json"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/option.json");
            SaveOption saveOption = JsonUtility.FromJson<SaveOption>(saveString);

            options.isVolume = saveOption.setVolume;
            options.isVibrate = saveOption.setVibrate;

            Debug.Log(Application.persistentDataPath + "/option.json");
        }
        else
        {
            OptionSave(true, true);
            Debug.Log("Create new option data");
        }
    }

    public class SaveOption
    {
        public bool setVolume;
        public bool setVibrate;
    }
}
