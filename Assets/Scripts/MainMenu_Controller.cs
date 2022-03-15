using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CS583
{
    public class menuScreenController : MonoBehaviour
    {

        public Button startButton;
        public Button ExitButton;
        public Button settingsButton;
        public Button aboutButton;
        private Button playGameButton;
        static public bool characterRollDone = false;


        private void Awake()
        {
        }


        private void moreUIReferences()
        {

            ExitButton = GameObject.Find("quitButton").GetComponent<Button>();
            ExitButton.onClick.AddListener(quitButton);

            settingsButton = GameObject.Find("b_Settings").GetComponent<Button>();
            settingsButton.onClick.AddListener(gameSettings);

            aboutButton = GameObject.Find("b_About").GetComponent<Button>();
            aboutButton.onClick.AddListener(gameAbout);

            playGameButton = GameObject.Find("b_Play_Game").GetComponent<Button>();
            playGameButton.onClick.AddListener(playGameScene);



        }


        public void gameAbout()
        {
            SceneManager.LoadScene(1);
        }

        public void gameSettings()
        {
            SceneManager.LoadScene(2);
        }

        public void playGameScene()
        {
            SceneManager.LoadScene(3);
        }

        //quit button
        public void quitButton()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }


    }
}
