using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Text HPText;

    void FixedUpdate()
    {
        HPText.text = "HP: " + PlayerController.Instance.healthPoints;
    }
}
