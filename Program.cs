namespace DeterminationOfExpiration;
class Program
{
    static void Main(string[] args)
    {
        List<Stew> stews = new List<Stew>
        {
            new Stew("Хрустящие ножки Алессы", 2023, 3),
            new Stew("Шепард в собственном соку", 2001, 5),
            new Stew("Масте Шеф с хитином", 2009, 10),
            new Stew("Мясо гусениц от Алисы", 2021, 1),
            new Stew("Черепашки Марио", 1989, 35),
            new Stew("Зерглинг без костей", 2018, 2)
        };

        Shop shop = new Shop(stews);
        
        Console.WriteLine("Список всей тушёнки:\n");
        shop.ShowInfo();
        
        Console.WriteLine("\nСписок просроченной тушёнки:\n");
        shop.ShowExpiredStews();
    }
}

class Stew
{
    public Stew(string name, int productionYearint, int expirationYear)
    {
        Name = name;
        ProductionYear = productionYearint;
        BestBeforeDate = expirationYear;
    }
    
    public string Name { get; private set; }
    public int ProductionYear { get; private set; }
    public int BestBeforeDate { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}. Год производства: {ProductionYear}. Срок годности: {BestBeforeDate}.");
    }
}

class Shop
{
    private List<Stew> _stews;

    public Shop(List<Stew> stews)
    {
        _stews = stews;
    }

    public void ShowExpiredStews()
    {
        int currentYear = DateTime.Now.Year;
        
        var expiredStews = _stews.Where(stew => stew.ProductionYear + stew.BestBeforeDate < currentYear)
            .ToList();

        foreach (Stew stew in expiredStews)
            stew.ShowInfo();
    }

    public void ShowInfo()
    {
        foreach (Stew stew in _stews)
            stew.ShowInfo();
    }
}
