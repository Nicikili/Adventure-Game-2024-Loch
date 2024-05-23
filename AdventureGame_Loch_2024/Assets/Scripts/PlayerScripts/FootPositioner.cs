using UnityEngine;

public class FootPositioner : MonoBehaviour
{
    [Header("Detecting Balance")]
    public GameObject playerObj;
    public Transform target;
    public FootPositioner otherFoot;
    public bool isBalanced;

    [Header("Make a step forward")]
    public float lerp;
    private Vector3 startPos;
    private Vector3 endPos;
    public float overShootFactor = 0.5f;
    public float stepSpeed = 3f;
    public float footDisplacementOnX = 0.25f;

    [Header("Better Animation")]
    private Vector3 midPos;

    private bool isJumping = false;
    private Vector3 initialTargetOffset;

    private void Start()
    {
        startPos = midPos = endPos = target.position;
        initialTargetOffset = target.position - playerObj.transform.position;
    }

    private void Update()
    {
        UpdateBalance();
        UpdateJumpState();

        bool thisFootCanMove = otherFoot.lerp > 1 && lerp > otherFoot.lerp;

        if (!isBalanced && lerp > 1 && thisFootCanMove)
        {
            CalculateNewStep();
        }

        if (isJumping)
        {
            target.position = playerObj.transform.position + initialTargetOffset;
        }
        else
        {
            float easedLerp = EaseInOutCubic(lerp);
            target.position = Vector3.Lerp(
                Vector3.Lerp(startPos, midPos, easedLerp),
                Vector3.Lerp(midPos, endPos, easedLerp),
                easedLerp
            );
            lerp += Time.deltaTime * stepSpeed;
        }
    }

    private float EaseInOutCubic(float x)
    {
        return 1f / (1 + Mathf.Exp(-10 * (x - 0.5f)));
    }

    private void UpdateBalance()
    {
        float centerOfMass = playerObj.transform.position.x;
        isBalanced = IsFloatInRange(centerOfMass, target.position.x - footDisplacementOnX, otherFoot.target.position.x - otherFoot.footDisplacementOnX);
    }

    bool IsFloatInRange(float value, float bound1, float bound2)
    {
        float minValue = Mathf.Min(bound1, bound2);
        float maxValue = Mathf.Max(bound1, bound2);
        return value > minValue && value < maxValue;
    }

    private void CalculateNewStep()
    {
        startPos = target.position;
        lerp = 0;

        RaycastHit2D ray = Physics2D.Raycast(playerObj.transform.position + new Vector3(footDisplacementOnX, 0, 0), Vector2.down, 10);

        if (ray.collider != null)
        {
            Vector3 posDiff = ((Vector3)ray.point - target.position) * (1 + overShootFactor);
            endPos = target.position + posDiff;

            float stepSize = Vector3.Distance(startPos, endPos);
            midPos = startPos + posDiff / 2f + new Vector3(0, stepSize * 0.8f);
        }
    }

    private void UpdateJumpState()
    {
        // Detect if the player is jumping (this is a simplistic way, consider using your own jump detection logic)
        isJumping = !Physics2D.Raycast(playerObj.transform.position, Vector2.down, 0.1f);

        if (isJumping)
        {
            initialTargetOffset = target.position - playerObj.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(endPos, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(playerObj.transform.position, 0.5f);
    }
}