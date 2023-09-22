using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    
    public AudioSource src;
    public AudioClip jump, shoot, die, score;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        src.PlayOneShot(shoot, 1);
    }

    public void Jump()
    {
        src.PlayOneShot(jump, 1);
    }

    public void Die()
    {
        src.PlayOneShot(die, 1);
    }

    public void Score()
    {
        src.PlayOneShot(score, 1);
    }
}
