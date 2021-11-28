using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private float speed;
    
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    
    private Rigidbody rigidbody;
    
    private Vector3 savePos;
    private Quaternion saveRot;
    
    private bool isMoving;
    
    private int score;
    
    public event UnityAction OnFell;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        savePos = transform.position;
        saveRot = transform.rotation;
    }
    
    void FixedUpdate()
    {
        if (isMoving == false) 
            return;

        if (Input.GetKey(up))
            rigidbody.AddForce(transform.up * speed, ForceMode.Impulse);

        if (Input.GetKey(down))
            rigidbody.AddForce(-transform.up * speed, ForceMode.Impulse);

        if (Input.GetKey(left))
            transform.Rotate(-10, 0, 0, Space.Self);

        if (Input.GetKey(right))
            transform.Rotate(10, 0, 0, Space.Self);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out BoardBounds bounds))
            return;
        
        score++;
        OnFell?.Invoke();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Board board))
            return;
        
        isMoving = true;
    }

    public int GetScore() => score;
    public string GetName() => name;

    public void ResetPlayer()
    {
        score = 0;
        
        ResetPos();
    }
    
    public void ResetPos()
    {
        rigidbody.velocity = new Vector3();
        rigidbody.angularVelocity = new Vector3();
        
        transform.position = savePos;
        transform.rotation = saveRot;
        
        isMoving = false;
    }
}
