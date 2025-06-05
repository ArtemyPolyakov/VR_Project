using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public WorkPieceInConveyor WorkPieceInConveyor;
    public DoorsAnimation DoorsAnimation;

    public Material[] WorckPiecesMaterials;

    public Animator RedButtonAnimator, GreenButtonAnimator, BlueButtonAnimator;
    void OnTriggerEnter(Collider other)
    {
        WorkPieceInConveyor.isPainting[WorkPieceInConveyor.WorkPieces.IndexOf(other.gameObject)] = true;
        DoorsAnimation.isWorkPieceInside = true;
        bool isRedColor = RedButtonAnimator.GetBool("isPressed");
        bool isGreenColor = GreenButtonAnimator.GetBool("isPressed");
        bool isBlueColor = BlueButtonAnimator.GetBool("isPressed");

        if (isRedColor == true && isGreenColor == false && isBlueColor == false)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[0];
        }
        else if (isRedColor == false && isGreenColor == true && isBlueColor == false)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[1];
        }
        else if (isRedColor == false && isGreenColor == false && isBlueColor == true)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[2];
        }
        else if (isRedColor == true && isGreenColor == true && isBlueColor == false)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[3];
        }
        else if (isRedColor == true && isGreenColor == false && isBlueColor == true)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[4];
        }
        else if (isRedColor == false && isGreenColor == true && isBlueColor == true)
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[5];
        }
        else
        {
            other.GetComponent<Renderer>().material = WorckPiecesMaterials[6];
        }
    }

    private void Update()
    {
        for (int i = 0; i < WorkPieceInConveyor.WorkPieces.Count; i++)
        {
            if (WorkPieceInConveyor.isPainting[i] == true && DoorsAnimation.isWorkPieceInside == false)
            {
                WorkPieceInConveyor.isPainting[i] = false;
            }
        }
    }

}
