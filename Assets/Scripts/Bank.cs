using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI goldText;

    int currentBalance;
    public int CurrentBalance { get => currentBalance; }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateBalanceUI();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceUI();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalanceUI();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    private void UpdateBalanceUI()
    {
        goldText.text = $"Gold = {currentBalance}";
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
