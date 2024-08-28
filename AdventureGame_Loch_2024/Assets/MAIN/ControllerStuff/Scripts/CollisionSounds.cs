using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSounds : MonoBehaviour
{
	private FMOD.Studio.EventInstance BucketCollision;
	public string ObjectPlayerCollidesWith;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		ObjectPlayerCollidesWith = other.tag;
		if (ObjectPlayerCollidesWith == "Elevator")
		{
			BucketCollision = FMODUnity.RuntimeManager.CreateInstance("event:/Collisions/BucketCollision");
			BucketCollision.start();
		}
	}
}
