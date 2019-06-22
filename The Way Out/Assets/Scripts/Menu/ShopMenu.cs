using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject life, boost, flash;
    private Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        if(menu.savedData._savedData.Life >= 3)
        {

        }

        if(menu.savedData._savedData.Level < 4)
        {

        }else if(menu.savedData._savedData.Level >= 4 && !menu.savedData._savedData.speedUp)
        {

        }
        else
        {

        }

        if (menu.savedData._savedData.Level < 7)
        {

        }
        else if (menu.savedData._savedData.Level >= 7 && !menu.savedData._savedData.flash)
        {

        }
        else
        {

        }
    }

    public void BuyItem(int item)
    {
        switch (item)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}
