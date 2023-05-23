using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class Teacher
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int Account { get; set; }

    public virtual Account AccountNavigation { get; set; } = null!;

    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
}
