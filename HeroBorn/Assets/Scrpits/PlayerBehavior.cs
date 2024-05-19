using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // 1
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    // 2
    private float _vInput;
    private float _hInput;
    // 1
    private Rigidbody _rb;
    // ... No other variable changes needed ...
    // 1
    public float JumpVelocity = 5f;
    private bool _isJumping;

    // Start is called before the first frame update
    void Start()
    {
        // 3
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 3
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        // 4
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        // 5
        this.transform.Translate(Vector3.forward * _vInput *
        Time.deltaTime);
        // 6
        this.transform.Rotate(Vector3.up * _hInput *
        Time.deltaTime);
        // 2
        _isJumping |= Input.GetKeyDown(KeyCode.J);
    }
    // 1
    void FixedUpdate()
    {
        // 2
        Vector3 rotation = Vector3.up * _hInput;
        // 3
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        // 4
        _rb.MovePosition(this.transform.position +
        this.transform.forward * _vInput * Time.fixedDeltaTime);
        // 5
        _rb.MoveRotation(_rb.rotation * angleRot);
        // 3
        if (_isJumping)
        {
            // 4
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        // 5
        _isJumping = false;
    }
}
