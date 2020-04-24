using UnityEngine;
using UnityEngine.UI;

public class PriceCannonController : MonoBehaviour
{
    public int Number_of_CannonBalls;

    public GameObject cannonBall;
    public Transform cannonBallSpawn;

    [Range (0.001f, 2.0f)]
    public float TranslationIncrement = .7f;

    private const float AngleIncrement = 5f;

    public float cannon_Power = 5;
    private float _angle = 0;

    public void AngleUp()
    {
        if (_angle + AngleIncrement > 90f) return;
        Debug.Log("Move Angle up");
        _angle += AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    public void ShootCannonBall()
    {
        var acannonBall = Instantiate(cannonBall, cannonBallSpawn.transform.position, Quaternion.identity);
        Rigidbody2D cannonBallRigidBody = acannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidBody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * cannon_Power; 
    }

    private void Awake()
    {
        Debug.Log("In Awake");
        Number_of_CannonBalls = 10;
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("In Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In Update");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move the cannon to the right
            transform.root.position += Vector3.right * TranslationIncrement;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the cannon to the left
            transform.root.position += Vector3.left * TranslationIncrement;
        }
    }

    // For physics
    private void FixedUpdate()
    {
        
    }

    // For UI stuff
    private void LateUpdate()
    {
        
    }
}
