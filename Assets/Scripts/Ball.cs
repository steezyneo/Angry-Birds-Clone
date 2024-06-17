using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hookRb;

    public GameObject nextBall;

    public float releseTime = .15f;
    public float maxDragDistance = 0f;

    bool isClicked;

    private void Update()
    {
        if (isClicked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hookRb.position) > maxDragDistance)
            {
                rb.position = hookRb.position + (mousePos - hookRb.position).normalized * maxDragDistance;
            }
            else
                rb.position = mousePos;
        }
    }
    private void OnMouseDown()
    {
        isClicked = true;
        rb.isKinematic = true;

    }

    private void OnMouseUp()
    {
        isClicked = false;
        rb.isKinematic = false;

        StartCoroutine(Relese());

    }
    
    IEnumerator Relese()
    {
        yield return new WaitForSeconds(releseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
