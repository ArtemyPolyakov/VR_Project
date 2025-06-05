using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkPieceInConveyor : MonoBehaviour
{
    public List<GameObject> WorkPieces { get; private set; } = new List<GameObject>();
    public List<bool> isPainting = new List<bool>();
    void OnCollisionEnter(Collision other)
    {
        isPainting.Add(false);
        WorkPieces.Add(other.gameObject);
    }
    void OnCollisionExit(Collision other)
    {
        if (WorkPieces.Contains(other.gameObject))
        {
            isPainting.RemoveAt(WorkPieces.IndexOf(other.gameObject));
            WorkPieces.Remove(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < WorkPieces.Count; i++)
        {
            if (!isPainting[i])
            {
                Rigidbody rb = WorkPieces[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 newPos = rb.position + Vector3.back * Time.fixedDeltaTime;
                    rb.MovePosition(newPos);
                }
            }
        }
    }
}
