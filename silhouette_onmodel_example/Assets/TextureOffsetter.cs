using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetter : MonoBehaviour {

	//array to store original offset data of textures set in the inspector
	private Vector2[] scroll_origoffsets;

	//inspector-settable scroll speed that acts as a manual multiplier
	[Range(0.0f,5.0f)]
	public float local_scroll_speed;

	//material information
	private Material[] mats;
	//number of textures applied to this GameObject (the thing this script is attached to)
	private int num_mats;

	//inspector-settable array to set the speeds for the scrolling textures
	[Range(0.0f,1.0f)]
	public float[] scroll_speeds;

	// Use this for initialization
	void Start () {
		
		Renderer renderer = GetComponent<Renderer>();
		mats = renderer.materials;
		num_mats = renderer.materials.Length;

		scroll_origoffsets = new Vector2[num_mats];

//		scroll_speeds[0] = 0.1f;
//		scroll_speeds[1] = 0.2f;
//		scroll_speeds[2] = 0.0f;
//		scroll_speeds[3] = 0.0f;
//		scroll_speeds[4] = 0.0f;
//		scroll_speeds[5] = 0.0f;
//		scroll_speeds[6] = 0.0f;
//		scroll_speeds[7] = 0.0f;
//		scroll_speeds[8] = 0.0f;

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
