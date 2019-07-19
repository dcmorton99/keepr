using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repository
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeeps GetById(int id)
    {
      string query = "SELECT * FROM vaultkeeps WHERE id = @id";
      VaultKeeps data = _db.QueryFirstOrDefault<VaultKeeps>(query, new { id });
      if (data == null) throw new Exception("Invalid Id");
      return data;
    }

    public object Create(VaultKeeps value)
    {
      string query = @"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
             VALUES(@VaultId, @KeepId, @UserId);
             SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public object Update(VaultKeeps value)
    {
      throw new NotImplementedException();
    }

    public object Delete(int id)
    {
      string query = "DELETE FROM vaultkeeps WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted VaultKeep";
    }
  }
}