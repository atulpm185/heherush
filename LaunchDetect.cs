using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDetect : MonoBehaviour
{
  public MovementMechanics MovementMechanics;

  private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "player")
        {
         MovementMechanics.Launching=0;
        }
    }

  private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "player")
        {
         MovementMechanics.Launching=1;
        }
    }  

}
