using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0F;
    public float rotateSpeed = 20.0F;
    private int ANIMATION_IDLE = 0;
    private int ANIMATION_RUN = 1;
    private int ANIMATION_UNARMED_LEFT_ATTACK = 2;
    private int ANIMATION_UNARMED_RIGHT_ATTACK = 3;
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        // use GetAxisRaw to avoid redundant animation after key is up
        float rawVertical = Input.GetAxisRaw("Vertical");
        float rawHorizontal = Input.GetAxisRaw("Horizontal");

        AnimatorStateInfo currentAnimator = animator.GetCurrentAnimatorStateInfo(0);
        bool isAttackClipPlaying = (currentAnimator.IsName("Unarmed-Attack-Left") || 
                                    currentAnimator.IsName("Unarmed-Attack-Right")) &&
                                    currentAnimator.normalizedTime <= 1;
        if (isAttackClipPlaying)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            int randomAttack = Random.Range(ANIMATION_UNARMED_LEFT_ATTACK, ANIMATION_UNARMED_RIGHT_ATTACK + 1);
            animator.SetInteger("state", randomAttack);
        } else if (rawVertical != 0 || rawHorizontal != 0)
        {
            // if the key was pressed, rotate and translate
            Vector3 rotateDirection = new Vector3(rawHorizontal, 0, rawVertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateDirection), rotateSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            // set the running animation
            animator.SetInteger("state", ANIMATION_RUN);
        } else
        {
            //  set the idle animation
            animator.SetInteger("state", ANIMATION_IDLE);
        }
    }

    private void Hit()
    {
        print("u hit something");
    }
}
