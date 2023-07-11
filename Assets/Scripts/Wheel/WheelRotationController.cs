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

    // Start is called before the first frame update
    void Start()
    {
        spin_button.onClick.AddListener(StartAndStopRotationCoroutineStarter);
    }

    private void StartAndStopRotationCoroutineStarter()
    {
        StartCoroutine(StartAndStopRotation());
    }

    private IEnumerator StartAndStopRotation()
    {
        backButton.interactable = false;
        spin_button.interactable = false;

        float randomAngle = Random.Range(_rotationSettings.randomRotationMinAngle, _rotationSettings.randomRotationMaxAngle);

        _audioSource.Play();

        // Start the wheel rotation
        Tween rotateTween = wheel.DORotate(new Vector3(0f, 0f, randomAngle), _rotationSettings.wheelRotationDuration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuad);

        // Wait for the duration before stopping the wheel
        yield return new WaitForSeconds(_rotationSettings.wheelRotationDuration + _rotationSettings.wheelRotationDelayOffset);

        _audioSource.Stop();

        // Ensure the rotation tween is completed (the wheel has finished rotating)
        // Get the current Euler angle of the wheel around the Y axis
        float currentAngle = wheel.rotation.eulerAngles.z;

        float roundedCurrentAngle = Mathf.Round(currentAngle / 45f);

        // Round the current angle to the nearest multiple of 45 degrees
        float roundedAngle = roundedCurrentAngle * 45f;

        // Rotate the wheel to the rounded angle
        wheel.DORotate(new Vector3(0f, 0f, roundedAngle), 1f).SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(1f);

        WheelController parentWheelComponentScript = parentWheelComponent.GetComponent<WheelController>();

        parentWheelComponentScript.HandleRotationEnd(roundedCurrentAngle);
    }
}
