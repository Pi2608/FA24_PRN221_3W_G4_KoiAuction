﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiAuction.Repositories.Models;

public partial class Auction
{
    public int Id { get; set; }

    public int GroupKoiId { get; set; }

    public int FarmId { get; set; }

    public int? WinnerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? Endtime { get; set; }

    public string AuctionMethod { get; set; }

    public decimal? StartingPrice { get; set; }

    public decimal? WinningPrice { get; set; }

    public decimal? MinIncrement { get; set; }

    public decimal? MinPrice { get; set; }

    public int? StepTimeDown { get; set; }

    public int? StepDecrease { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual KoiFarm Farm { get; set; }

    public virtual GroupKoi GroupKoi { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User Winner { get; set; }
}