using System.Collections;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    public Light lightningLight;
    public AudioSource thunderSound;
    public float minTimeBetweenLightning = 10f;
    public float maxTimeBetweenLightning = 30f;
    public float lightningDuration = 0.2f; // Duration of the lightning flash

    private void Start()
    {
        if (lightningLight == null)
        {
            Debug.LogError("Lightning light not assigned.");
            return;
        }

        if (thunderSound == null)
        {
            Debug.LogError("Thunder sound not assigned.");
            return;
        }

        lightningLight.enabled = false;
        StartCoroutine(ControlLightning());
    }

    private IEnumerator ControlLightning()
    {
        while (true)
        {
            // Wait for a random time before starting the next lightning
            float timeToWait = Random.Range(minTimeBetweenLightning, maxTimeBetweenLightning);
            yield return new WaitForSeconds(timeToWait);

            // Flash the lightning
            lightningLight.enabled = true;
            yield return new WaitForSeconds(lightningDuration);
            lightningLight.enabled = false;

            // Play thunder sound with a delay to simulate distance
            float thunderDelay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(thunderDelay);
            thunderSound.Play();
        }
    }
}