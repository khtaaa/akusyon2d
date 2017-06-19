using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float move;
	public bool floor;
	public Sprite[] spritelist;
	// Use this for initialization
	void Start () {
		floor = false;
	}
	
	// Update is called once per frame
	void Update () {
		move = Input.GetAxis ("Horizontal");//AとDの入力を-1から1に変換
		transform.Translate (move * 0.1f, 0f, 0f);//移動
		//ジャンプ
		if ((Input.GetKeyDown (KeyCode.Space))&&floor==true) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 9.7f);
		}
			

		//右画像に変化
		if (move > 0) {
			if (floor == false) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = spritelist [0];
		}

		//左画像に変化
		if (move < 0) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = spritelist [1];
		}


	}

	//オブジェクトが衝突したとき
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag ("floor")) {
			floor = true;
		}
	}

	//オブジェクトが離れた時
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.CompareTag ("floor")) {
			floor = false;
		}
	}

	//オブジェクトが触れている間
	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.CompareTag ("floor")) {
			floor = true;
		}
	}
}
