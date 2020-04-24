using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyTargetController2 : MonoBehaviour {


    [SerializeField]
    private Transform _explosionSpawn;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    Text scoreText;
    public int _score;

    public AudioClip explodesound;

    private AudioSource MyAudioSrc ;

    private void Start()
    {
        _score = 0;
        scoreText.text = "Score = 0";
        MyAudioSrc = GetComponent<AudioSource>();
        MyAudioSrc.playOnAwake = false;
        MyAudioSrc.clip = explodesound;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "CannonBall")
        {

            var ex = Instantiate(_explosionPrefab, _explosionSpawn.position, Quaternion.identity) as GameObject;

            ex.GetComponent<ParticleSystem>().Play();
            _score++;
            scoreText.text = "Score = " + _score;
            MyAudioSrc.Play();
        }
    }

}
