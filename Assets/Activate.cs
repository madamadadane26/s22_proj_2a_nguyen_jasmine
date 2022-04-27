using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{
    // Start is called before the first frame update
    public Image dialogBox;
    public Text dialogTextMC;
    public Image dialogSpriteMC;


    private void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        //Wait for 4 secs.
        yield return new WaitForSeconds(1);

        //Turn My game object that is set to false(off) to True(on).
        dialogSpriteMC.gameObject.SetActive(true);

        dialogBox.gameObject.SetActive(true);
        dialogTextMC.gameObject.SetActive(true);

        //Turn the Game Oject back off after sec.
        yield return new WaitForSeconds(2);

        //Game object will turn off
        dialogSpriteMC.gameObject.SetActive(false);
        dialogBox.gameObject.SetActive(false);
        dialogTextMC.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
