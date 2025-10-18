using System;
using System.Collections.Generic;

namespace AuthorizeService.Infrastructure.Context;

public partial class Role
{
    public int Id { get; set; }

    public string Role1 { get; set; } = null!;

    public int ProjectId { get; set; }

    public bool? IsDefault { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
