using Photon.Pun;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float powerMultiplier;

    public Vector2 minPower;
    public Vector2 maxPower;

    Rigidbody2D rb;
    LineRenderer lr;
    Camera cam;

    Vector3 endPos;
    Vector3 startPos;

    PhotonView view;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
            {
                if (Input.GetMouseButton(0))
                {
                    lr.enabled = true;
                    startPos = this.transform.position;
                    lr.SetPosition(0, startPos);
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = -15;
                    endPos = cam.ScreenToWorldPoint(mousePos);
                    endPos.z = 0;
                    endPos = this.transform.position + (this.transform.position - endPos);
                    lr.SetPosition(1, endPos);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    lr.enabled = false;
                    Vector2 dir = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
                    rb.AddForce(dir * powerMultiplier, ForceMode2D.Impulse);
                }
            }
        }
    }
}
