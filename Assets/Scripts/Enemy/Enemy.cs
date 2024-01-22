// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public float idleDuration;
//     public float movementSpeed;
//     public Transform leftEdge, rightEdge;
//     public StateManager stateManager;
//     public Animator animator {get; private set;}
//     public float attackCooldown;
//     [SerializeField] private BoxCollider2D boxCollider;
//     [SerializeField] private float attackRange;
//     [SerializeField] private float colliderDistance;
//     [SerializeField] private LayerMask playerLayer;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         // boxCollider = GetComponent<BoxCollider2D>();
//         stateManager = new StateManager();
//         stateManager.StartState(this);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         stateManager.currentState.UpdateState(this, stateManager);

//         if (Input.GetKeyDown(KeyCode.Return))
//         {
//             Damage();
//         }
//     }

//     public bool playerInSight() {
//         RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
//         new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
//         0,Vector2.left,0f,playerLayer);

//         if(hit.collider != null) {
//             //mendapatkan nyawa dari player
//         }

//         return hit.collider != null;
//     }

//     private void OnDrawGizmos() {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance, 
//         new Vector3(boxCollider.bounds.size.x * attackRange,boxCollider.bounds.size.y, boxCollider.bounds.size.z));
//     }

//     public void Damage() {
//         stateManager.SwitchState(this, stateManager.enemyDeathState);
//     }
    
//     // private void DamagePlayer() {
//     //     stateManager.currentState.DamagePlayer(this);
//     // }

//     private void Deactivate() {
//         stateManager.currentState.Deactivate(this);
//     }
// }
