using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantSlot : MonoBehaviour
{
    public Sprite plantSprite;
    public GameObject plantObject;
    public Image icon;
    public int price;
    public TextMeshProUGUI priceText;
    private Gamemanager gameMangerSlot;

    public void Start()
    {
        gameMangerSlot = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }


    private void BuyPlant()
    {
        if (gameMangerSlot.suns >= price)
        {
            gameMangerSlot.suns -= price;
            gameMangerSlot.BuyPlant(plantObject, plantSprite);
        }
    }

    private void OnValidate()
    {
        if (icon == null)
        {
            icon = GetComponent<Image>();
            if (icon == null)
            {
                Debug.LogError("PlantSlot: Icon is not assigned.");
                return;
            }
        }

        if (priceText == null)
        {
            priceText = GetComponentInChildren<TextMeshProUGUI>();
            if (priceText == null)
            {
                Debug.LogError("PlantSlot: PriceText is not assigned.");
                return;
            }
        }

        if (plantSprite)
        {
            icon.enabled = true;
            icon.sprite = plantSprite;
            priceText.text = price.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }
}

