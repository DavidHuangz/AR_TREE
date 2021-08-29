using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ToggleLayers : MonoBehaviour
{
    public GameObject Water;
    public GameObject Nutrient;
    public GameObject Main;

    public GameObject Recommend_Panel;
    public TextMeshProUGUI Recommend_txt;
    public Button button_1;
    public Button button_2;

    void start()
    {
        Recommend_txt.text = "--";
        button_1.GetComponent<Image>().color = new Color(141,189,219);
    }

    public void setWaterActive()
    {
        Water.transform.gameObject.SetActive(true);
        Main.transform.gameObject.SetActive(false);
    }

    public void setNutrientActive()
    {
        Nutrient.transform.gameObject.SetActive(true);
        Main.transform.gameObject.SetActive(false);
    }

    public void setMain()
    {
        Main.transform.gameObject.SetActive(true);
        Water.transform.gameObject.SetActive(false);
        Nutrient.transform.gameObject.SetActive(false);
    }

    // Recommendation buttons
    public void setRecommend_1()
    {
            Recommend_Panel.transform.gameObject.SetActive(false);
            Recommend_Panel.transform.gameObject.SetActive(true);
            Recommend_txt.text = "Plant soil can dry out quickly because of low humidity, " +
                "internal water channels, excessive sunlight, loose soil, and unwanted fungi. " +
                "As a result, water can run out of holes at the bottom of the pot, while atmospheric " +
                "conditions around the plant can escalate the rate of evaporation, causing the soil to dry out fast.";
            button_1.GetComponent<Image>().color = Color.grey;
            button_2.GetComponent<Image>().color = new Color(141, 189, 219);

    }

    public void setRecommend_2()
    {
            Recommend_Panel.transform.gameObject.SetActive(false);
            Recommend_Panel.transform.gameObject.SetActive(true);
            Recommend_txt.text = "If your plants are not growing in pots or in your garden, evaluate the environment. " +
                "Each plant has different requirements for sunlight, soil type, soil pH levels and water needs. " +
                "Make sure that plants are getting the required sunlight each day. " +
                "Some plants will thrive in heavy shade, while others require full sun.";
            button_2.GetComponent<Image>().color = Color.grey;
            button_1.GetComponent<Image>().color = new Color(141, 189, 219);
    }

    public void hideRecommend()
    {
        button_1.GetComponent<Image>().color = new Color(141, 189, 219);
        button_2.GetComponent<Image>().color = new Color(141, 189, 219);
        Recommend_Panel.transform.gameObject.SetActive(false);
    }

}
