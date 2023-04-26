using System;
using System.Collections.Generic;

namespace SkillQuizLight.Models;

public partial class UserType
{
    public int UserTypeid { get; set; }

    public string Description { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
