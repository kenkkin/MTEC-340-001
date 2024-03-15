using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int HP;
    [SerializeField] int HeartsNumber = 5;

    [SerializeField] Image[] Hearts;
    [SerializeField] Sprite FullHeart;
    [SerializeField] Sprite EmptyHeart;
    [SerializeField] Sprite ArmouredHeart;
    
    void Update()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (HP > HeartsNumber)
            {
                HP = HeartsNumber;
            }
            
            if (i < HP)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            
            if (i < HeartsNumber)
            {
                Hearts[i].enabled = true;
            }
            else 
            {
                Hearts[i].enabled = false;
            }
        } 
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (gameObject.tag == "Player")
        {
            if (HP <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}   
