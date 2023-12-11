using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private navigation_patrol enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Chase");
            //enemy.ChasePlayer();
        }
    }
}
