using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private float health = 1;
    [SerializeField] private GameObject panel;
    [SerializeField] private Image bar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 0.2f;
            bar.fillAmount = health;
            if(health <= 0)
            {
                Time.timeScale = 0;
                panel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
