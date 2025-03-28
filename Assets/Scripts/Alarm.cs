using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField, Range(0f, 1f)] private float _minVolume = 0f;
    [SerializeField, Range(0f, 1f)] private float _maxVolume = 1f;
    [SerializeField, Min(0.1f)] private float _volumeChangeSpeed = 0.3f;

    private Coroutine _volumeChangeCoroutine;

    private void OnValidate()
    {
        if (_minVolume > _maxVolume)
        {
            _minVolume = _maxVolume;
        }
    }

    private void OnEnable()
    {
        _alarmTrigger.FraudEnterTrigger += Activate;
        _alarmTrigger.FraudExitTrigger += Deactivate;
    }

    private void OnDisable()
    {
        _alarmTrigger.FraudEnterTrigger -= Activate;
        _alarmTrigger.FraudExitTrigger -= Deactivate;
    }

    public void Activate()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        StopVolumeChangeCourutine();
        _volumeChangeCoroutine = StartCoroutine(ChangeSoundVolume(_maxVolume));
    }

    public void Deactivate()
    {
        StopVolumeChangeCourutine();
        _volumeChangeCoroutine = StartCoroutine(ChangeSoundVolume(0f));
    }

    private void StopVolumeChangeCourutine()
    {
        if (_volumeChangeCoroutine != null)
        {
            StopCoroutine(_volumeChangeCoroutine);
        }
    }

    private IEnumerator ChangeSoundVolume(float tagetVolume)
    {
        while (_audioSource.volume != tagetVolume)
        {
            float volumeChangeStep = _volumeChangeSpeed * Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, tagetVolume, volumeChangeStep);

            yield return null;
        }

        if (tagetVolume == 0)
        {
            _audioSource.Stop();
        }
    }
}
