using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    static GameData gameData;
    [Header("Custom game save")]
    [SerializeField]    string scenceName;
    [SerializeField]    int ckeckpoint;
    [SerializeField]    WordList[] WordSets;

    //public static string scenceName;
    //public static int ckeckpoint;
    //public static WordList[] WordSets;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gameData = CreateCustomSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private GameData CreateCustomSave()
    {
        var data = new GameData();
        data.scenceName = scenceName;
        data.checkPointNumber = ckeckpoint;
        data.CurrentWords = new List<WordList>(WordSets);
        return data;
    }
    static GameData CreateNewSave()
    {
        var data = new GameData();
        data.scenceName = "Library";
        data.checkPointNumber = 0;
        data.CurrentWords = new List<WordList>(VoiceRegognite.Instance.GetWordSet());
        return data;
    }

    public static GameData GetSave()
    {
        return gameData;
    }

}
