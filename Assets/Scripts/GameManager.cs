using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Game Manger
    public static GameManager Instance { get; private set; }
    
    //This is a hack to display hash table like structure in the Unity inspector
    [Serializable]
    private struct StartingChicks
    {
        public string difficulty;
        public GameObject chickPrefab;
    }
    [SerializeField]
    private StartingChicks[] startingChickPrefabSetter;
    public GameObject firstChick;
    public int spawnCount = 12;
    public float explosiveness = 3000;

    //Simple variables
    private Dictionary<string, GameObject> startingChickDict;
    private Vector3 startPos = new Vector3(0,-52,-100);
    public bool IsGameActive = false;
    private int m_difficulty = 0;
    public int SelectedDifficulty // 0=Standard, 1=Cross, 2=Chaos
    {
        get{ return m_difficulty; }
        set {
            if (value < 0 || value > 2) 
            {
                Debug.LogWarning("Difficulty must be between 0~2");
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
    }
    private void Start()
    {
        SpawnFirstChick();
    }

    public void SpawnFirstChick()
    {
        switch (m_difficulty)
        {
            case 0:
                firstChick = startingChickDict["Standard"];
                break;
            case 1:
                firstChick = startingChickDict["Cross"];
                break;
            case 2:
                firstChick = startingChickDict["Chaos"];
                break;
            default:
                firstChick = startingChickDict["Standard"];
                break;
        }
        firstChick = Instantiate(firstChick, startPos, firstChick.transform.rotation);
    }

    public void SpawnFirstChick(Vector3 pos)
    {
        switch (m_difficulty)
        {
            case 0:
                firstChick = startingChickDict["Standard"];
                break;
            case 1:
                firstChick = startingChickDict["Cross"];
                break;
            case 2:
                firstChick = startingChickDict["Chaos"];
                break;
            default:
                firstChick = startingChickDict["Standard"];
                break;
        }
        firstChick = Instantiate(firstChick, pos, firstChick.transform.rotation);
    }

    public void updateStartChickType(int optionSelected)
    {
        
        if (firstChick != null)
        {
            Vector3 posToSpawn = startPos;
            m_difficulty = optionSelected;
            posToSpawn = firstChick.transform.position;
            firstChick.gameObject.SetActive(false);
            SpawnFirstChick(posToSpawn);
        }
        else
        {
            SpawnFirstChick();
        }
    }

    public void ResetGame()
    {
        if(firstChick != null)
        {
            firstChick.gameObject.SetActive(false);
        }
        GameManager.Instance.IsGameActive = false;
        GameManager.Instance.SpawnFirstChick();
    }
}
