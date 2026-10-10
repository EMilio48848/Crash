using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private Animator coinsAnimator;
    private int coins;
    public int Coins => coins;

    public void Initialize(int initialCoins = 0)
    {
        coins = initialCoins;
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "x" + coins.ToString();
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinsText();
        coinsAnimator.Play("Wiggle", 0, 0f);
    }
}
