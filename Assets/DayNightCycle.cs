using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;
    public float dayDuration = 60f; // Duration of one day in seconds

    private float timeOfDay = 0f;

    void Update()
    {
        // Increment time of day
        timeOfDay += Time.deltaTime / dayDuration;

        // Calculate the angle of the sun
        float sunAngle = timeOfDay * 360f;

        // Rotate the directional light to simulate the sun
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0));

        // Reset time of day if it exceeds 1 (i.e., one full cycle)
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }
    }
}