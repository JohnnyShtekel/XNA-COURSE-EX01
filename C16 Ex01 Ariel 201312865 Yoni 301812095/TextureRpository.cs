using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16_Ex01_Ariel_201312865_Yoni_301812095
{
    internal class TextureRpository
    {
        private static readonly Dictionary<String, Texture2D> m_TextureDictionary = new Dictionary<string, Texture2D>();

        public static void Add(String i_Name, Texture2D i_TextureToAdd)
        {
            m_TextureDictionary.Add(i_Name, i_TextureToAdd);
        }

        public static Texture2D Get(String i_Name)
        {
            Texture2D toReturn = null;

            m_TextureDictionary.TryGetValue(i_Name, out toReturn);

            return toReturn;
        }

        public static void Remove(String i_Name)
        {
            m_TextureDictionary.Remove(i_Name);
        }

        public static List<Texture2D> GetAll()
        {
            return m_TextureDictionary.Values.ToList();
        }
    }
}
