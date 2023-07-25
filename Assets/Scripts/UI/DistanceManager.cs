using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public Text traveledDistanceText;
    public Transform player;
    private float traveledDistance;

    void FixedUpdate()
    {
        traveledDistance = player.position.z + 7.75f;
        if (traveledDistance < 1000)
        {
            traveledDistanceText.text = Mathf.Round(traveledDistance) + "m";
        }
        else
        {
            traveledDistanceText.text = string.Format("{0:.00}", traveledDistance * 0.001f) + "km";
        }
    }
}
