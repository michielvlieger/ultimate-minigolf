using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Pun;

public class SpawnBalls : MonoBehaviour
{
    public GameObject spawnObject;
    Camera cam;
    Vector3 spawnLocation = new Vector3(0, 0, 0);

    private void Start()
    {
        cam = Camera.main;
        Tilemap tilemap = this.GetComponent<Tilemap>();
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position))
            {
                spawnLocation = tilemap.CellToWorld(position);
                spawnLocation.x += 0.5f;
                spawnLocation.y += 0.5f;
                break;
            }
        }
    }

    void Spawn()
    {
        GameObject newBall = PhotonNetwork.Instantiate(spawnObject.name, spawnLocation, Quaternion.identity);
        cam.GetComponent<BallTracking>().target = newBall;
        cam.GetComponent<BallTracking>().enabled = true;

    }
}
