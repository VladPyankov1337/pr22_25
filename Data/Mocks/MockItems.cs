using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys _category = new MockCategorys();
        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items() {
                        Id = 0,
                        Name = "DEXP MS-70",
                        Description = "Благодаря черному корпусу с лаконичным дизайном микроволновая печь DEXP MS-70 отлично впишется в кухню с любым интерьером. Камера вмещает 20 л и дополняется удобным поворотным столом со стеклянным блюдом диаметром 25.5 см. С эмалированных стенок легко удаляются засохшие частички пищи. Для простоты ухода перед очисткой камеры можно поставить на 1-2 минуты стакан с водой и лимонной кислотой.",
                        Image = "https://c.dns-shop.ru/thumb/st1/fit/500/500/59a87f71c12f41fa3c6ad251a93b7811/b1a761fddbd2197e22bdcf5ee0cd1cfd773ce824ab6ef6eba7411b9a626c50a7.jpg.webp",
                        Price = 3999,
                        Category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 1,
                        Name = "DEXP ES-70",
                        Description = "Микроволновая печь DEXP ES-70 представлена в белом корпусе с дисплеем и сенсорными кнопками. Вы можете блокировать управление от любопытных детей. Поворотный стол гарантирует равномерный прогрев продуктов и блюд. Камера на 20 л с диаметром поддона 25.5 см вмещает объемную посуду.",
                        Image = "https://c.dns-shop.ru/thumb/st4/fit/500/500/988026b016ec56e2fd890b4a1545b017/74fcd7425bfbba9b47d84fb84aa2f8fe96a52d8a580ae722dc1d4a8c29a023f1.jpg.webp",
                        Price = 4699,
                        Category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 2,
                        Name = "LG RENAISSANCE MS2042DY",
                        Description = "Микроволновая печь LG RENAISSANCE MS2042DY представлена в белом корпусе с дисплеем и мембранными кнопками. Вы можете настраивать часы, использовать 5 уровней мощности, таймер до 95 минут, 32 автоматические программы. Есть отдельные кнопки быстрого разогрева и разморозки продуктов. СВЧ позволяет программировать многоступенчатое приготовление сложных блюд.",
                        Image = "https://c.dns-shop.ru/thumb/st4/fit/500/500/fb55f30890d809f41105ebe4712752fd/a01b40624070eb81babcf288eb4364ee1827a6a01bb7bbc6e8bf2a7d84b22712.jpg.webp",
                        Price = 6499,
                        Category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 3,
                        Name = "Polaris PMC 0517 Expert",
                        Description = "Мультиварка Polaris PMC 0517 Expert – настоящий «эксперт» на вашей кухне. При ее мощности 860 Вт и объеме чаши 5 л получить горячее полноценное блюдо можно за кратчайший промежуток времени без необходимости его контролировать – в керамической чаше супы приобретут необходимую консистенцию, а мясо и овощи – нужную степень прожарки даже без применения масла. Модель оснащена дисплеем и панелью сенсорного управления для простоты эксплуатации.",
                        Image = "https://c.dns-shop.ru/thumb/st4/fit/500/500/b05914eef41762a0e7c7d84b6d4b8840/ff276fb60caf1fede7933fb96ddb34271785b84a08d779e590f9f18bdd164e0e.jpg.webp",
                        Price = 7999,
                        Category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 4,
                        Name = "Tefal CY625D32",
                        Description = "Готовьте любимые блюда в разы быстрее вместе с мультиваркой-скороваркой Tefal CY625D32. 66 автоматических программ. Мультиварка автоматически сбрасывает давление. Автоматически подогревает блюда - не нужно следить за процессом. А для мяса и разного типа ингредиентов предусмотрены специальные программы работы под давлением. Чаша сферической формы обеспечивает оптимальную циркуляцию горячего воздуха для равномерного приготовления любого блюда. Вкус блюд получается как из русской печи.",
                        Image = "https://c.dns-shop.ru/thumb/st1/fit/500/500/055fa0bc9842cf9d71b37b91df65df6a/0fdbd0c7197997aae705fbbeff9d1fe2b19102e68febcaf682dcac29e047a1f0.png.webp",
                        Price = 22999,
                        Category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },new Items() {
                        Id = 5,
                        Name = "MOULINEX CE5A0F32",
                        Description = "Мультиварка-скороварка Moulinex CE5A0F32 в привлекательном черно-золотистом корпусе станет настоящей помощницей на кухне. Она позволит приготовить кашу к утреннему завтраку за счет опции отложенного старта, сварить суп или потушить второе, пока вас нет дома. Для этого модель мощностью 1000 Вт имеет 21 встроенную программу с всевозможными рецептами. Выбрать необходимое время работы для того или иного продукта можно вручную.",
                        Image = "https://c.dns-shop.ru/thumb/st4/fit/500/500/86e38b96f196d8a6a44e2b07d080bd5b/cde836b55a6bab37eb5d0d38d85bbacf9c7f8af4aa92d871f583de325ab20904.jpg.webp",
                        Price = 9499,
                        Category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                };
            }
        }
    }
}
