using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    
    private Vector3 myPosition;
    [SerializeField]float speed = 0.02f;
    public float stopRange;
   public Vector3 destination;
    [SerializeField] private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
        myPosition = transform.position;
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
    private void Move()
    {

        if (Vector3.Distance(destination, transform.position) > stopRange)
        {
            transform.position = Vector3.Lerp(myPosition, destination, speed * Time.deltaTime);
        }

    }
    public void SetDestination(Vector3 des)
    {
        destination = des;
    }
}
