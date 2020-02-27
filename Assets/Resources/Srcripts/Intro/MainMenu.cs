using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Scene StartScence;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        LoadScence("SampleScene");
    }
    public void LoadGame()
    {
        GameData curData = DataController.GetSave();
        LoadScence(curData.scenceName);
    }

    public void LoadScence(string scenceName)
    {
        //Fade
        //
        SceneManager.LoadScene(scenceName, LoadSceneMode.Single);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
