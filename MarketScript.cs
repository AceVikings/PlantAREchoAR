using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MarketScript : MonoBehaviour
{
    public Text CornNum;
    public Text WheatNum;
    public Text TotalNum;
    public Text Money;

    public static int MoneyInt = 500;
    public static int Corn = 0;
    public static int Wheat = 0;
    public static int Total = 0;

    public GameObject buyPanel;
    public GameObject transactionText;
    public void CornPlus()
    {
        Corn += 1;
        Total += 1;
        CornNum.text = Corn.ToString();
    }

    public void CornMinus()
    {
        if(Corn-1>=0)
        {
            Corn -= 1;
            Total -= 1;
        }
        CornNum.text = Corn.ToString();
    }

    public void WheatPlus()
    {
        Wheat += 1;
        Total += 1;
        WheatNum.text = Wheat.ToString();
    }

    public void WheatMinus()
    {
        if (Wheat-1>=0)
        {
            Wheat -= 1;
            Total -= 1;
        }
        
        WheatNum.text = Wheat.ToString();
    }
    
    private void Update()
    {
        TotalNum.text = Total.ToString();
    }

    public void Buy()
    {
        MoneyInt -= Total;
        Money.text = MoneyInt.ToString();
        Corn = 0;
        CornNum.text = Corn.ToString();
        Wheat = 0;
        WheatNum.text = Wheat.ToString();
        Total = 0;
        TotalNum.text = Total.ToString();
        buyPanel.SetActive(false);
        transactionText.SetActive(true);
        Invoke("DeactTText",3);
    }

    public void DeactTText()
    {
        transactionText.SetActive(false);
    }
}
