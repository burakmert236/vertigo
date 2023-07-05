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
        backButton.onClick.AddListener(goBackAnimation);
    }

	private void goBackAnimation()
	{
		animator.SetTrigger("BACK_TO_START");
    }
}

