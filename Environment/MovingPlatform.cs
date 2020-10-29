using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Environment
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovingPlatform : Platform
    {
        [SerializeField] Transform[] points;
        [SerializeField] float speed = 2f;
        [SerializeField] float timeBetweenPoints = 1f;
        bool isWaiting = false;
        private float currentWaitTime = 0f;
        private int currentPointIndex;
        Rigidbody rb;

        Vector3 direction;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            currentPointIndex = 0;

            UpdateDirection();
        }
        private void FixedUpdate()
        {
            if (points.Length == 0) return;


            if (Vector3.Distance(transform.position, points[currentPointIndex].position) <= 0.2f)
            {
                isWaiting = true;
                currentWaitTime += Time.fixedDeltaTime;
                if (isWaiting && currentWaitTime <= timeBetweenPoints) return;
                isWaiting = false;
                currentWaitTime = 0f;

                currentPointIndex += 1;
                if (currentPointIndex >= points.Length)
                {
                    currentPointIndex = 0;
                }

                UpdateDirection();
            }
            //transform.Translate(points[currentPointIndex].localPosition * speed * Time.deltaTime, Space.Self);


            //float step = speed * Time.deltaTime;
            //transform.localPosition = Vector3.MoveTowards(transform.localPosition, points[currentPointIndex].localPosition, step);


            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }

        private void UpdateDirection()
        {
            direction = (points[currentPointIndex].position - transform.position).normalized;
        }

        public Vector3 GetDirectionAndSpeed()
        {
            return (!isWaiting) ? direction * speed * Time.fixedDeltaTime : Vector3.zero;
        }
    }
}