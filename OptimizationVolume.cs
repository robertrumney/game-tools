using UnityEngine;
using System.Collections.Generic;

public class OptimizationVolume : MonoBehaviour 
{
    public bool autoSpawnOnStart = false;
    public bool useSpawning = false;
    public GameObject[] items;
    public List<GameObject> spawnedItems = new List<GameObject>();
    private bool activated = false;

    private void Awake () 
    {
        GetComponent<MeshRenderer>().enabled = false;
        SetItems(false);
    }

    private IEnumerator Start()
    {
        ProceduralMachine.instance.volumes.Add(this);
        if (autoSpawnOnStart) AutoSpawn();
        yield return new WaitForSeconds(2);
        activated = true;
        GetComponent<Collider>().enabled = false;
        yield return null;
        GetComponent<Collider>().enabled = true;
    }

    private void AutoSpawn()
    {
        ProceduralMachine.instance.SpawnAtPoint(this, transform.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && activated)
        {
            if (useSpawning)
            {
                ProceduralMachine.instance.Do(this);
            }
            SetItems(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            SetItems(false);
        }
    }

    public void ForceClear()
    {
        foreach(GameObject go in spawnedItems)
        {
            Destroy(go);
        }
        spawnedItems.Clear();
    }

    private void SetItems(bool active)
    {
        foreach (GameObject item in items)
        {
            if (item) item.SetActive(active);
        }
    }

    public void SpawnItem(GameObject go)
    {
        spawnedItems.Add(go);
    }

    public bool CannotSpawnMoreItems(ProceduralMachine pm)
    {
        return spawnedItems.Count > pm.amount;
    }
}
