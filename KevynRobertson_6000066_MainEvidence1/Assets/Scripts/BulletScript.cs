using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    // public Image healthBarOne, healthBarTwo;
    // private float healthMax = 100;
    // public float currentHealthOne, currentHealthTwo;
    // public float damage = 15;

    void Awake()
    {
        // healthBarOne = GameObject.Find("Blue Health").GetComponent<Image>();
        // healthBarTwo = GameObject.Find("Red Health").GetComponent<Image>();
        // currentHealthOne = healthMax;
        // currentHealthTwo = healthMax;
    }


    public void OnCollisionEnter(Collision collision)
    {
        
        // if(collision.gameObject.CompareTag("playerOne"))
        // {
        // currentHealthOne -= damage;
        // healthBarOne.fillAmount = currentHealthOne/healthMax;
        // PlayerScript Respawn = collision.gameObject.GetComponent<PlayerScript>();
        // }
        
        // if(collision.gameObject.CompareTag("playerTwo"))
        // {
        // currentHealthTwo -= damage;
        // healthBarTwo.fillAmount = currentHealthTwo/healthMax;
        // PlayerScript Respawn = collision.gameObject.GetComponent<PlayerScript>();
        // }
        
        // if(currentHealthOne <= 0)
        // {
        //     Respawn.Respawn();
        //     currentHealthOne = 100;
        // }
        // if(currentHealthTwo <= 0)
        // {
        //     Respawn.Respawn();
        //     currentHealthTwo = 100;
        // }

        gameObject.SetActive(false);
    }
}
