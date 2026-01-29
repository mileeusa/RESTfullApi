using DictionaryInActions.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryInActions.src
{
    public class MyCharDictionary
    {
        private readonly Dictionary<char, string> m_dict;

        public MyCharDictionary() 
        {
            m_dict = new Dictionary<char, string>(new CaseInsensitiveCharComparer());
        }

        public void Add(char key, string value)
        {
            m_dict[key] = value;
        }
    }
}
