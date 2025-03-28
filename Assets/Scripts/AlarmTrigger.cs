using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action FraudEnterTrigger;
    public event Action FraudExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            FraudEnterTrigger?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Fraud>(out _))
        {
            FraudExitTrigger?.Invoke();
        }
    }
}
