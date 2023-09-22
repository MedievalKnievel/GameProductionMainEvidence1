using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    private GameObject Target;
    public GameObject endPoint;
    public GameObject Spawn;
    public GameObject playerPointOne;
    public GameObject playerPointTwo;
    private float speed = 5f;
    public TextMeshProUGUI blueScore, redScore;
    private float bluePoint = 0, redPoint = 0;
    private SoundScript sounds;

    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("sounds").GetComponent<SoundScript>();
        Target = endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
        checkWin();
    }

    public void enemyMove(){
        var step = speed * Time.deltaTime;
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Target.transform.position, step);
        transform.LookAt(Target.transform);

        if(Vector3.Distance(Enemy.transform.position, endPoint.transform.position) < 1f)
         {
            Enemy.transform.position = Spawn.transform.position;
            Target = endPoint;
         }

         if(Vector3.Distance(Enemy.transform.position, PlayerOne.transform.position) < 1.5f)
         {
            Target = PlayerOne;
            speed = 0f;
         }else{ if(Target != PlayerTwo){speed = 5f;} }

         if(Vector3.Distance(Enemy.transform.position, PlayerTwo.transform.position) < 1.5f)
         {
            Target = PlayerTwo;
            speed = 0f;
         }else{ if(Target != PlayerOne){speed = 5f;} }

         if(Vector3.Distance(Enemy.transform.position, playerPointOne.transform.position) < 1f)
         {
            Enemy.transform.position = Spawn.transform.position;
            Target = endPoint;
            bluePoint += 1;
            sounds.Score();
            blueScore.text = bluePoint.ToString();
            print(bluePoint);
         }

         if(Vector3.Distance(Enemy.transform.position, playerPointTwo.transform.position) < 1f)
         {
            Enemy.transform.position = Spawn.transform.position;
            Target = endPoint;
            redPoint += 1;
            sounds.Score();
            redScore.text = redPoint.ToString();
            print(redPoint);
         }


    }

    private void checkWin()
    {
        if(redPoint >= 5)
        {
         Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
        if(bluePoint >= 5)
        {
         Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(4);
        }
    }

}
