using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeElapsedText;
    private float timer = 0.0f;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        timeElapsedText.text = Mathf.Round(timer).ToString();
    }
}
