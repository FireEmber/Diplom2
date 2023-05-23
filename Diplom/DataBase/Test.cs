using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class Test
{
    public int Id { get; set; }

    public int Discription { get; set; }

    public int Discipline { get; set; }

    public virtual Discipline DisciplineNavigation { get; set; } = null!;

    public virtual TestDiscription DiscriptionNavigation { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<TestScore> TestScores { get; set; } = new List<TestScore>();
}
