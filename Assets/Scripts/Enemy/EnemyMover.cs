using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    private Enemy enemy;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PrintWaypointName());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void FindPath()
    {
        path.Clear();

        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform pathChild in pathParent.transform)
        {
            path.Add(pathChild.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }

        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
