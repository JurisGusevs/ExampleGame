using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private Transform ProjectileSpawnPoint;
    [SerializeField] private float destroyDelay = 5f;
    [SerializeField] private AudioSource hit;
    private float fireTime = 0f;

    private void Start()
    {
        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireTime)
        {
            fireTime += fireRate;
            GameObject projectileInstance = Instantiate(projectile, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
            projectileInstance.transform.localScale = transform.localScale;
            projectileInstance.transform.GetChild(0).transform.localScale = Vector3.one;
            projectileInstance.GetComponent<FireBallCollision>().hit = hit;

            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            rb.velocity = projectileInstance.transform.up * projectileSpeed;
            Destroy(projectileInstance, destroyDelay);
        }
    }
}
