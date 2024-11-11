using System;
using System.Collections.Generic;

namespace ApiBurgerNew.Data.Models;

public partial class Promo
{
    public int PromoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaPromo { get; set; }

    public int BurguerId { get; set; }

    public virtual Burguer Burguer { get; set; } = null!;
}
