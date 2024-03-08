using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; //matriz de sprites
    public float size = 1.0f; 
    public float minSize = 0.09f; // < 0.10f
    public float maxSize = 0.30f;
    public float speed = 2.5f;
    public float maxLifeTime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private AudioSource asteroidSound; // no funciona
    public AudioClip explotion;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        asteroidSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)]; //asteroide aleatorio

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f); //giro aleatorio

        this.transform.localScale = Vector3.one * this.size; //tamaño aleatorio

        _rigidbody.mass = this.size; //masa aleatoria deacuerdo a su tamaño?
    }

    public void SetTrayectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //asteroidSound.PlayOneShot(explotion, 1.0f);
            if((this.size * 0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
            //asteroidSound.PlayOneShot(explotion, 1.0f);
        }
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrayectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
