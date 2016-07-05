namespace SeminarMVC.Models
{
    public interface IRestoranFilter
    {
        string Ime { get; }
        string Adresa { get; }
        string CityName { get; }
        int? Zvez { get; }
    }
    
}