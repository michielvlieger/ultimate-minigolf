using UnityEngine;

public class Finish : MonoBehaviour
{
    public float maxSpeedFinish = 0.1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Hole" && this.GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeedFinish)
        {
            Camera.main.GetComponent<BallTracking>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
