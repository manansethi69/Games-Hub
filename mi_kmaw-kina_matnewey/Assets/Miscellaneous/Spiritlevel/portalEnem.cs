// Logic for creating an enemy that shoots projectiles. Enemy can be rotated
// in any direction by changing the Z rotation.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnem : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject bulletPrefab;
    public static float bulletSpeed = 5f;
    public static float spawnTime = 2f;
    float resetTime, checkTime;
    public bool onTime = true;
    public Sprite onTimeSprite;
    public Sprite offTimeSprite;


    void Start() {
        resetTime = spawnTime;
        if (onTime) { 
            GetComponent<SpriteRenderer>().sprite = onTimeSprite;
            checkTime = spawnTime;
        } else { 
            GetComponent<SpriteRenderer>().sprite = offTimeSprite; 
            checkTime = spawnTime * 1.5f;
        }
    }

    void Update() {
        if (checkTime > 0f) { checkTime -= Time.deltaTime; } 
        else { SpawnBullet(); }
    }

    void SpawnBullet() {
        GameObject bullet = Instantiate(bulletPrefab, spawnPos.position, spawnPos.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawnPos.up * bulletSpeed;
        checkTime = resetTime;
    }
}