using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Linq;
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
    public List<string> textLine;
    public string[] dialogList;
    public List<questionText> questionsList;
    private int dialogIndex = 0;
    private bool isEnd=false;

    // Start is called before the first frame update
    void Start()
    {
     
        processText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void processText()
    {
        textLine = textFile.text.Split('\n').ToList(); 
    }

    public string ReStartDialog()
    {
        dialogIndex = 0;
        isEnd = false;
        return  GetDialog();
    }
    public string NextDialog()
    {
        if (dialogIndex < textLine.Count)
        {
            dialogIndex++;
            return GetDialog();
        }
        else
        {
            isEnd = true;
            return "";
        }
       
    }

    public string GetDialog()
    {
        return textLine[dialogIndex];
    }


    public string GotoLine(int i)
    {
        if (i < textLine.Count&& i>0)
        {
            dialogIndex=i;
        }
        else throw new System.InvalidOperationException("Line number out of Range");
        return GetDialog();
    }
}
