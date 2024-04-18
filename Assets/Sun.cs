using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float dropToField;
    private float speed = .15f;

    private void Start()
    {
        // transform.position = new Vector3(Random.Range(-4f, 8f), 6, 0);
        // dropToField = Random.Range(2f, -3f);
        Destroy(gameObject, Random.Range(6f, 12f));
    }

    private void Update()
    {
        if (transform.position.y > dropToField)
        {

            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }
    }
}
