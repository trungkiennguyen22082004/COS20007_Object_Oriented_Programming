using System;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;
        public IdentifiableObject(string[] identifiers)
        {
            _identifiers = new List<string>();
            foreach (string identifier in identifiers) 
                _identifiers.Add(identifier.ToLower());
        }

        public bool AreYou(string identifier) 
        {
            return _identifiers.Contains(identifier.ToLower());
        }

        public string FirstId
        {
            get 
            {
                if (_identifiers.Count == 0)
                    return "";
                else
                    return _identifiers.First(); 
            }
        }

        public void AddIdentifier(string identifier) 
        {
            _identifiers.Add(identifier.ToLower());
        }
    }
}
