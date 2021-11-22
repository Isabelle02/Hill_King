using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketMover : MonoBehaviour
{
    Rigidbody _rigidbody;
    Vector3 savePos;
    Quaternion saveRot;
    bool move;
    private int _exitCount = 0;
    public int ExitCount
    {
        get => _exitCount;
        set
        {
            _exitCount = value;
            OnExitCountChanged?.Invoke();
        }
    }
    [SerializeField] private float speed;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    public event UnityAction OnExitCountChanged; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        savePos = transform.position;
        saveRot = transform.rotation;
    }
    void FixedUpdate()
    {
        if (move == false) return;

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
        if (other.gameObject.name == "GameObject")
        {
            ResetPos();
            ExitCount++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Board")
            move = true;
    }
    public void ResetPos()
    {
        _rigidbody.velocity = new Vector3();
        _rigidbody.angularVelocity = new Vector3();
        transform.position = savePos;
        transform.rotation = saveRot;
        move = false;
    }

}
