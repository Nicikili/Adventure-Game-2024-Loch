using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRandomToggle : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule _emission;
    [SerializeField] private Vector2 _minMaxWaitTimeOff = Vector2.one;
    [SerializeField] private Vector2 _minMaxWaitTimeOn = Vector2.one;


    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _emission = _particleSystem.emission;
        StartWait();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ToggleParticles()
    {
        _emission.enabled = !_emission.enabled;
        StartWait();

    }

    IEnumerator ToggleAfterSeconds(float waitTimeSeconds)
    {
        yield return new WaitForSeconds(waitTimeSeconds);
        ToggleParticles();
    }

    private void StartWait()
    {
        if (_emission.enabled)
        {
            StartCoroutine(ToggleAfterSeconds(Random.Range(_minMaxWaitTimeOn.x, _minMaxWaitTimeOn.y)));
        }
        else
        {
            StartCoroutine(ToggleAfterSeconds(Random.Range(_minMaxWaitTimeOff.x, _minMaxWaitTimeOff.y)));
        }
    }
}
