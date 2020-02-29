using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variables that state the arrays, game object and game mamager
    public static GameManager instance;
    public GameObject playerTank;
    public GameObject[] enemyTanks;
    public List<Transform> enemySpawnPoints;

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

}
