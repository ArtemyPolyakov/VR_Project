using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPiecesInCart : MonoBehaviour
{
    public List<GameObject> WorkPieces { get; private set; } = new List<GameObject>();


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo") && !WorkPieces.Contains(other.gameObject))
        {
            WorkPieces.Add(other.gameObject);
            other.transform.SetParent(transform);
            Debug.Log($"{other.name} загружен в тележку.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (WorkPieces.Contains(other.gameObject))
        {
            WorkPieces.Remove(other.gameObject);
            Debug.Log($"{other.name} выгружен из тележки.");
        }
    }
}
