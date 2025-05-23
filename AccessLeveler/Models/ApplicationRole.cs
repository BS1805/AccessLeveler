﻿using Microsoft.AspNetCore.Identity;
using System;

namespace AccessLeveler.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base() { }
    public ApplicationRole(string roleName) : base(roleName) { }
}