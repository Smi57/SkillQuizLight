using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuizLight.Models;

public partial class UsrToShow
{
    public int LoginId { get; set; }
    
    public string LoginTxt { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Comment { get; set; }

}

