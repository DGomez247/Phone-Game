using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon_Crontroller : MonoBehaviour {

    [Range(0.001f, 10f)]
    public float speed;
    public GameObject CannonBallPrefab;
    public Transform CannonBallSpawnPoint;
    private float _angle;
    public float AngleIncrement = 5f;
    public float PowerIncrement = 5f;
    public float cannon_Power;
    public float MaxPower = 100f;
    public float MinPower = 1f;

    [SerializeField]
    Text _powerText;


    public void fire()
    {
        //Debug.Log("Called Fire");
        var cannonBall = Instantiate(CannonBallPrefab, CannonBallSpawnPoint.position, Quaternion.identity) as GameObject;
        var cannonBallRigidbody = cannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidbody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * cannon_Power;
    }
    public void angle_Up()
    {
        //Debug.Log("Called Angle Up");
        if (_angle > 90f) return;
        _angle += AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    public void angle_Down()
    {
        if (_angle <= 0f) return;
        _angle -= AngleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }


    public void PowerUp()
    {
        if (cannon_Power + PowerIncrement > MaxPower) return;
        cannon_Power += PowerIncrement;
        _powerText.text = cannon_Power + "";
    }
    public void PowerDown()
    {
        if (cannon_Power - PowerIncrement < MinPower) return;
        cannon_Power -= PowerIncrement;
        _powerText.text = cannon_Power + "";
    }
    private void Awake()
    {
        //Debug.Log("Inside Start");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Inside Start");
        _powerText.text = "Power " + MinPower.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Inside Update");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.root.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.root.position += Vector3.left * speed;
        }
    }

    private void FixedUpdate()
    {

        //Debug.Log("Inside FixedUpdate");
    }

    private void LateUpdate()
    {
        // Debug.Log("Inside LateUpdate");
    }
}
