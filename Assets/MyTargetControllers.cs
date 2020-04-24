using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTargetControllers : MonoBehaviour {


    private int _scoreText;

    public Text ScoreText;

    public GameObject ExplosionPrefab;

    public Transform ExplosionSpawnPoint;

    // Use this for initialization
	void Start () {
        _scoreText = 0;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            _scoreText++;
            GameObject myExplosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, Quaternion.identity);
            ScoreText.text = "Hits= " + _scoreText;
            Destroy(collision.gameObject,0.5f);
        }
    }
}
