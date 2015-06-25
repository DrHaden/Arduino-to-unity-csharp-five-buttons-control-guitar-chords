using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Chordcontrol : MonoBehaviour {
	public float tac;
	public GameObject[] Chords;
	public AudioClip[] Notes;
	SerialPort sp = new SerialPort ("COM5", 9600); 
	private AudioSource[] Notesource;
	IEnumerator GChord(){
		Chords [0].SetActive (false);
		Chords [1].SetActive (false);
		Chords [2].SetActive (false);
		Chords [3].SetActive (false);
		Chords [4].SetActive (false);
		Debug.Log ("G Chord");
		Notesource [0].PlayOneShot (Notes[0]);
		Chords [0].SetActive (true);
		yield return new WaitForSeconds(tac);
		Debug.Log ("Chord over");
	}
	IEnumerator EChord(){
		Chords [0].SetActive (false);
		Chords [1].SetActive (false);
		Chords [2].SetActive (false);
		Chords [3].SetActive (false);
		Chords [4].SetActive (false);
		Debug.Log ("E Chord");
		Notesource [1].PlayOneShot (Notes[1]);
		Chords [1].SetActive (true);
		yield return new WaitForSeconds(tac);
		Debug.Log ("Chord over");
	}
	IEnumerator AChord(){
		Chords [0].SetActive (false);
		Chords [1].SetActive (false);
		Chords [2].SetActive (false);
		Chords [3].SetActive (false);
		Chords [4].SetActive (false);
		Debug.Log ("A Chord");
		Notesource [2].PlayOneShot (Notes[2]);
		Chords [2].SetActive (true);
		yield return new WaitForSeconds(tac);
		Debug.Log ("Chord over");
	}
	IEnumerator CChord(){
		Chords [0].SetActive (false);
		Chords [1].SetActive (false);
		Chords [2].SetActive (false);
		Chords [3].SetActive (false);
		Chords [4].SetActive (false);
		Debug.Log ("C Chord");
		Notesource [3].PlayOneShot (Notes[3]);
		Chords [3].SetActive (true);
		yield return new WaitForSeconds(tac);
		Debug.Log ("Chord over");
	}
	IEnumerator DChord(){
		Chords [0].SetActive (false);
		Chords [1].SetActive (false);
		Chords [2].SetActive (false);
		Chords [3].SetActive (false);
		Chords [4].SetActive (false);
		Debug.Log ("D Chord");
		Notesource [4].PlayOneShot (Notes[4]);
		Chords [4].SetActive (true);
		yield return new WaitForSeconds(tac);
		Debug.Log ("Chord over");
	}
	void Start () {
		Notesource [0] = GetComponent<AudioSource>();
		Notesource [1] = GetComponent<AudioSource>();
		Notesource [2] = GetComponent<AudioSource>();
		Notesource [3] = GetComponent<AudioSource>();
		Notesource [4] = GetComponent<AudioSource>();
		sp.Open ();
		sp.ReadTimeout = 1;
	}
	void Update () {
		if (sp.IsOpen) {
			try {
				changechord (sp.ReadByte ());
			} catch (System.Exception) {
				
			}
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			StartCoroutine (GChord());
		} 
		if (Input.GetKeyDown (KeyCode.E)) {
			StartCoroutine (EChord());
		} 
		if (Input.GetKeyDown (KeyCode.A)) {
			StartCoroutine (AChord());
		} 
		if (Input.GetKeyDown (KeyCode.C)) {
			StartCoroutine (CChord());
		} 
		if (Input.GetKeyDown (KeyCode.D)) {
			StartCoroutine (DChord());
		}
	}
	void changechord (int Chord){
		if (Chord == 1) {
			StartCoroutine (GChord());
		} 
		if (Chord == 2) {
			StartCoroutine (EChord());
		}
	    if (Chord == 3) {
			StartCoroutine (AChord());
		}
		if (Chord == 4) {
			StartCoroutine (CChord());
		}
		if (Chord == 5) {
			StartCoroutine (DChord());
		}
	}
}
