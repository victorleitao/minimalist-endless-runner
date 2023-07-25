using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinsPickedText;

    void FixedUpdate()
    {
        coinsPickedText.text = PlayerController.Instance.coinCounter.ToString();
    }
}
