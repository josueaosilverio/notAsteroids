using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShipData
{


    public bool[] unlockShips = new bool[3];
    public int money;
    public int currentShip;

    public ShipData(bool[] data, int money, int currentShip)
    {
        this.unlockShips = data;
        this.money = money;
        this.currentShip = currentShip;
    }



    public void UnlockShip(int piece)
    {
        switch (piece)
        {
            case 0:
                if (money > 10000)
                {
                    money -= 10000;
                    unlockShips[piece] = true;
                }
                break;
            case 1:
                if (money > 25000)
                {
                    money -= 25000;
                    unlockShips[piece] = true;
                }
                break;
            case 2:
                if (money > 100000)
                {
                    money -= 100000;
                    unlockShips[piece] = true;
                }
                break;
            default:
                break;
        }
    }

    public void LockShip(int piece)
    {
        unlockShips[piece] = false;
    } 
    
    
    public void SelectShip(int piece)
    {
        currentShip = piece;
    }

}
