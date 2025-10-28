using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                return new List<Categorys>
                {
                    new Categorys(){
                        Id = 0,
                        Name = "Микроволновые печи",
                        Description = "Микроволновая печь - электроприбор, позволяющий совершать разогрев водосодержащих веществ благодаря электромагнитному излучению дециметрового диапазона (обычно с частотой 2450 МГц) и предназначенный для быстрого приготовления, подогрева или размораживания пищи."
                    },
                    new Categorys(){
                        Id = 1,
                        Name = "Мультиварки",
                        Description = "Мультиварка - многофункциональный бытовой прибор, который значительно упрощает процесс приготовления разнообразных блюд"
                    },
                };
            }
        }
    }
}
