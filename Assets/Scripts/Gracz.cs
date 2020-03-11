using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour {

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(-Vector3.right);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(-Vector3.up);
        }
    }
    void MovePlayer(Vector3 direction)
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Moneta")
        {
            GameManager.Instance.CollectedCoin(col.gameObject);
        }
        if (col.gameObject.tag == "Meta")
		   {
            GameManager.Instance.WonGame();
        }
    }
}
