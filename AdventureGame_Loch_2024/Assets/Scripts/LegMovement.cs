using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
	public Transform chainSolverTarget;
	public float moveDistance;
    public LayerMask groundLayer;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    //distance check between the body target and the chainsover target, if it is higher than the threshold the leg will move to a new position
    void Update()
    {
        CheckGround();

        if(Vector2.Distance(chainSolverTarget.position,transform.position) > moveDistance)
        {
            chainSolverTarget.position = transform.position;
        }
    }

    //raycast downward, snap body of the player to the ground
    public void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.down, 5, groundLayer);
        if (hit.collider != null)
        {
            Vector3 point = hit.point; //get the position where the leg hits something
            point.y += 0.1f;
            transform.position = point;
        }
    }
}
