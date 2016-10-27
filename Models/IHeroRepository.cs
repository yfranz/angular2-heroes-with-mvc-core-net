using Angular2WithCoreMVC.ViewModels;

namespace Angular2WithCoreMVC.Models
{
    public interface IHeroRepository
    {
        HeroItem[] Search(string name);

        void Add(HeroItem item);

        HeroItem Add(string n);

        void Delete(int id);

        HeroItem Edit(int id, string name);

        HeroItem[] List { get; }
    }
}
