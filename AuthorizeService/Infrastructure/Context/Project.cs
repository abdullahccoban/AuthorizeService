using System;
using System.Collections.Generic;

namespace AuthorizeService.Infrastructure.Context;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
