using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Wheel;

public class WheelRotationController : MonoBehaviour
{
    public WheelRotationSettings _rotationSettings;

    public Transform wheel; // The wheel you want to rotate
    public Transform parentWheelComponent;

    public Button spin_button;
    public Button backButton;

    public AudioSource _audioSource;

    private bool isWheelRotating;
    private float singleSlotAngle;
    private const float wholeWheelAngle = 360f;

    // Start is called before the first frame update
    void Start()
    {
        isWheelRotating = false;
        singleSlotAngle = wholeWheelAngle / _rotationSettings.wheelSlotNumber;
        spin_button.onClick.AddListener(StartAndStopRotationCoroutineStarter);
    }

    private void OnDestroy()
    {
        // Remove the listener in OnDestroy()
        spin_button.onClick.RemoveListener(StartAndStopRotationCoroutineStarter);
    }

    private void StartAndStopRotationCoroutineStarter()
    {
        if(!isWheelRotating) {
            isWheelRotating = true;
            StartCoroutine(StartAndStopRotation());
        }
    }

    private IEnumerator StartAndStopRotation()
    {
        while(isWheelRotating) {
            backButton.interactable = false;
            spin_button.interactable = false;

            float randomAngle = Random.Range(_rotationSettings.randomRotationMinAngle, _rotationSettings.randomRotationMaxAngle);

            _audioSource.Play();

            // Start the wheel rotation
            wheel
                .DORotate(new Vector3(0f, 0f, randomAngle), _rotationSettings.wheelRotationDuration, RotateMode.FastBeyond360)
                .SetEase(_rotationSettings.rotationEaseType);

            // Wait for the duration before stopping the wheel
            yield return new WaitForSeconds(_rotationSettings.wheelRotationDuration + _rotationSettings.wheelRotationDelayOffset);

            _audioSource.Stop();

            // Ensure the rotation tween is completed (the wheel has finished rotating)
            // Get the current Euler angle of the wheel around the Y axis
            float currentAngle = wheel.rotation.eulerAngles.z;

            float roundedCurrentAngle = Mathf.Round(currentAngle / singleSlotAngle);

            // Round the current angle to the nearest multiple of singleSlotAngle degrees
            float roundedAngle = roundedCurrentAngle * singleSlotAngle;

            // Rotate the wheel to the rounded angle
            wheel
                .DORotate(new Vector3(0f, 0f, roundedAngle), 1f)
                .SetEase(_rotationSettings.roundingRotationEaseType);

            yield return new WaitForSeconds(_rotationSettings.wheelRoundingRotationDuration);

            WheelController parentWheelComponentScript = parentWheelComponent.GetComponent<WheelController>();

            parentWheelComponentScript.HandleRotationEnd(roundedCurrentAngle);

            isWheelRotating = false;
        }
    }
}
