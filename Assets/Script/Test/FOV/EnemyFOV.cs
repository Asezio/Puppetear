using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Vector3[] waypointList;
    [SerializeField] private float[] waitTimeList;
    private int wayPointIndex=0;
    [SerializeField]private Transform pfFieldofView;
    [SerializeField] Vector3 aimDirection;
    [SerializeField] private Transform player;

    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDistance = 50f;
    [SerializeField] private LayerMask playerLayer;

    private FOV fieldOfView;

    private float waitTimer;
    private Vector3 lastMoveDir;

    private enum State
    {
        Waiting,
        Moving,
    }

    private State state;
    private void Start()
    {
        waitTimer = waitTimeList[0];
        lastMoveDir = aimDirection;

        fieldOfView = Instantiate(pfFieldofView, null).GetComponent<FOV>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);
    }

    private void Update()
    {
        
        switch (state)
        {
            default:
            case State.Waiting:
            case State.Moving:
                HandleMovement();
                FindTargetPlayer();
                break;

        }

        if (fieldOfView != null)
        {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetAimDir());
        }

        Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);
    }

    private void HandleMovement()
    {
        switch (state)
        {
            case State.Waiting:
                waitTimer -= Time.deltaTime;
                //animatedWalker.SetMoveVector(Vector3.zero);
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;

            case State.Moving:
                Vector3 waypoint = waypointList[wayPointIndex];
                Vector3 waypointDir = (waypoint - transform.position).normalized;
                lastMoveDir = waypointDir;
                float distanceBefore = Vector3.Distance(transform.position, waypoint);
                transform.position = transform.position + waypointDir * speed * Time.deltaTime;
                float distanceAfter = Vector3.Distance(transform.position, waypoint);

                float arriveDistance = 0.1f;
                if (distanceAfter < arriveDistance || distanceBefore <= distanceAfter)
                {
                    //Flip();
                    // Go to next waypoint
                    waitTimer = waitTimeList[wayPointIndex];
                    wayPointIndex = (wayPointIndex + 1) % waypointList.Length;
                    state = State.Waiting;
                }
                break;

        }
    }

    private void FindTargetPlayer()
    {
        if (Vector3.Distance(GetPosition(), player.position) < viewDistance)
        {
            
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.position - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance,playerLayer);
                if (raycastHit2D.collider != null)
                {

                    Debug.Log(raycastHit2D.collider.name);
                }
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }

}
