using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager2 : MonoBehaviour
{
    bool toggleStat = true;
   public Animator animator;
    [SerializeField] string startAnimTrigger="StartAnim", stopAnimTrigger = "StopAnim";
    [SerializeField] 
    // Start is called before the first frame update
    
        public void ToggleAnim()
    {
        toggleStat = !toggleStat;
        CheckAnimStat();
        if(toggleStat)
            animator.SetTrigger(stopAnimTrigger);
        else
            animator.SetTrigger(startAnimTrigger);

    }
    public void StartAnim()
    {

        CheckAnimStat();
        toggleStat = true;
        animator.SetTrigger(startAnimTrigger);
    }
    public void StopAnim()
    {
        CheckAnimStat();
        toggleStat = false;
        animator.SetTrigger(stopAnimTrigger);
    }

    void CheckAnimStat() { if (!animator)  animator = GetComponent<Animator>();
        if (!animator.enabled)
            animator.enabled = true;
    }
}
