using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    int currentCoins = 0;

    private void Start(){UpdateCoins();}

    private void UpdateCoins() { scoreDisplay.text = currentCoins.ToString(); }

    public void AddCoins(int score) { currentCoins += score; UpdateCoins(); }

    public int GetCoins() { return currentCoins; }

    public bool CheckEnoughCoins(int amount) { return currentCoins >= amount; }

    public void DeductCoins(int amount) { currentCoins -= amount; }
}
