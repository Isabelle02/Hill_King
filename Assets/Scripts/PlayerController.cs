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
    
    private Rigidbody _rigidbody;
    
    private Vector3 _savePos;
    private Quaternion _saveRot;
    
    private bool _isMoving;
    
    private int _score;
    
    public event UnityAction OnFell;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _savePos = transform.position;
        _saveRot = transform.rotation;
    }
    
    void FixedUpdate()
    {
        if (_isMoving == false) 
            return;

        if (Input.GetKey(up))
            _rigidbody.AddForce(transform.up * speed, ForceMode.Impulse);

        if (Input.GetKey(down))
            _rigidbody.AddForce(-transform.up * speed, ForceMode.Impulse);

        if (Input.GetKey(left))
            transform.Rotate(-10, 0, 0, Space.Self);

        if (Input.GetKey(right))
            transform.Rotate(10, 0, 0, Space.Self);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out BoardBounds bounds))
            return;
        
        _score++;
        OnFell?.Invoke();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out Board board))
            return;
        
        _isMoving = true;
    }

    public int GetScore() => _score;
    public string GetName() => name;

    public void ResetPlayer()
    {
        _score = 0;
        
        ResetPos();
    }
    
    public void ResetPos()
    {
        _rigidbody.velocity = new Vector3();
        _rigidbody.angularVelocity = new Vector3();
        
        transform.position = _savePos;
        transform.rotation = _saveRot;
        
        _isMoving = false;
    }
}
