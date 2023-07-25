using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour
{
    public Text speedText;
    private float speed;


    void FixedUpdate()
    {
        speed = (PlayerController.Instance.forwardMovement) / 1000;
        speedText.text = Mathf.Round(speed) + "Km/h";
    }
}
