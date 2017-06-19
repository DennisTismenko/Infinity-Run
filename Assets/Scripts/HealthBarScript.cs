using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    public Image health;
    public Image container;
    public Image damage;
    public Text healthText;
    float fill;


    const float healthYDiff = -1.41f;
    const float damageYDiff = -1.4f;
    const float healthTextYDiff = -0.1f;

    RectTransform healthTransform;
    RectTransform containerTransform;
    RectTransform damageTransform;
    RectTransform healthTextTransform;


    GameObject player;

    void OnEnable()
    {
        Player.playerHit += UpdateGUI;
    }

    void OnDisable()
    {
        Player.playerHit -= UpdateGUI;
    }
	
	void Start()
	{
        healthText.text = Player.health.ToString();
        fill = Player.health / Player.maxHp;
        healthTransform = health.GetComponent<RectTransform>();
        containerTransform = container.GetComponent<RectTransform>();
        damageTransform = damage.GetComponent<RectTransform>();
        healthTextTransform = healthText.GetComponent<RectTransform>();
        player = GameObject.Find ("Player");
	}

	void Update(){
        Vector3 position = Camera.main.WorldToScreenPoint(player.transform.position);
        containerTransform.position = new Vector3(position.x, position.y, 0);
        healthTransform.position = new Vector3(position.x, position.y + healthYDiff, 0);
        damageTransform.position = new Vector3(position.x, position.y + damageYDiff, 0);
        healthTextTransform.position = new Vector3(position.x, position.y + healthTextYDiff, 0);
    }

    void OnGUI()
    {
    }

    void UpdateGUI()
    {
        healthText.text = Player.health.ToString();
        fill = Player.health / Player.maxHp;
        health.fillAmount = fill;
    }


}
