using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoBackButton : MonoBehaviour
{

	private Button backButton;
	public Animator animator;

	// Use this for initialization
	void Start()
	{
		backButton = GetComponent<Button>();
        backButton.onClick.AddListener(GoBackAnimation);
    }

	private void GoBackAnimation()
	{
		animator.SetTrigger("BACK_TO_START");
    }
}

