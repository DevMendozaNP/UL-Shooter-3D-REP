using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject healthIcon;

    #region Iconos de vida
    [SerializeField]
    private Sprite fullShieldIcon;
    [SerializeField]
    private Sprite noShieldIcon;
    [SerializeField]
    private Sprite damageIcon;
    [SerializeField]
    private Sprite nearDeathIcon;
    [SerializeField]
    private Sprite deathIcon;
    private Sprite currentHealthIcon;
    #endregion

    #region Contadores de vida y escudo
    [SerializeField]
    private TextMeshProUGUI healthCount;
    [SerializeField]
    private TextMeshProUGUI shieldCount;
    #endregion

    #region Unidades de vida manejadas
    [SerializeField]
    private float healthCountStart = 100f;
    [SerializeField]
    private float shieldCountStart = 100f;
    private float healthCounter;
    private float shieldCounter;
    #endregion

    private void Start()
    {
        //Registrando los niveles de vida asignados en el editor
        healthCounter = healthCountStart;
        shieldCounter = shieldCountStart;

        healthCount.text = healthCountStart.ToString();
        shieldCount.text = shieldCountStart.ToString();

        //Sincronizando los contadores
        Image healthIcon = GetComponent<Image>();
        healthIcon.sprite = currentHealthIcon;

        // Registro como Observer
        PlayerManager.Instance.AddOnPlayerObserver(damageTaken);
    }
    

    private void Update()
    {
        //healthIcon.GetComponent<Image>().sprite = currentHealthIcon;

        if(currentHealthIcon == deathIcon)
        {
            Destroy(player);
        }
    }

    public void damageTaken(float damage)
    {
        if (shieldCounter > 0f)
        {
            shieldCounter -= damage;
            shieldCount.text = shieldCounter.ToString();
        }
        else
        {
            healthCounter -= damage;
            healthCount.text = healthCounter.ToString();
        }
    }

    private void iconChanger()
    {
        if (shieldCounter > 0f)
        {
            currentHealthIcon = fullShieldIcon;
        }
        else if (shieldCounter <= 0f && healthCounter > 50f)
        {
            currentHealthIcon = noShieldIcon;
        }
        else if (shieldCounter <= 0f && healthCounter == 50f)
        {
            currentHealthIcon = damageIcon;
        }
        else if (shieldCounter <= 0f && healthCounter == 25f)
        {
            currentHealthIcon = nearDeathIcon;
        }
        else if (shieldCounter <= 0f && healthCounter <= 0f)
        {
            currentHealthIcon = deathIcon;
        }
    }
    
}