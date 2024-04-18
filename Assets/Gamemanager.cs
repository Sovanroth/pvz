using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public GameObject currentPlant;
    public Sprite curentPlantSprite;
    public Transform tiles;
    public LayerMask tileMask;
    public int suns;
    public TextMeshProUGUI sunText;
    public LayerMask sunMask;

    public void BuyPlant(GameObject plant, Sprite sprite)
    {
        currentPlant = plant;
        curentPlantSprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = curentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(currentPlant, hit.collider.transform.position, Quaternion.identity);
                currentPlant = null;
            }
        }

        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);
        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                suns += 50;
                Destroy(sunHit.collider.gameObject);
            }
        }
    }
}
