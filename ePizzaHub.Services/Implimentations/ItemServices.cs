using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implimentations
{
    public class ItemServices : Services<Item>, IItemServices
    {
        private readonly IRepositories<Item> _repository;

        public ItemServices(IRepositories<Item> repository) : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<ItemModel> GetItems()
        {
            var data = _repository.GetAll().OrderBy(item => item.CategoryId).ThenBy(item => item.ItemTypeId).
                Select(i => new ItemModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    UnitPrice = i.UnitPrice,
                    ImageUrl = i.ImageUrl,
                    CategoryId = i.CategoryId,
                    ItemTypeId = i.ItemTypeId,
                }).ToList();
            return data;
        }
    }
}
