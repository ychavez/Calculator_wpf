﻿using System;
using System.Collections.Generic;

namespace Calculator_wpf.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public int MyProperty { get; set; }
    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
