using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Touch touch;
    Animator animator;
    [SerializeField] GameManager gameManager;
    [SerializeField] StaminaManager staminaManager;
    [SerializeField] LevelManager levelManager;
    [SerializeField] SweatManager sweatManager;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    void Push()
    {
        if(Input.touchCount>0 && gameManager.canPush)
        {     
            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                animator.SetBool("IsTouch",true);
            }
        }
    }

    void GainProgress()
    {
        staminaManager.StaminaCost();
        levelManager.GainExp();
        sweatManager.GainSweat();
    }
    void StopPush()
    {
        animator.SetBool("IsTouch",false);
    }


}
