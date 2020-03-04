using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variables that state the arrays, game object and game mamager
    public static GameManager instance;
    public GameObject instantiatedPlayerTank;
    public GameObject playerTankPrefab;
    public GameObject[] enemyTanks;
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

     void Update()
    {
        if(instantiatedPlayerTank == null)
        {
            SpawnPlayer(RandomSpawnPoint(playerSpawnPoints));
        }
    }

    private GameObject RandomSpawnPoint(List<GameObject> spawnPoints)
    {
        //Get a random spawn point from inside our list of spawn points.
        int spawnToGet = UnityEngine.Random.Range(0, spawnPoints.Count -1);
            return spawnPoints[spawnToGet];
            
    }

    public void SpawnPlayer(GameObject spawnPoint)
    {
       instantiatedPlayerTank = Instantiate(playerTankPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void SpawnEnmies()
    {
        //write code for spawning enmies.
    }
}
