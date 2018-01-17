﻿namespace Tangle.Net.Source.DataTransfer
{
  using Tangle.Net.Source.Entity;

  /// <summary>
  /// The transactions to approve.
  /// </summary>
  public class TransactionsToApprove
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the branch transaction.
    /// </summary>
    public Hash BranchTransaction { get; set; }

    /// <summary>
    /// Gets or sets the trunk transaction.
    /// </summary>
    public Hash TrunkTransaction { get; set; }

    #endregion
  }
}