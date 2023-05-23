using System;
using System.Collections.Generic;

namespace Diplom.DataBase;

public partial class Question
{
    public int Id { get; set; }

    public string Question1 { get; set; } = null!;

    public string Exirsise { get; set; } = null!;

    public int FalseAnswer { get; set; }

    public int TrueAnswer { get; set; }

    public int? Test { get; set; }

    public virtual FalseAnswer FalseAnswerNavigation { get; set; } = null!;

    public virtual Test? TestNavigation { get; set; }

    public virtual TrueAnswer TrueAnswerNavigation { get; set; } = null!;
}
