using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PutWorkPieceConveyor : MonoBehaviour
{
    public Animator CartAnimation;
    public WorkPiecesInCart WorkPiecesInCart;
    public Transform gripper;
    private Animator ArmRobotAnimator;
    private List<GameObject> WorkPieces;
    private List<GameObject> WorkPiecesConveyor  = new List<GameObject>();
    void Start()
    {
        ArmRobotAnimator = GetComponent<Animator>();
        WorkPieces = WorkPiecesInCart.WorkPieces;
    }
    public void PutWorkPiece()
    {
        GameObject WorkPiece = WorkPieces.Last();
        WorkPiecesConveyor.Add(WorkPiece);
        WorkPieces.Remove(WorkPiece);
        WorkPiece.transform.position = new Vector3(-5.069f, 1.405f, -2.252f);
        WorkPiece.transform.rotation = Quaternion.Euler(-181.714f, 0, 0);
        WorkPiece.transform.SetParent(gripper);
        if (WorkPieces.Count == 0)
        {
            ArmRobotAnimator.SetBool("CartEmpty", true);
            CartAnimation.ResetTrigger("CartEmpty");
            CartAnimation.SetTrigger("CartEmpty");
        }
    }

    public void DropWorkPiece()
    {
        GameObject WorkPiece = WorkPiecesConveyor.Last();
        WorkPiecesConveyor.Remove(WorkPiece);
        WorkPiece.transform.SetParent(null);
    }
    public void OnAroundAxisAnimationEnd()
    {
        ArmRobotAnimator.ResetTrigger("CartHere");
        ArmRobotAnimator.SetTrigger("CartHere");
        ArmRobotAnimator.SetBool("CartEmpty", false);
    }
}
