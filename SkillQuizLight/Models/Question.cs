using System;
using System.Collections.Generic;

namespace SkillQuizLight.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int Level { get; set; }

    public decimal Weight { get; set; }

    public int? Duration { get; set; }

    public string Comment { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
