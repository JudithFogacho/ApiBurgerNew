using System;
using System.Collections.Generic;

namespace ApiBurgerNew.Data.Models;

public partial class Burguer
{
    public int BurguerId { get; set; }

    public string BurguerName { get; set; } = null!;

    public bool WithCheese { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Promo> Promos { get; set; } = new List<Promo>();
}
