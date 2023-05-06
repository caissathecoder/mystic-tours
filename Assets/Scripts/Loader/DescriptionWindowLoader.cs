using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DescriptionWindowLoader : MonoBehaviour
{
    public string itemID;
    public GameObject descriptionWindow;
    private string itemGroup;

    public void ShowDescription()
    {
        descriptionWindow.SetActive(true);

        if (itemID == "Ang Tondo ni Bonifacio Description"
            || itemID == "Ang Tondo ni Bonifacio Map"
            || itemID == "Ang Dapat Mabatid ng mga Tagalog"
            || itemID == "Ang Dapat Mabatid ng mga Tagalog Mural"
            || itemID == "The Pre-Colonial Archipelago"
            || itemID == "The Blood Compact with the Spaniards"
            || itemID == "Abuses Everywhere"
            || itemID == "Our Mother"
            || itemID == "Rebirth of a Nation")
        {
            itemGroup = "Items_KatipunanMuseum_A";
        }
        else if (itemID == "Kartilya"
            || itemID == "Dekalogo ng Katipunan"
            || itemID == "Portraits"
            || itemID == "Pagpupugay sa Kababaihan ng Himagsikan"
            || itemID == "Sa Mga Babae"
            || itemID == "Mga Katipunera"
            || itemID == "Gising na mga Tagalog"
            || itemID == "Wake Up Tagalogs"
            || itemID == "Gising na mga Tagalog Original")
        {
            itemGroup = "Items_KatipunanMuseum_B";
        }
        else if (itemID == "Tabak"
            || itemID == "Gulok"
            || itemID == "Bolo_01"
            || itemID == "Bolo_02"
            || itemID == "Architectural Detail"
            || itemID == "Gun Powder Horn"
            || itemID == "Saber"
            || itemID == "Rifle"
            || itemID == "Cloth"
            || itemID == "Cedula")
        {
            itemGroup = "Items_KatipunanMuseum_C";
        }
        else if (itemID == "Entrance Statue"
            || itemID == "Unnamed Statue"
            || itemID == "Emilio Jacinto Statue"
            || itemID == "Gregoria de Jesus Statue"
            || itemID == "Andres Bonifacio Statue"
            || itemID == "Katipunan Sculpture"
            || itemID == "Sanduguan Display"
            || itemID == "Sanduguan Sculpture"
            || itemID == "Matinding Pagsubok sa Pagsapi sa Katipunan")
        {
            itemGroup = "Items_KatipunanMuseum_D";
        }
        else if (itemID == "Ang Sigaw ng mga Anak ng Bayan"
            || itemID == "Unang Sigaw Diorama"
            || itemID == "Unang Sigaw"
            || itemID == "Ang Labanan sa Pinaglabanan"
            || itemID == "Painting of JTorres_01"
            || itemID == "Painting of JTorres_02")
        {
            itemGroup = "Items_KatipunanMuseum_E";
        }
        else if (itemID == "Paglaganap at Pagsiklab ng Himagsikan"
            || itemID == "Cebu"
            || itemID == "Kamindanawan"
            || itemID == "Nueva Ecija"
            || itemID == "Bulacan"
            || itemID == "Maynila"
            || itemID == "Panay"
            || itemID == "Batangas"
            || itemID == "Cavite")
        {
            itemGroup = "Items_KatipunanMuseum_F";
        }
        else if (itemID == "Andres at Oryang"
            || itemID == "Andres and Oryang"
            || itemID == "Tula ni Oryang"
            || itemID == "Pagdakila kay Andres Bonifacio"
            || itemID == "Pag-ibig sa Tinubuang Lupa"
            || itemID == "Mga Anting-Anting")
        {
            itemGroup = "Items_KatipunanMuseum_G";
        }
        else if (itemID == "Ang Paglaganap ng Digmaan"
            || itemID == "Emilio Jacinto"
            || itemID == "Ang Utak ng Katipunan"
            || itemID == "Magkaibigan at Magkatuwang"
            || itemID == "Ang Katagalugan ng Katipunan"
            || itemID == "Reproduction of Katipunan Document")
        {
            itemGroup = "Items_KatipunanMuseum_H";
        }
        else if (itemID == "Pinaglabanan Shrine Monument"
            || itemID == "Pinaglabanan Shrine Flame"
            || itemID == "Talaan Description"
            || itemID == "Talaan_A"
            || itemID == "Talaan_B")
        {
            itemGroup = "Items_KatipunanMuseum_I";
        }
        else if (itemID == "Doble Kayod"
            || itemID == "Yakapsul"
            || itemID == "Parcel No. 143"
            || itemID == "Brush Stroke Imitation"
            || itemID == "Tale of Two Variants"
            || itemID == "Look Up in the Sky"
            || itemID == "Ang Hardinera"
            || itemID == "Tatsulok")
        {
            itemGroup = "Items_GSISMuseum_A";
        }
        else if (itemID == "Genealogy 101"
            || itemID == "Ecce Homo"
            || itemID == "Essence of A Woman"
            || itemID == "Fish Bone"
            || itemID == "Hamon sa Kapayapaan"
            || itemID == "Pieta"
            || itemID == "The Twist"
            || itemID == "Banig"
            || itemID == "The Plight of Maliputo")
        {
            itemGroup = "Items_GSISMuseum_B";
        }
        else if (itemID == "History of the Philippine Music"
            || itemID == "Ritual Dance")
        {
            itemGroup = "Items_GSISMuseum_C";
        }

        AnalyticsResult analyticsResult = Analytics.CustomEvent(
            itemGroup,
            new Dictionary<string, object>
            {
                { "item_id", itemID },
            });
        Debug.Log("analyticsResult_ViewedItem: " + analyticsResult);

    }

    public void DisableDescription()
    {
        descriptionWindow.SetActive(false);
    }
}
