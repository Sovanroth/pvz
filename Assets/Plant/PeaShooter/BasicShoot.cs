using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;
    public float cd;
    private bool canShoot;
    public float range;
    public LayerMask shootMask;
    private GameObject target;

    private void Start()
    {
        Invoke("ResetCD", cd);
    }


    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);

        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Shoot();
        }

    }


    void ResetCD()
    {
        canShoot = true;
    }

    void Shoot()
    {
        if (!canShoot)
            return;
        canShoot = false;
        Invoke("ResetCD", cd);

        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);

    }

}