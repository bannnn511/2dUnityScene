using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharBehaviourScript : MonoBehaviour
{
	public float speed = 0.1f;
	public GameObject bossObject;
	public GameObject clawAttack;
	public GameObject bossDeath;
	public GameObject aflyn;
	Vector2 newPos;
	Animator animator;
	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		bossDeath.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

		if (bossObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleState"))
		{
			animator.SetBool("fightBool", true);
		}

		if (animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("mainCharIdleState"))
		{
			bossObject.SetActive(false);
			bossDeath.SetActive(true);
			bossDeath.GetComponent<Animator>().SetTrigger("bossDeathTrigger");
		}
	}
}
