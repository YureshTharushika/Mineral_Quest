using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsText;

    public float energy;
    public TextMeshProUGUI energyText;
    public float energyDecreaseAmountPerTime;

    public float health;
    public TextMeshProUGUI healthText;

    public float fireRate;

    public GameObject gameOverScreen;

    public static Logic Instance;

    private bool isGameOn = true;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadPlayerData();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //energy = 100;
        //health = 100;

        
        energyText.text = energy.ToString("F2");
        healthText.text = health.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOn)
        {
            DecreaseEnergy();
        }
    }


    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(new PlayerData(this));
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        coins = data.coins;
        energy = data.energy;
        health = data.health;
        fireRate = data.fireRate;
    }

    public bool IsGameOn()
    {
        return isGameOn;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        isGameOn = false;
        SaveSystem.UpdateCoins(coins);
        gameOverScreen.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coins = coins + coinsToAdd;
        coinsText.text = coins.ToString();
    }

    public void AddEnergy(float energyToAdd)
    {
        energy = energy + energyToAdd;
        energyText.text = energy.ToString("F2");
    }

    public void DecreaseEnergy()
    {
        energy = energy - energyDecreaseAmountPerTime * Time.deltaTime;
        energyText.text = energy.ToString("F2");

        if(energy <= 0)
        {
            energyText.text = "0";
            GameOver();
        }
    }

    public void DecreaseHealth(float healthToReduce)
    {
        health = health - healthToReduce;
        healthText.text = health.ToString("F2");

        if (health <= 0)
        {
            healthText.text = "0";
            GameOver();
        }
    }

    public void IncreaseFireRate(float fireRateToAdd)
    {
        fireRate = fireRate + fireRateToAdd;
    }

}
