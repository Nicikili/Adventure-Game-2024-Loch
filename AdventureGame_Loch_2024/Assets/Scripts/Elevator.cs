using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private GameObject player;
    private bool playerOnPlatform = false;
    private bool isMoving = false;
    private Vector2 originalPosition;

    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        originalPosition = transform.parent.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform && !isMoving)
        {
            StartCoroutine(MoveElevatorRoutine());
        }
    }

    private IEnumerator MoveElevatorRoutine()
    {
        isMoving = true;
        yield return MoveToPosition(target.transform.position);
        yield return new WaitForSeconds(waitTime);
        yield return MoveToPosition(originalPosition);
        yield return new WaitForSeconds(waitTime);
        isMoving = false;
    }
    private IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while (Vector2.Distance(transform.parent.position, targetPosition) > 0.001f)
        {
            float step = speed * Time.deltaTime;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetPosition, step);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOnPlatform = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnPlatform = false;
    }
}
