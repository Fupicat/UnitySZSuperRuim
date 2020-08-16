using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GJSave : MonoBehaviour {

    private static string invString;

    public static void Save()
    {
        invString = "";
        foreach (SkinManager.Roupa item in SkinManager.Inventory)
        {
            if(invString == "")
                invString = SkinManager.GetRoupaID(item).ToString();
            else
                invString = invString + "," + SkinManager.GetRoupaID(item);
        }
        Debug.Log(invString);

        DataStore.Set("Roupas", invString, false, (bool success) => { });
        DataStore.Set("Creds", CredsSystem.credsTotal.ToString(), false, (bool success) => { });
        DataStore.Set("Planeta", PlanetaControle.CurrentPlanet, false, (bool success) => { });
        DataStore.Set("CabeçaUsando", SkinManager.GetRoupaID(SkinManager.CabeçaUsando).ToString(), false, (bool success) => { });
        DataStore.Set("RoupaUsando", SkinManager.GetRoupaID(SkinManager.RoupaUsando).ToString(), false, (bool success) => { });
        DataStore.Set("CalçaUsando", SkinManager.GetRoupaID(SkinManager.CalçaUsando).ToString(), false, (bool success) => { });
        DataStore.Set("LuvaUsando", SkinManager.GetRoupaID(SkinManager.LuvaUsando).ToString(), false, (bool success) => { });
        DataStore.Set("SapatoUsando", SkinManager.GetRoupaID(SkinManager.SapatoUsando).ToString(), false, (bool success) => { });

        DataStore.Set("CasaCor", CasaRender.GetDecorID(CasaRender.CasaCor).ToString(), false, (bool success) => { });
        DataStore.Set("CasaMúsica", CasaRender.GetDecorID(CasaRender.CasaMúsica).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot1", CasaRender.GetDecorID(CasaRender.CasaSlot1).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot2", CasaRender.GetDecorID(CasaRender.CasaSlot2).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot3", CasaRender.GetDecorID(CasaRender.CasaSlot3).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot4", CasaRender.GetDecorID(CasaRender.CasaSlot4).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot5", CasaRender.GetDecorID(CasaRender.CasaSlot5).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot6", CasaRender.GetDecorID(CasaRender.CasaSlot6).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot7", CasaRender.GetDecorID(CasaRender.CasaSlot7).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot8", CasaRender.GetDecorID(CasaRender.CasaSlot8).ToString(), false, (bool success) => { });
        DataStore.Set("CasaSlot9", CasaRender.GetDecorID(CasaRender.CasaSlot9).ToString(), false, (bool success) => { });

        SaveAnim.SaveLoad(0);
    }

    public static void GJLoad()
    {

        CasaRender.LoadDecors();

        DataStore.Get("Creds", false, (string value) =>
        {
            if (value != null)
            {
                CredsSystem.credsTotal = int.Parse(value);
            }
        });
        
        DataStore.Get("Planeta", false, (string value) =>
        {
            if (value != null)
            {
                SceneManager.LoadScene(value);
            }
        });

        DataStore.Get("Roupas", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.Inventory.Clear();

                string[] invArr = value.Split(',');
                foreach (string item in invArr)
                {
                    SkinManager.Inventory.Add(SkinManager.All[int.Parse(item)]);
                }
            }
        });

        DataStore.Get("CabeçaUsando", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.CabeçaUsando = SkinManager.All[int.Parse(value)];
            }
        });

        DataStore.Get("RoupaUsando", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.RoupaUsando = SkinManager.All[int.Parse(value)];
            }
        });

        DataStore.Get("CalçaUsando", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.CalçaUsando = SkinManager.All[int.Parse(value)];
            }
        });

        DataStore.Get("LuvaUsando", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.LuvaUsando = SkinManager.All[int.Parse(value)];
            }
        });

        DataStore.Get("SapatoUsando", false, (string value) =>
        {
            if (value != null)
            {
                SkinManager.SapatoUsando = SkinManager.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaCor", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaCor = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaMúsica", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaMúsica = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot1", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot1 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot2", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot2 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot3", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot3 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot4", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot4 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot5", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot5 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot6", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot6 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot7", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot7 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot8", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot8 = CasaRender.All[int.Parse(value)];
            }
        });

        DataStore.Get("CasaSlot9", false, (string value) =>
        {
            if (value != null)
            {
                CasaRender.CasaSlot9 = CasaRender.All[int.Parse(value)];
            }
        });

        SaveAnim.SaveLoad(1);
    }
}
