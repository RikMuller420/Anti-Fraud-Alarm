using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            _alarm.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            _alarm.Deactivate();
        }
    }
}
