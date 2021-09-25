using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallCollision : MonoBehaviour
{
    PhotonView photonView;

    public void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!photonView.IsMine)
            return;

        if (other.tag != "Player")
            return;

        Vector3 otherVelocity = other.attachedRigidbody.velocity;

        //Set other velocity
        PhotonView otherPhotonView = other.transform.root.GetComponent<PhotonView>();
        Player otherPlayer = otherPhotonView.Owner;
        otherPhotonView.RPC("SetVelocity", otherPlayer, otherVelocity);
    }

    [PunRPC]
    void SetVelocity(Vector3 velocity)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.WakeUp();
        rb.velocity = Vector3.zero;
        rb.AddForce(100 * velocity); //Change this for more forceful collisions
    }
}
