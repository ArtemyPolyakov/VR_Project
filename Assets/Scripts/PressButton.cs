using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public bool isPressed = false;
    public Animator ButtonAnimator;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Button") && hit.collider.gameObject == this.gameObject)
                {
                    if (isPressed)
                    {
                        isPressed = false;
                        ButtonAnimator.SetBool("isPressed", isPressed);
                    }
                    else
                    {
                        isPressed = true;
                        ButtonAnimator.SetBool("isPressed", isPressed);
                    }
                }
            }
        }
    }
}
