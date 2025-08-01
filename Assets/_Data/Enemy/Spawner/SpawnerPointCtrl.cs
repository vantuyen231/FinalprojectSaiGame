using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCtrl : SaiBehaviour
{
    [SerializeField] protected List<SpawnPoint> spawnPoints ;
    public List<SpawnPoint> SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        SpawnPoint[] points = transform.GetComponentsInChildren<SpawnPoint>();
        this.spawnPoints = new List<SpawnPoint>(points);
        Debug.Log(transform.name + ": LoadFirePoints", gameObject);
    }

    //public Transform GetRandomSpawnPoint()
    //{
    //    if (spawnPoints.Count == 0) return this.transform;
    //    int index = Random.Range(0, spawnPoints.Count);
    //    return spawnPoints[index];
    //}

}
