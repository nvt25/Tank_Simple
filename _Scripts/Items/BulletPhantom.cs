using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletPhantom : MonoBehaviour
{
    public GameObject bom;
    private GameObject player;
    private NavMeshAgent agent;
    void Start()
    {
        this.player = GameManager.instance.player;
        this.agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(this.player.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
            Tung();
    }
    private void Tung()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 chang = new Vector3(Random.Range(-1.5f, 1), Random.Range(1.5f, -1.5f));
            GameObject bom = Instantiate(this.bom, transform.position + chang, Quaternion.identity);
            Destroy(bom, 2.5f);
        }
    }
}
