using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

    public int requiredCoins = 10; // How many they need
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI requirementText; // Optional UI telling player goal

    public AudioSource sfxSource;      // For sound effects
    public AudioClip coinSFX;          // Coin sound


    private void Start()
    {
        if (requirementText != null)
            requirementText.text = "Collect " + requiredCoins + " coins!";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin++;
            coinText.text = "Coins: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);

            // Play coin SFX
            if (sfxSource != null && coinSFX != null)
                sfxSource.PlayOneShot(coinSFX);

            if (Coin >= requiredCoins && requirementText != null)
            {
                requirementText.text = "Go to the stairs!";
            }
        }
    }

    public bool HasEnoughCoins()
    {
        return Coin >= requiredCoins;
    }
}
