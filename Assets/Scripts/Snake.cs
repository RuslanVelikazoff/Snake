using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    public GameObject losePanel;
    public int score;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if (SwipeController.swipeUp)
        {
            _direction = Vector2.up;
        }

        else if (SwipeController.swipeDown)
        {
            _direction = Vector2.down;
        }

        else if (SwipeController.swipeLeft)
        {
            _direction = Vector2.left;
        }

        else if (SwipeController.swipeRight)
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0f
            ); 
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            score += 2;
            AudioManager.instance.Play("Eat");
        }
        else if (other.tag == "Obstacle" || other.tag == "Player")
        {
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
            losePanel.SetActive(true);

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            AudioManager.instance.Play("Die");
        }
    }
}
