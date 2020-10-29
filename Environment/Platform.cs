using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Environment
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] Renderer[] shaderRenderers;
        [SerializeField] float timeToAppear = 1f;
        [SerializeField] string dissolveShaderValueReference; // Vector1_382BFC75
        //Material shader;
        private float t = 0f;
        private bool isRunning = false;
        IEnumerator currentCoroutine;
        private float currentShaderValue = 1f;
        private Vector3 startPosition;
        private float randomMultiplyValue;


        private void Awake()
        {
            SetShaderRenderers(1f);
            startPosition = transform.position;
            randomMultiplyValue = Random.Range(-1f, 1f);
        }

        private void FixedUpdate()
        {
            transform.position = startPosition + new Vector3(0f, Mathf.Sin(Time.time * randomMultiplyValue) * 0.2f, 0f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                isRunning = false;
            }
            currentCoroutine = DisolveToCoroutine(currentShaderValue, 0f);
            StartCoroutine(currentCoroutine);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                isRunning = false;
            }
            currentCoroutine = DisolveToCoroutine(currentShaderValue, 1f);
            StartCoroutine(currentCoroutine);
        }

        IEnumerator DisolveToCoroutine(float from, float to)
        {
            isRunning = true;
            t = 0f;

            while (t < timeToAppear && isRunning)
            {
                //shader.SetFloat(dissolveShaderValueReference, Mathf.Lerp(from, to, t));
                currentShaderValue = Mathf.Lerp(from, to, t);
                SetShaderRenderers(currentShaderValue);
                t += Time.deltaTime;
                yield return null;
            }
            isRunning = false;
        }

        private void SetShaderRenderers(float value)
        {
            foreach (Renderer shaderRenderer in shaderRenderers)
            {
                Material shader = shaderRenderer.material;
                shader.SetFloat(dissolveShaderValueReference, value);
            }
        }
    }
}