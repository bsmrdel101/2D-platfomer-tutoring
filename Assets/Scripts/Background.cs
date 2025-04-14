using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] private float bgSpeed = 0.4f;
    
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    
    
    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x * bgSpeed, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 2.0f);
    }
}
