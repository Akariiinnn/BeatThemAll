using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerTransform.position.x);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraPos;
    }
}
