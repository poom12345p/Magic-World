using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
public class Dialog : MonoBehaviour
{
    [System.Serializable]
    public struct questionText
    {
        public int afterLine;
        public TextAsset QTextFile;
        public List<UnityEvent> QAction;
    }
    public TextAsset textFile;
    public string[] dialogList;
    public List<questionText> questionsList;

    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;  //this is the content as string
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDialog()
    {

    }
}
