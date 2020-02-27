using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScenceControl : MonoBehaviour
{
    // Start is called before the first frame update
    public struct CheckPoint
    {
        public int number;
        public Transform spawnLocation;
        public UnityEvent spawnEvnt;
    }

    public CheckPoint[] checkPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScence()
    {
        GameData data = DataController.GetSave();

    }
    
}
