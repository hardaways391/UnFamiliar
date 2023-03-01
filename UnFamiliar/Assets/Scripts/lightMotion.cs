using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMotion : MonoBehaviour
{
    [SerializeField] Vector2 cycleDurationXZ = new Vector2(20f, 20f);
    [SerializeField] AnimationCurve mvmtPathX;
    [SerializeField] AnimationCurve mvmtPathZ;
    [SerializeField] Vector2 mvmtMagnitudeXZ = new Vector2(1.0f, 1.0f);
    [SerializeField] Vector2 mvmtTimeOffset = new Vector2();

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;   
    }
    void Update()
    {
        move();
    }

    private void move()
    {
        float timeX = Time.time % cycleDurationXZ.x;
        timeX /= cycleDurationXZ.x;

        float timeZ = Time.time % cycleDurationXZ.y;
        timeZ /= cycleDurationXZ.y;

        float newX = mvmtPathX.Evaluate(timeX + mvmtTimeOffset.x) * mvmtMagnitudeXZ.x;
        float newZ = mvmtPathZ.Evaluate(timeZ + mvmtTimeOffset.y) * mvmtMagnitudeXZ.y;

        transform.position = initialPosition + new Vector3(newX, 0, newZ);
    }
}
