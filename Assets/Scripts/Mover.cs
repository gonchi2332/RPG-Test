using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    
    [SerializeField] Transform Target;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasthit = Physics.Raycast(ray, out hit);
        if(hasthit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
    private void UpdateAnimator() 
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity; 
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;  
        GetComponent<Animator>().SetFloat("forwardSpeed", speed); 
    }
}
