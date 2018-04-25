using UnityEngine;
using UnityEngine.UI;

// Reference: https://github.com/Temeez/Unity-Dropdown-Example/blob/master/Assets/Scripts/UIDropdown.cs
public class UIDropdown : MonoBehaviour
{
    [Tooltip("Add items (gameobjects) to the dropdown which has the given tag.")]
    public string populateByTag;

    Dropdown m_dropdown;

    void Awake()
    {
        m_dropdown = gameObject.GetComponent<Dropdown>();
        m_dropdown.ClearOptions();

        GameObject[] tag_items = GameObject.FindGameObjectsWithTag(populateByTag);
        if (populateByTag != null)
        {
            foreach (GameObject item in tag_items)
            {
                AddItemToDropdown(item.name);
            }
        }

        m_dropdown.RefreshShownValue();

        m_dropdown.onValueChanged.AddListener(delegate {
            string text = m_dropdown.options[m_dropdown.value].text;
            print("Item: " + text + " | Id: " + m_dropdown.value);

            GameObject[] controlPanels = GameObject.FindGameObjectsWithTag(populateByTag);
            foreach (GameObject panel in controlPanels)
            {
                Vector3 temp = panel.transform.localPosition;
                temp.x = -10000;
                panel.transform.localPosition = temp;
            }

            GameObject controlPanel = GameObject.Find(text);
            Vector3 temp2 = controlPanel.transform.localPosition;
            temp2.x = -470;
            controlPanel.transform.localPosition = temp2;
        });
    }

    public void SelectOption(string text)
    {
        int option_id = 0;
        foreach (Dropdown.OptionData data in m_dropdown.options)
        {
            if (data.text == text)
            {
                m_dropdown.value = option_id;
                m_dropdown.RefreshShownValue();
            }
            option_id++;
        }
    }

    public void AddItemToDropdown(string item, bool select_on_add = false)
    {
        m_dropdown.options.Add(new Dropdown.OptionData(item));

        if (select_on_add)
        {
            SelectOption(item);
        }
    }

    public void AddItemToDropdownAndSelect(string item)
    {
        AddItemToDropdown(item, true);
    }
}