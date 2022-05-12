using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_to_Elve : MonoBehaviour
{
    GameObject Elve;

    Animator animator;
    Animator Elve_animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Elve = GameObject.Find("My_elve");
        Elve_animator = Elve.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckElve())
        {
            animator.SetTrigger("Walk_elve");
            this.transform.parent = Elve.transform;

            Elve_animator.SetTrigger("8 close");
            Elve_animator.SetTrigger("8-9");
            Elve_animator.SetTrigger("9 open");
        }
    }

    private bool CheckElve()
    {
        return Elve_animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.8 open") &&

            Elve_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;

    }
}
