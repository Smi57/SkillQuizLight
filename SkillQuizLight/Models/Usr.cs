using System;
using System.Collections.Generic;

namespace SkillQuizLight.Models;

public partial class Usr
{
    public int LoginId { get; set; }

    public string LoginTxt { get; set; } = null!;

    public string Passwordtxt { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Comment { get; set; }

    public int? AccessFailedCount { get; set; }

    public int TypeUserId { get; set; }

    public DateTime? DateCreat { get; set; }

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
