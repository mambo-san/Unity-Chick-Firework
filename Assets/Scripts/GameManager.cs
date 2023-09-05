using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Game Manger
    private static GameManager Instance { get; set; }
    
    //This is a hack to display hash table like structure in the Unity inspector
    [Serializable]
    private struct StartingChicks
    {
        public string difficulty;
        public GameObject chickPrefab;
    }
    [SerializeField]
    private StartingChicks[] startingChickPrefabSetter;


    //Simple variables
    private Dictionary<string, GameObject> startingChickDict;
    private Vector3 startPos = new Vector3(0,-52,-100);
    private int m_difficulty = 1;
    public int SelectedDifficulty // 1=Easy, 2=Med, 3=Hard
    {
        get{ return m_difficulty; }
        set {
            if (value < 1 || value > 3) 
            {
                Debug.LogWarning("Difficulty must be between 1~3");
            }
            else
            {
                m_difficulty = value;
            }
        }
    } 

    private void Awake()
    {
        //Only one instance of Game Manger allowed
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Create the dictionary for the first spawn (according to the prefab specified in inspector)
        startingChickDict = new Dictionary<string, GameObject>();
        for (int i = 0; i < startingChickPrefabSetter.Length; i++)
        {
            startingChickDict.Add(startingChickPrefabSetter[i].difficulty, startingChickPrefabSetter[i].chickPrefab);
        }

        SpawnFirstChick();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFirstChick()
    {
        GameObject firstChick;
        switch (m_difficulty)
        {
            case 1:
                firstChick = startingChickDict["Easy"];
                break;
            case 2:
                firstChick = startingChickDict["Medium"];
                break;
            case 3:
                firstChick = startingChickDict["Hard"];
                break;
            default:
                firstChick = startingChickDict["Easy"];
                break;
        }
        Instantiate(firstChick, startPos, firstChick.transform.rotation);
    }
}
