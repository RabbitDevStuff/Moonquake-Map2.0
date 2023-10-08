using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;

    private Transform cameraTransform;
    private Vector3 originalPosition;

    private void Start()
    {
        cameraTransform = transform;
        originalPosition = cameraTransform.localPosition;
    }

    public void GoTOMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            cameraTransform.localPosition = originalPosition + shakeOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPosition; // Reset to the original position
    }
}
