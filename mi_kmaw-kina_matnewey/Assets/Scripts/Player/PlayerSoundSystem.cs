using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSystem : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource jump;
    public AudioSource damage;
    public AudioSource crouch;
    public AudioSource coin;
    public AudioSource hint;
    public AudioSource killEnemy;

    public void Walk()
    {
        walk.Play();
    }
    public void stopWalk()
    {
        walk.Stop();
    }

    public void Jump()
    {
       jump.Play();
    }

    public void Damage()
    {
        damage.Play();
    }

    public void Crouch()
    {
        walk.Stop();
        crouch.Play();
    }
    public void stopCrouch()
    {
        crouch.Stop();
    }

    public void Hint()
    {
        hint.Play();
    }

    public void Coin()
    {
        coin.Play();
    }

    public void KillEnemy()
    {
        killEnemy.Play();
    }
}
