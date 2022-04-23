using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove_Ref : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.LoadLevel();
        }
    }
}