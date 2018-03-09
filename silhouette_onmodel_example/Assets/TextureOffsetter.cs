using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetter : MonoBehaviour {

	public float[] scroll_speeds;
	private Vector2[] scroll_origoffsets;

	public float local_scroll_speed = 1.0f;

	private Material[] mats;
	private int num_mats;

	// Use this for initialization
	void Start () {
		
		Renderer renderer = GetComponent<Renderer>();
		mats = renderer.materials;
		num_mats = renderer.materials.Length;

		scroll_origoffsets = new Vector2[num_mats];
		scroll_speeds = new float[20];

		scroll_speeds[0] = 0.1f;
		scroll_speeds[1] = 0.2f;
		scroll_speeds[2] = 0.0f;
		scroll_speeds[3] = 0.0f;
		scroll_speeds[4] = 0.0f;
		scroll_speeds[5] = 0.0f;
		scroll_speeds[6] = 0.0f;
		scroll_speeds[7] = 0.0f;
		scroll_speeds[8] = 0.0f;

		for(int i=0; i<num_mats; i++){
			scroll_origoffsets[i] = mats[i].GetTextureOffset("_MainTex");
		}
	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0; i<num_mats; i++){
			float offset = Time.time * scroll_speeds[i];
			mats[i].SetTextureOffset("_MainTex", new Vector2(offset, scroll_origoffsets[i].y));
		}
		
	}
}
