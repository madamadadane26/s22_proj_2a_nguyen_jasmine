using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponScript : MonoBehaviour
{
    private bool swing = false;
    int degree = 0;
    private float weaponY = -0.2f;
    private float weaponX = .7f;
    public float weaponPower = 1.0f;

    Vector3 pos;
    public GameObject player;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (swing)
        {
            degree -= 7;
            if (degree < -65)
            {
                degree = 0;
                swing = false;
                GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.eulerAngles = Vector3.forward * degree;
        }
    }

    void Attack()
    {
        if (player.GetComponent<PlayerScript>().turnedLeft)
        if (player.GetComponent<PlayerScript>().turnedLeft)
        {
            transform.localScale = new Vector3(-3f, 3f, 1);
            weaponX = -0.7f;
        }
        else
        {
            transform.localScale = new Vector3(3f, 3f, 1);
            weaponX = 0.7f;
        }

        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;
        swing = true;
    }


}