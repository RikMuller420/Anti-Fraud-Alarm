using UnityEngine;

public class FraudMover : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _speed = 5f;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
