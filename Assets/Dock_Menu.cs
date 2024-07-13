using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dock_Menu : MonoBehaviour
{

    public int coins;
    public TextMeshProUGUI coinsText;

    public float energy;
    public TextMeshProUGUI energyText;


    public float health;
    public TextMeshProUGUI healthText;

    public float fireRate;
    public TextMeshProUGUI fireRateText;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
        SetDockValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(new PlayerData(coins, energy, health, fireRate));
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        coins = data.coins;
        energy = data.energy;
        health = data.health;
        fireRate = data.fireRate;
    }

    public void SetDockValues()
    {

        SetDockCoins();
        SetDockEnergy();
        SetDockHealth();
        SetDockFireRate();

    }

    public void SetDockCoins()
    {
        coinsText.text = coins.ToString();
    }
    public void SetDockEnergy()
    {
        energyText.text = energy.ToString();
    }
    public void SetDockHealth()
    {
        healthText.text = health.ToString();
    }
    public void SetDockFireRate()
    {
        fireRateText.text = fireRate.ToString();
    }

    public void IncreaseHealth()
    {

        int costToUpgrade = 10;
        if (coins >= costToUpgrade)
        {
            health = health + 10;
            coins = coins - costToUpgrade;
            SetDockHealth();
            SetDockCoins();
        }

       
    }

    public void IncreaseEnergy()
    {
        int costToUpgrade = 20;
        if (coins >= costToUpgrade)
        {

            energy = energy + 20;
            coins = coins - costToUpgrade;
            SetDockEnergy();
            SetDockCoins();
        }



    }

    public void IncreaseFireRate()
    {

        int costToUpgrade = 50;
        if (coins >= costToUpgrade)
        {
            fireRate = fireRate + 1;
            coins = coins - costToUpgrade;
            SetDockFireRate();
            SetDockCoins();
        }

        
    }
}
