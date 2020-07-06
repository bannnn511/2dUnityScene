using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharBehaviourScript : MonoBehaviour
{
	public float speed = 0.1f;
	public GameObject bossObject;
	public GameObject clawAttackObject;
	public GameObject bossDeathObject;
	public GameObject aflynObject;
	public GameObject aflynDeathObject;
	public GameObject hellFireObject;
	public GameObject haanitObject;
	Vector2 newPos;
	float movementObject = 2;
	Animator mainCharAnimator;
	Animator bossObjectAnimator;
	Animator bossDeathObjectAnimator;
	Animator clawAttackAnimator;
	Animator aflynAnimator;
	Animator haanitAnimator;
	float index = 0;
	float amplitudeX = 10.0f;
	float amplitudeY = 1.0f;
	float omegaX = 2.0f;
	float omegaY = 5.0f;
	// Start is called before the first frame update
	void Start()
	{
		mainCharAnimator = GetComponent<Animator>();
		bossDeathObject.SetActive(false);
		clawAttackAnimator = clawAttackObject.GetComponent<Animator>();
		clawAttackObject.SetActive(false);
		bossObjectAnimator = bossObject.GetComponent<Animator>();
		aflynAnimator = aflynObject.GetComponent<Animator>();
		aflynDeathObject.SetActive(false);
		bossDeathObjectAnimator = bossDeathObject.GetComponent<Animator>();
		hellFireObject.SetActive(false);
		haanitAnimator = haanitObject.GetComponent<Animator>();
		hellFireObject.GetComponent<Animator>().speed = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{

		if (bossObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName("bossAttackState"))
		{
			clawAttackObject.SetActive(true);
			clawAttackAnimator.SetTrigger("readyToAttackTrigger");
		}

		if (clawAttackAnimator.GetCurrentAnimatorStateInfo(0).IsName("clawAttackAnimation"))
		{
			aflynAnimator.SetTrigger("aflynDeathStateTrigger");
			bossObjectAnimator.SetTrigger("bossAttackTrigger");
		}

		if (aflynAnimator.GetCurrentAnimatorStateInfo(0).IsName("AflynDyingState") || aflynAnimator.GetCurrentAnimatorStateInfo(0).IsName("AflynDeathState"))
		{
			clawAttackObject.SetActive(false);
			aflynDeathObject.SetActive(true);
			aflynObject.SetActive(false);
		}

		if (bossObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName("bossAtackDoneState"))
		{
			haanitAnimator.SetTrigger("HaanitAttackTrigger");
			mainCharAnimator.SetBool("fightBool", true);
		}

		if (haanitAnimator.GetCurrentAnimatorStateInfo(0).IsName("HaanitAnimationState"))
		{
			hellFireObject.SetActive(true);
			index += Time.deltaTime;
			float x = amplitudeX * Mathf.Cos(omegaX * index) - hellFireObject.transform.position.x;
			float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
			hellFireObject.transform.localPosition = new Vector3(x, y, 0);
		}

		if (mainCharAnimator.GetCurrentAnimatorStateInfo(0).IsName("mainCharIdleState"))
		{
			hellFireObject.SetActive(false);
			bossObject.SetActive(false);
			bossDeathObject.SetActive(true);
			bossDeathObject.GetComponent<Animator>().SetTrigger("bossDeathTrigger");
		}

		if (bossDeathObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName("bossDeathState"))
		{
			bossDeathObject.SetActive(false);
		}
	}
}


