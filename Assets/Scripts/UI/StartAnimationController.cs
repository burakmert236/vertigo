using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnimationController : MonoBehaviour
{

    private Button ui_start_button;
    public Animator start_screen_animator;

    private void Start()
    {
        ui_start_button = GetComponent<Button>();
        ui_start_button.onClick.AddListener(HandleStartButtonClick);
    }

    private void HandleStartButtonClick()
    {
        start_screen_animator.SetTrigger("START");
    }

}
