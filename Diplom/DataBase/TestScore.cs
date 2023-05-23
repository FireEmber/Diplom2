using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class TestScore
{
    public int Id { get; set; }

    public int Student { get; set; }

    public int Test { get; set; }

    public int? TestScore1 { get; set; }

    public virtual Student StudentNavigation { get; set; } = null!;

    public virtual Test TestNavigation { get; set; } = null!;
}
