using UnityEngine;

using System.Collections;



public class Fire : MonoBehaviour {



  public GameObject shot;	
  public Transform shotSpawn;
  public Transform shotSpawn2;
  public float fireRate;

  private float nextFire;
  private AudioSource audio;

  void Start() {
       audio = GetComponent<AudioSource>();
  }

  void Update() {
     if (Time.time > nextFire)
        {
          nextFire = Time.time + fireRate;
          Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
          Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
         // audio.Play();
        }
  } 

}