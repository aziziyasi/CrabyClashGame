using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
   private NavMeshAgent agent;
   private Transform player;

   void Start(){
    agent = GetComponent<NavMeshAgent>();
    player = FindObjectOfType<Movement>().transform;
   }

   void Update(){
    agent.SetDestination(player.position);
   }
}