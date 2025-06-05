using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCartAnimator : MonoBehaviour
{
    public bool isLoaded;
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    public PutWorkPieceConveyor PutWorkPieceConveyor;

    void Start()
    {
        animator = GetComponent<Animator>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Cart") && isLoaded == false)
                {
                    animator.ResetTrigger("CartLoaded");
                    animator.SetTrigger("CartLoaded");
                }
            }
        }
    }
    public void OnAroundAxisAnimationEnd()
    {
        PutWorkPieceConveyor.OnAroundAxisAnimationEnd();
    }
}
