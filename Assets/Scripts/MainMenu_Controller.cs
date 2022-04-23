using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CS583
{
    public class MainMenu_Controller : MonoBehaviour
    {

        public Button startButton;
        public Button ExitButton;
        public Button settingsButton;
        public Button aboutButton;
        private Button playGameButton;


        private void Awake()
        {
        }


        private void moreUIReferences()
        {

            ExitButton = GameObject.Find("b_Quit").GetComponent<Button>();
            ExitButton.onClick.AddListener(quitButton);

            settingsButton = GameObject.Find("b_Settings").GetComponent<Button>();
            settingsButton.onClick.AddListener(gameSettings);

            aboutButton = GameObject.Find("b_About").GetComponent<Button>();
            aboutButton.onClick.AddListener(gameAbout);

            playGameButton = GameObject.Find("b_Play_Game").GetComponent<Button>();
            playGameButton.onClick.AddListener(playGameScene);



        }


        public void playGameScene()
        {
            SceneManager.LoadScene(3);
        }

        public void gameSettings()
        {
            SceneManager.LoadScene(1);
        }


        public void gameAbout()
        {
            SceneManager.LoadScene(2);
        }
        //quit button
        public void quitButton()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }


    }
}
