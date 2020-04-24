using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myTargetController : MonoBehaviour {

    [SerializeField]
    private Text _hitCounterUI;


    public int _hitCounter;
    [SerializeField]
    private Transform _explosionSpawn;
    [SerializeField]
    private GameObject _explosionPrefab;

    // Use this for initialization
    void Start () {
        _hitCounter = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Inside OnCollicionEnter2D");
        if (collision.gameObject.tag == "boomba")
        {
            _hitCounter++;
            var ex = Instantiate(_explosionPrefab, _explosionSpawn.position, Quaternion.identity) as GameObject;

            ex.GetComponent<ParticleSystem>().Play();
            _hitCounterUI.text = "Hits" +_hitCounter + "";
        }
        Destroy(collision.gameObject);

    }
}
