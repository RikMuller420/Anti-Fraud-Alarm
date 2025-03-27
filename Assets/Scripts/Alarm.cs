using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0f, 1f)] private float _maxVolume = 1f;
    [SerializeField, Min(0.1f)] private float _volumeChangeStep = 0.3f;

    private Coroutine _volumeChangeCoroutine;

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
            float volumeChangeStep = _volumeChangeStep * Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, tagetVolume, volumeChangeStep);

            yield return null;
        }

        if (tagetVolume == 0)
        {
            _audioSource.Stop();
        }
    }
}
