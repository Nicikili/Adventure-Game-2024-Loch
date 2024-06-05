using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility_toggle : MonoBehaviour
{

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVisibillity ()
    {
        _renderer.enabled = !_renderer.enabled;
        Debug.Log("aweawe");
    }
}
