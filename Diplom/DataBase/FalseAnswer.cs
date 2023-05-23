using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class FalseAnswer
{
    public int Id { get; set; }

    public string FalseAnswer1 { get; set; } = null!;

    public string FalseAnswer2 { get; set; } = null!;

    public string FalseAnswer3 { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
