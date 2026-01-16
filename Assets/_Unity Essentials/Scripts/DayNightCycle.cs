using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Number of real-time seconds for a full day cycle
    public float dayLengthInSeconds = 120f;

    void Update()
    {
        // Calculate rotation speed (360 degrees per day)
        float rotationSpeed = 360f / dayLengthInSeconds;

        // Rotate the light over time
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
