using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    RawImage rawImageComp;
    private bool movieStarted;
    public VideoPlayer videoPlayer;

    public Image winningText;
    public Button returnButton;


    public Texture2D fadeTexture;

    [Range(0.1f, 1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    private float alpha = 1f;
    private float fadeDir = -1f;

    void Start()
    {
        winningText.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        //videoPlayer.Play();




        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        winningText.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        Debug.Log("video end");
    }

    private void OnGUI()
    {

        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}