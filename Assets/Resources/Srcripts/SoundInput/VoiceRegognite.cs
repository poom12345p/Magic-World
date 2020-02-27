using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRegognite : MonoBehaviour
{
    public static Speaker VoiceRecigniteSpeaker;
    static public VoiceRegognite Instance;
    private KeywordRecognizer kwr,kw2;
    [SerializeField]private List<KeywordRecognizer> recogizerList=new List<KeywordRecognizer>();
    private List<WordList> wordSetLists=new List<WordList>();
    public WordList[] startWordSets;
    private Dictionary<string, string> actions = new Dictionary<string, string>();
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        VoiceRecigniteSpeaker = GetComponent<Speaker>();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        foreach (var wl in startWordSets)
        {
            AddWordList(wl);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RecogSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        VoiceRecigniteSpeaker.SentWord(speech.text);
        //speaker.SendToAll(speech.text);
    }

    public List<WordList> GetWordSet()
    {
        return wordSetLists;
    }
    public void AddWordList(WordList wl)
    {
        if (wordSetLists.Contains(wl))
        {
            return;
        }
        KeywordRecognizer newKey = new KeywordRecognizer(wl.wordslist, ConfidenceLevel.Rejected);
        wordSetLists.Add(wl);
        Debug.Log(wl.wordslist);
        recogizerList.Add(newKey);
        newKey.OnPhraseRecognized += RecogSpeech;
        newKey.Start();
    }
    public void removeWordList(WordList wl)
    {
        if (!wordSetLists.Contains(wl))
        {
            return;
        }
       int index = wordSetLists.IndexOf(wl);
        recogizerList[index].Stop();
        wordSetLists.Remove(wl);
        recogizerList.Remove(recogizerList[index]);
    }
}
