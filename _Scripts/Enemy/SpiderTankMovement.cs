using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpiderTankMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 lookDir;
    private Vector3 change;
    private NavMeshAgent agent;
    void Start()
    {
        this.player = GameManager.instance.player;
        this.change = new Vector3(Random.Range(0.2f, 2), Random.Range(-2, -0.2f));

        this.agent = transform.parent.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {

        this.lookDir = this.player.transform.position - transform.position;
        agent.SetDestination(this.player.transform.position + this.change);
    }
    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(this.lookDir.y, this.lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.parent.localRotation = Quaternion.Euler(0, 0, angle);
    }

}
