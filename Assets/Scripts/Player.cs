using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;

    public float thrustSpeed = 1.0f; //velocidad de empuje
    public float turnSpeed = 1.0f; //velocidad de giro


    private Rigidbody2D _rigidbody;

    private bool _thrusting; //empuje

    private float _turnDirection; //giro

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //siempre se capturan las teclas de input
    {
        // empujando cuando 
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow); 
    
        // giro
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;

        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;

        } else
        {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate() // siempre se mueven objetos por rigidbody
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Proyect(this.transform.up);
    }


}
