using System;
using System.Collections.Generic;

namespace AuthorizeService.Infrastructure.Context;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
