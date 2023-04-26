using System;
using System.Collections.Generic;

namespace SkillQuizLight.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public decimal Weight { get; set; }

    public string Comment { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
