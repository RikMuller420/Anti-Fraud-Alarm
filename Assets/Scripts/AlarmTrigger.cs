using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action FraudEntered;
    public event Action FraudLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            FraudEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            FraudLeft?.Invoke();
        }
    }
}
