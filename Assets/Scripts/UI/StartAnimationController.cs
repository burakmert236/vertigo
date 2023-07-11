using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnimationController : MonoBehaviour
{

    private Button uiStartButton;
    public Animator startScreenAnimator;

    private void Start()
    {
        uiStartButton = GetComponent<Button>();
        uiStartButton.onClick.AddListener(HandleStartButtonClick);
    }

    private void OnDestroy()
    {
        uiStartButton.onClick.RemoveListener(HandleStartButtonClick);
    }

    private void HandleStartButtonClick()
    {
        startScreenAnimator.SetTrigger("START");
    }

}
