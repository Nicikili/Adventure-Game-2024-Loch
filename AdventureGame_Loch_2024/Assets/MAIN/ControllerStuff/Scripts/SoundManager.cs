using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private FMOD.Studio.EventInstance AmbientSound;
	// Start is called before the first frame update
	void Start()
    {
		AmbientSound = FMODUnity.RuntimeManager.CreateInstance("event:/AmbientSounds/World/Overworld1");
		AmbientSound.start();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
