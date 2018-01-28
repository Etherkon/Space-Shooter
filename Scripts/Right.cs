using UnityEngine;

using System.Collections;




[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Right : MonoBehaviour {

	

  public GameObject player;
  public float speed;
  private bool moves = false;
  public float tilt;
  public Boundary boundary;

  void FixedUpdate() {

      if(moves == true) {
           player.transform.Translate(speed,0,0,Space.World);

         player.transform.position = new Vector3 
        (
            Mathf.Clamp (player.transform.position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp (player.transform.position.z, boundary.zMin, boundary.zMax)
        );


       }     
  }

  public void move(){  moves = true; 
     player.transform.Rotate(0,0,-tilt,Space.World);} 
  public void stop() { moves = false;
    player.transform.Rotate(0,0,tilt,Space.World); }

}