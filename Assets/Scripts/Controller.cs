using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private static bool created = false;
    public static Controller instance;
    public GameManager gameManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public void Respawn()
    {
        SceneManager.LoadScene(0);
        gameManager.LoadLevel();

        GameObject.Find("Player").transform.position = GameObject.Find("Controller").transform.position;
    }
}
