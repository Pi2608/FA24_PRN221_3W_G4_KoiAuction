﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KoiAuction.Repositories.Models;

public partial class KoiFarm
{
    public int Id { get; set; }

    public string FarmName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Location { get; set; }

    public string OwnerName { get; set; }

    public string Phone { get; set; }

    public DateTime? CreateDate { get; set; }

    public double? Wallet { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<GroupKoi> GroupKois { get; set; } = new List<GroupKoi>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}