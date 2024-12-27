using UnityEngine;
using UnityEngine.Events;

public class MazeEndPoint : MonoBehaviour
{
    public UnityEvent BallReachedEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BallReachedEnd.Invoke();
        }
    }
}
