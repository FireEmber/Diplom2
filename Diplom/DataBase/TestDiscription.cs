using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class TestDiscription
{
    public int Id { get; set; }

    public string Discription { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
