using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Back");
    }
}
