using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawners;
    private int level = 0;
    private int currentScene = 0;
    private int enemyCount = 0;
    private int bossCount = 0;

    private int enemyLimit = 10;
    private int bossLimit = 1;

    //public static GameManager Instance;
    //public Vector3 SpawnLocation = Vector3.zero;

    public GameObject player;
    public GameObject weapon;
    public GameObject hudCanvas;
    public GameObject mainCam;
    public GameObject controller;

    private Scene scene;

    void Start()
    {
        PrepareSpawners();

    }

    void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(weapon.gameObject);
        DontDestroyOnLoad(hudCanvas.gameObject);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(mainCam.gameObject);
        //DontDestroyOnLoad(controller.gameObject);

        scene = SceneManager.GetActiveScene();


        }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!string.Equals(scene.path, this.scene.path))
        {
            level++;
            PrepareSpawners();
        }

        if (scene.name == "MainMenu_Controller")
        {
            // Destroy the gameobject this script is attached to
            Destroy(gameObject);
        }
    }

    void PrepareSpawners()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        if (spawners.Length > 0)
        {
            int rnd = Random.Range(0, spawners.Length);
            spawners[rnd].GetComponent<SpawnerScript>().SetGateway(true);
        }
    }

    public void SetEnemyCount(int amount)
    {
        enemyCount += amount;
    }
    public void SetBossCount(int amount)
    {
        bossCount += amount;
    }
    public int GetEnemyCount()
    {
        return enemyCount;
    }
    public int GetBossCount()
    {
        return bossCount;
    }
    public int GetEnemyLimit()
    {
        return enemyLimit;
    }

    public int GetBossLimit()
    {
        return bossLimit;
    }

    public void LoadLevel()
    {
        enemyCount = 0;
        bossCount = 0;
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            currentScene = 1;
        }
        else
        {
            currentScene = -1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + currentScene);
    }

    public int GetLevel()
    {
        return level;
    }

}