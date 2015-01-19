using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//attack
	public float damage = 1f;
	private bool stopAttack = false;
	//range checking
	public float attackRange = 3f;
	public float sightRange = 5f;
	//timing
	public float attackDuration = 1f;
	public float attackBuff = 0f;

	public static int playerLife = 10;




	/*function Begin(){
		stopAttack = false;
	}
	
	function End(){
		stopAttack = true;
		GetComponent(Unit).priority = 0;
	}
	
	function Update(){
		if(!stopAttack){ //can attack
			if(GetComponent(Unit).target != null){
				Begin(GetComponent(Unit).target); //if unit has target, attack target
			}
			else {//else unit checks for surround enemies
				var nearbyUnits = Physics.OverlapSphere(Transform.position,SightRange - 4, 1<<10);
				for(var i = 0; i<nearbyUnits.length;i++){
					//nearbyunit is an enemy
					if(){
						//begin attacking nearby enemy
					}
				}
			}
		}
	}*/
}
