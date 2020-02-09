using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField]
    private GameObject StartScreenObj;
    [SerializeField]
    private GameObject UnlockScreenObj;
    [SerializeField]
    private GameObject Ship1B1;
    [SerializeField]
    private GameObject Ship1B2;
    [SerializeField]
    private GameObject Ship2B1;
    [SerializeField]
    private GameObject Ship2B2;
    [SerializeField]
    private GameObject Ship3B1;
    [SerializeField]
    private GameObject Ship3B2;
    [SerializeField]
    private Text MoneyHolder;

    [SerializeField]
    private SaveManager saveManager;

    private ShipData data;



    private void Start()
    {
        data = SaveManager.LoadPieces();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
        UnlockScreenObj.SetActive(false);
        StartScreenObj.SetActive(true);
        MoneyHolder.text = data.money.ToString();
        }

    }
    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UnlockScreen()
    {
        StartScreenObj.SetActive(false);
        UnlockScreenObj.SetActive(true);
        data = SaveManager.LoadPieces();
        MoneyHolder.text = data.money.ToString();
        UnlockButtons();
    }
    public void BackToStart()
    {
        UnlockScreenObj.SetActive(false);
        StartScreenObj.SetActive(true);
    }

    public void UnlockButtons()
    {
        data = SaveManager.LoadPieces();
        if (data.unlockShips[0])
        {
            Ship1B1.SetActive(false);
            Ship1B2.SetActive(true);
        }
        else
        {
            Ship1B1.SetActive(true);
            Ship1B2.SetActive(false);
        }
        if (data.unlockShips[1])
        {
            Ship2B1.SetActive(false);
            Ship2B2.SetActive(true);
        }
        else
        {
            Ship2B1.SetActive(true);
            Ship2B2.SetActive(false);
        }
        if (data.unlockShips[2])
        {
            Ship3B1.SetActive(false);
            Ship3B2.SetActive(true);
        }
        else
        {
            Ship3B1.SetActive(true);
            Ship3B2.SetActive(false);
        }
    }

    public void UnlockButton(int unlock)
    {
        saveManager.data.UnlockShip(unlock);
        SaveManager.SavePieces(saveManager.data.unlockShips, saveManager.data.money, saveManager.data.currentShip);
        data = SaveManager.LoadPieces();
        UnlockButtons();
        MoneyHolder.text = data.money.ToString();


    }

    public void SelectShip(int ship)
    {
        saveManager.data.SelectShip(ship);
        SaveManager.SavePieces(saveManager.data.unlockShips, saveManager.data.money, saveManager.data.currentShip);
        data = SaveManager.LoadPieces();

    }

}
