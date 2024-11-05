using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[4,4];
    public float scrap;
    public TMP_Text ScrapTXT;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;



    void Start()
    {
        ScrapTXT.text = "Scrap:" + scrap;

        //Shop Item ID's
        shopItems[1, 0] = 1;
        shopItems[1, 1] = 2;
        shopItems[1, 2] = 3;

        //Price of items in shop
        shopItems[2, 0] = 10;
        shopItems[2, 1] = 20;
        shopItems[2, 2] = 30;

        //Quantity of Items Bought
        shopItems[3, 0] = 0;
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
    }

    void Update()
    {
        if(shopItems[3, 0] == 1)
        {
            //stop buying after player purchases one of this category per floor
            buttonOne.enabled = false;
        }
        if (shopItems[3, 1] == 1)
        {
            //stop buying after player purchases one of this category per floor
            buttonTwo.enabled = false;
        }
        if (shopItems[3, 2] == 1)
        {
            //stop buying after player purchases one of this category per floor
            buttonThree.enabled = false;
        }
    }

    public void Purchase()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (scrap >= shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID])
        {
            scrap -= shopItems[2, ButtonRef.GetComponent<buttoninfo>().ItemID];

            //Updating Text every time item is purchased

            shopItems[3, ButtonRef.GetComponent<buttoninfo>().ItemID]++;
            ScrapTXT.text = "Scrap Amount:" + scrap;
            ButtonRef.GetComponent<buttoninfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<buttoninfo>().ItemID].ToString();




        }
    }
}
