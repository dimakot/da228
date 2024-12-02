using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private void Update()
    {
        Move();
    }

    private void Move() {
        var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position, Time.deltaTime);
        transform.position = nextPosition;
    }
}
