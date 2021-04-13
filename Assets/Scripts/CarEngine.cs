using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
[RequireComponent(typeof(AudioSource))]

public class CarEngine : MonoBehaviour
{
    CarController car;
    AudioSource source;
    public float modifier;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<CarController>();    
        source = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(car.Speed);

        float soundPitchDiff = 1;

        if (car.Speed > 0.04f)
            soundPitchDiff = 1.5f;

        if (car.Speed > 0.055f)
            soundPitchDiff = 1.8f;

        if (car.Speed > 0.07f)
            soundPitchDiff = 2f;

        if (car.Speed > 0.08f)
            soundPitchDiff = 2.5f;

        source.pitch = (car.Speed * 35 / soundPitchDiff) * modifier + .6f;
    }
}
