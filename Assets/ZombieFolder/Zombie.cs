using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float speed;
    private int health;
    private int damage;
    private float range;
    public LayerMask plantMask;
    private float eatCD;
    private bool canEat = true;
    public Plant targetPlant;
    public ZombieType type;


    private void Start()
    {
        health = type.health;
        speed = type.speed;
        damage = type.damage;
        range = type.range;
        eatCD = type.eatCD;

        GetComponent<SpriteRenderer>().sprite = type.sprite;
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider != null)
        {
            Debug.Log("Plant detected!");
            targetPlant = hit.collider.GetComponent<Plant>();
            Eat();
        }

        // if (health == 1)
        //     GetComponent<SpriteRenderer>().sprite = type.death;
    }


    void Eat()
    {
        if (!canEat || targetPlant == null)
        {
            Debug.Log("Cannot eat");
            return;
        }

        Debug.Log("Eating plant");
        canEat = false;
        Invoke("ResetEatCD", eatCD);

        targetPlant.Hit(damage);
    }

    void reasetEarCD()
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        if (!targetPlant)
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage, bool freeze)
    {
        health -= damage;

        if (freeze)
        {
            Freeze();
        }

        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = type.death;
            Destroy(gameObject, 1);
        }
    }


    void Freeze()
    {
        CancelInvoke("unFreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        speed = type.speed / 2;
        Invoke("unFreeze", 5);
    }

    void unFreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        speed = type.speed;
    }
}
