using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButtonCrl : MonoBehaviour
{
    public int index;
    public SkinShopUIManager skinShop;
    public void TaskOnClick()
    {
        skinShop.ChangePlayerShield(index);
    }
}
