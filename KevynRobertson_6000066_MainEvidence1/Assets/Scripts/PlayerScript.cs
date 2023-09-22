using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpForce = 2.0f;
    public float gravity = -9.8f;
    private Vector3 velocity;
    private bool grounded = true;
    private Vector2 move;
    private float fallspeed = -2f;
    private CharacterController controller;
    private PlayerControls controls;
    public Transform ground;
    public LayerMask groundMask;
    public float distanceToGround = 0.4f;
    public GameObject bullet;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject playerPointOne;
    public GameObject playerPointTwo;
    public GameObject spawn;
    public Transform firePoint;
    public int pool = 10;
    public List<GameObject> bulletPool;
    public Image healthBar;
    private float healthMax = 100;
    public float currentHealth;
    public float damage = 10;
    private SoundScript sounds;
    
    

    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("sounds").GetComponent<SoundScript>();
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        currentHealth = healthMax;
        bulletPool = new List<GameObject>();
        for(int i = 0; i < pool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
        spawn.transform.localPosition = Player.transform.position;
        spawn.transform.localRotation = Player.transform.rotation;
    }

    void Update()
    {
        PlayerMovement();
        Gravity();
    }

    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            if(!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].SetActive(true);
                return bulletPool[i];
            }
        }
        return null;
    }

    public void onMove(InputAction.CallbackContext context)
    {
         move = context.ReadValue<Vector2>();
    }

    private void PlayerMovement()
    {
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * speed * Time.deltaTime);
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Shoot();
        }
        sounds.Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = GetBullet();

        if(bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.useGravity = false;
            bulletRb.velocity = bullet.transform.forward * 80f;
            StartCoroutine(ReturnBulletToPool(bullet));
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if(context.started && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * fallspeed * gravity);
            sounds.Jump();
        }
    }

    private void Gravity()
    {
        grounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -6;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("bullet"))
        {
            currentHealth = currentHealth - damage;
            print(currentHealth);
            healthBar.fillAmount = currentHealth/healthMax;
            col.gameObject.SetActive(false);

            if(currentHealth <= 0)
                {
                    controller.enabled = false;
                    currentHealth = 0;
                    sounds.Die();
                    print("Players position as it hits 0 health: " + Player.transform.localPosition);
                    Player.transform.localPosition = spawn.transform.localPosition;
                    print("Players position after respawning: " + Player.transform.localPosition);
                    print(Player);
                    controller.enabled = true;
                    currentHealth = healthMax;
                    healthBar.fillAmount = currentHealth/healthMax;
                }
        }
        
    }

    IEnumerator ReturnBulletToPool(GameObject bullet)
    {
        yield return new WaitForSeconds(3);

        if(bullet != null)
        {
            bullet.SetActive(false);
        }
    }

    
}
