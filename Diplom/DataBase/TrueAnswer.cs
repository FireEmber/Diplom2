using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class TrueAnswer
{
    public int Id { get; set; }

    public string TrueAnswer1 { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
