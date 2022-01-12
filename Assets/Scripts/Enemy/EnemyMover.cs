using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
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
            Tile waypoint = pathChild.GetComponent<Tile>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Tile waypoint in path)
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

        FinishPath();
    }
}
