using Angular2WithCoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2WithCoreMVC.Models
{
    public class HeroRepository : IHeroRepository
    {
        private Dictionary<int, HeroItem> data = new Dictionary<int, HeroItem>();
        private int maxId = 0;

        public HeroRepository()
        {
            Add(new HeroItem() { id = 11, name = "Mr. Nice" });
            Add(new HeroItem() { id = 12, name = "Narco" });
            Add(new HeroItem() { id = 13, name = "Bombasto" });
            Add(new HeroItem() { id = 14, name = "Celeritas" });
            Add(new HeroItem() { id = 15, name = "Magneta" });
            Add(new HeroItem() { id = 16, name = "RubberMan" });
            Add(new HeroItem() { id = 17, name = "Dynama" });
            Add(new HeroItem() { id = 18, name = "Dr IQ" });
            Add(new HeroItem() { id = 19, name = "Magma" });
            Add(new HeroItem() { id = 20, name = "Tornado" });
        }

        public HeroItem[] Search(string name)
        {
            List<HeroItem> responce = new List<HeroItem>();
            foreach(HeroItem item in data.Values)
            {
                if(item.name.ToLower().Contains(name.ToLower()))
                {
                    responce.Add(item);
                }
            }
            return responce.ToArray();
        }

        public void Add(HeroItem item)
        {
            data[item.id] = item;
            if (maxId < item.id)
            {
                maxId = item.id;
            }
        }

        public HeroItem Add(string n)
        {
            HeroItem item = new HeroItem() { id = maxId + 1, name = n };
            Add(item);
            return item;
        }

        public void Delete(int id)
        {
            data.Remove(id);
        }

        public HeroItem Edit(int id, string name)
        {
            data[id].name = name;
            return data[id];
        }

        public HeroItem[] List
        {
            get
            {
                return data.Values.ToArray();
            }
        }
    }
}
