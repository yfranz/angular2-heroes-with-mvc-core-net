using Microsoft.AspNetCore.Mvc;
using Angular2WithCoreMVC.ViewModels;
using System;
using Angular2WithCoreMVC.Models;

namespace Angular2WithCoreMVC.Controllers
{
    [Route("app/[controller]")]
    public class HeroesController : Controller
    {
        class HeroResponce
        {
            public object data;
        }

        private IHeroRepository _repository;
        public HeroesController(IHeroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return Json(new HeroResponce { data = _repository.List });
            }
            else
            {
                return Json(new HeroResponce { data = _repository.Search(name) });
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        [HttpPost]
        public IActionResult Crate([FromBody] HeroItem item)
        {
            return Json(new HeroResponce { data = _repository.Add(item.name) });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] HeroItem item)
        {
            return Json(new HeroResponce { data = _repository.Edit(id, item.name) });
        }
    }
}
