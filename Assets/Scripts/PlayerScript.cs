using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : GameManager
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb;

    private float health = 200;
    private float startHealth;

    public bool turnedLeft = false;
    public Image healthFill;
    private float healthWidth;

    public Image mainText;
    public Image redOverlay;
    public Text expText;
    public Button retryButton;
    public Vector3 enter;

    public Image dialogBox;
    public Image dialogBox2;

    public Text dialogTextMC;
    public Text dialogTextGIRL;
    public Text dialogTextBOY;

    public Image dialogSpriteMC;
    public Image dialogSpriteGirl;
    public Image dialogSpriteGuy;


    public GameManager gameManager;



    private int experience = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthWidth = healthFill.sprite.rect.width;
        startHealth = health;
        mainText.gameObject.SetActive(false);

        redOverlay.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        dialogBox.gameObject.SetActive(false);
        dialogBox2.gameObject.SetActive(false);

        dialogTextMC.gameObject.SetActive(false);
        dialogTextGIRL.gameObject.SetActive(false);
        dialogTextBOY.gameObject.SetActive(false);

        dialogSpriteMC.gameObject.SetActive(false);
        dialogSpriteGirl.gameObject.SetActive(false);
        dialogSpriteGuy.gameObject.SetActive(false);



        //transform.position = GameManager.Instance.SpawnLocation;


    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        if (horizontal > 0)
        {
            GetComponent<Animator>().Play("Right");
        }
        else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("Left");
            turnedLeft = true;
        }
        else if (vertical > 0)
        {
            GetComponent<Animator>().Play("Up");
        }
        else if (vertical < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            health -= collision.gameObject.GetComponent<EnemyScript>().GetHitStrength();
            if (health < 1)
            {
                healthFill.enabled = false;
                mainText.gameObject.SetActive(true);
                redOverlay.gameObject.SetActive(true);
                retryButton.gameObject.SetActive(true);

            }
            Vector2 temp = new Vector2(healthWidth * (health / startHealth), healthFill.sprite.rect.height);
            healthFill.rectTransform.sizeDelta = temp;
            Invoke("HidePlayerBlood", 0.25f);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            health -= collision.gameObject.GetComponent<BossScript>().GetBossHitStrength();
            if (health < 1)
            {
                healthFill.enabled = false;
                mainText.gameObject.SetActive(true);
                redOverlay.gameObject.SetActive(true);
                retryButton.gameObject.SetActive(true);
            }
            Vector2 temp = new Vector2(healthWidth * (health / startHealth), healthFill.sprite.rect.height);
            healthFill.rectTransform.sizeDelta = temp;
            Invoke("HidePlayerBlood", 0.25f);
        }

        if (collision.gameObject.CompareTag("GIRL"))
        {
            Debug.Log("girl talk");

            dialogBox2.gameObject.SetActive(true);
            dialogTextGIRL.gameObject.SetActive(true);
            dialogSpriteGirl.gameObject.SetActive(true);
        }
        else
        {

            dialogBox2.gameObject.SetActive(false);
            dialogTextGIRL.gameObject.SetActive(false);
            dialogSpriteGirl.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("BOY"))
        {
            Debug.Log("Guy talk");

            dialogBox.gameObject.SetActive(true);
            dialogTextBOY.gameObject.SetActive(true);
            dialogSpriteGuy.gameObject.SetActive(true);
        }
        else
        {

            dialogBox.gameObject.SetActive(false);
            dialogTextBOY.gameObject.SetActive(false);
            dialogSpriteGuy.gameObject.SetActive(false);
        }

    }


    void HidePlayerBlood()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void retryButtonClick(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        expText.text = experience.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            GameObject.Find("Controller").GetComponent<Controller>().Respawn();
            gameManager.LoadLevel();
            Debug.Log("spawn");

        }
    }

}