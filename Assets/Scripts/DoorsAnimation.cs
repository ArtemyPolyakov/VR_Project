using UnityEngine;
public class DoorsAnimation : MonoBehaviour
{
    public Transform[] doors = new Transform[2];
    public bool isWorkPieceInside;

    private enum DoorState { Idle, Closing, Closed, Opening }
    private DoorState currentState = DoorState.Idle;

    private float closedY = 9.06f;
    private float openY = 10.726f;
    private float speed = 2f;
    private float timer = 0f;

    void Update()
    {
        switch (currentState)
        {
            case DoorState.Idle:
                if (isWorkPieceInside)
                {
                    currentState = DoorState.Closing;
                }
                break;

            case DoorState.Closing:
                if (MoveDoorsY(closedY))
                {
                    currentState = DoorState.Closed;
                    timer = 0f;
                }
                break;

            case DoorState.Closed:
                timer += Time.deltaTime;
                if (timer >= 5f)
                {
                    currentState = DoorState.Opening;
                }
                break;

            case DoorState.Opening:
                if (MoveDoorsY(openY))
                {
                    currentState = DoorState.Idle;
                    isWorkPieceInside = false;
                }
                break;
        }
    }

    private bool MoveDoorsY(float targetY)
    {
        bool allAtTarget = true;

        foreach (Transform door in doors)
        {
            if (Mathf.Abs(door.localPosition.y - targetY) > 0.01f)
            {
                door.localPosition = Vector3.MoveTowards(
                    door.localPosition,
                    new Vector3(door.localPosition.x, targetY, door.localPosition.z),
                    speed * Time.deltaTime
                );
                allAtTarget = false;
            }
        }

        return allAtTarget;
    }
}
