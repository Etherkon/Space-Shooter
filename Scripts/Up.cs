using UnityEngine;

using System.Collections;



public class Up : MonoBehaviour {

	

  public GameObject player;
  public float speed;
  private bool moves = false;
  public Boundary boundary;

  void FixedUpdate() {

      if(moves == true) {
           player.transform.Translate(0,0,-speed,Space.World);     

       player.transform.position = new Vector3 
        (
            Mathf.Clamp (player.transform.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp (player.transform.position.z, boundary.zMin, boundary.zMax)
        );
        
	}
  }

  public void move(){  moves = true; 
} 
  public void stop() { moves = false; }

}