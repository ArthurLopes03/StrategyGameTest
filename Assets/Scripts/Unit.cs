using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private float stoppingDistance = 1f;
    private GridPosition gridPosition;

    [SerializeField] private Animator unitAnimator;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    private void Update()
    {
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            unitAnimator.SetBool("isRunning", true);

            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        }
        else
        {
            unitAnimator.SetBool("isRunning", false);
        }

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }
    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
