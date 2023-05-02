using System;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        private string _description;
        private string _name;

        public string Name
        { 
            get 
            {
                return _name;
            } 
        }

        public virtual string FullDescription
        { 
            get 
            {
                return _description;
            }
        }

        public string ShortDescription
        {
            get 
            {
                return $"{Name} ({FirstId})"; 
            }
        }
    }
}
