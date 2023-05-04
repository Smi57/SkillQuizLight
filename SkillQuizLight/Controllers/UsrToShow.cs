using System;
using System.Collections.Generic;

namespace SkillQuizLight.Models;

public partial class UsrToShow
{
    public string LoginTxt { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Comment { get; set; }

}

