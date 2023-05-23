using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class Student
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public int Account { get; set; }

    public virtual Account AccountNavigation { get; set; } = null!;

    public virtual ICollection<TestScore> TestScores { get; set; } = new List<TestScore>();
}
