using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    public Transform teleportLocation; // Drag a Transform into this slot

    public AudioSource sfxSource;
    public AudioClip teleportSFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollection coins = other.GetComponent<CoinCollection>();

            if (coins != null && coins.HasEnoughCoins())
            {

                if (sfxSource != null && teleportSFX != null)
                    sfxSource.PlayOneShot(teleportSFX);

                // Teleport the player
                other.transform.position = teleportLocation.position;
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
    }
}
