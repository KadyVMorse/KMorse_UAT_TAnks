using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variables that state the arrays, game object and game mamager
    public static GameManager instance;

    public GameObject levelGameObject;
    public GameObject instantiatedPlayerTank;
    public GameObject playerTankPrefab;
    public List<GameObject> instantiatedEnemyTanks;
    public GameObject[] enemyTanksPrefabs;
    public List<GameObject> playerSpawnPoints;
    public List<GameObject> enemySpawnPoints;

    // Runs before any Start() functions run
    void Awake()
    {
        // if a game manger is made then it will only be one and if more is made then it will say you cant have more then one they destroy game manager also the game manager will not be destroyed on load throughout level
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ERROR: There can only be one GameManager.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
     void Start()
    {
        instantiatedEnemyTanks = new List<GameObject>();
        playerSpawnPoints = new List<GameObject>();
        enemySpawnPoints = new List<GameObject>();
    }
    void Update()
    {
        if(instantiatedPlayerTank == null)
        {
            SpawnPlayer(RandomSpawnPoint(playerSpawnPoints));
        }
    }

    public GameObject RandomSpawnPoint(List<GameObject> spawnPoints)
    {
        //Get a random spawn point from inside our list of spawn points.
        int spawnToGet = UnityEngine.Random.Range(0, spawnPoints.Count -1);
            return spawnPoints[spawnToGet];
            
    }

    public void SpawnPlayer(GameObject spawnPoint)
    {
       instantiatedPlayerTank = Instantiate(playerTankPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void SpawnEnemies()
    {
        //write code for spawning enmies. // Write code for spawning enemies.
        if (enemyTanksPrefabs.Length == 0)
        { Debug.LogWarning("Enemy tank prefabs is empty"); }
        for (int i = 0; i < enemyTanksPrefabs.Length; ++i)
        {
            if (enemySpawnPoints.Count == 0)
            { Debug.LogWarning("Enemy spawn points list is empty."); }
            GameObject instantiatedEnemyTank =
                Instantiate(enemyTanksPrefabs[i], RandomSpawnPoint(enemySpawnPoints).transform.position, Quaternion.identity);
            instantiatedEnemyTanks.Add(instantiatedEnemyTank);
        }
    }
}
