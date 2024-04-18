using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dps;
    public float speed = 2f;
    public bool freeze;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        Debug.Log("Bullet Update");
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            zombie.Hit(dps, freeze);
            Destroy(gameObject);
        }
    }
}
