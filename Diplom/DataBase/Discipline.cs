using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class Discipline
{
    public int Id { get; set; }

    public string Tittle { get; set; } = null!;

    public int Teacher { get; set; }

    public virtual Teacher TeacherNavigation { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
