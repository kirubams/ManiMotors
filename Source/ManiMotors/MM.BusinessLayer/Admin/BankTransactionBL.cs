using MM.DataLayer;
using MM.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class BankTransactionBL
    {
        public List<BankAccountTransactionDTO> GetBankAccountTransaction()
        {
            var lstBankActTran = new List<BankAccountTransactionDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                lstBankActTran = (from bat in entities.BankAccountTransactions
                                  join bt in entities.BankAccountTypes on bat.BankAccountTypeID equals bt.BankAccountTypeID
                                  select new BankAccountTransactionDTO
                                  {
                                      BankAccountTransactionID = bat.BankAccountTransactionID,
                                      BankAccountTypeID = bat.BankAccountTypeID,
                                      BankAccountTypeDescription = bt.Description,
                                      TransactionType = bat.TransactionType,
                                      Amount = bat.Amount,
                                      TransactionDate = bat.TransactionDate,
                                      Description = bat.Description,
                                      CreatedBy = bat.Createdby,
                                      CreatedDate = bat.CreatedDate,
                                      ModifiedBy = bat.Modifiedby,
                                      ModifiedDate = bat.ModifiedDate,
                                      Type = bat.Type,
                                  }
                                    ).ToList();
            }

            return lstBankActTran;
        }

        public bool AddBankAccountTransaction(BankAccountTransactionDTO baDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = new BankAccountTransaction()
                    {
                        BankAccountTypeID = baDTO.BankAccountTypeID,
                        TransactionType = baDTO.TransactionType,
                        Amount = baDTO.Amount,
                        Description = baDTO.Description,
                        TransactionDate = baDTO.TransactionDate,
                        CreatedDate = baDTO.CreatedDate,
                        Createdby = baDTO.CreatedBy,
                        Modifiedby = baDTO.ModifiedBy,
                        ModifiedDate = baDTO.ModifiedDate,
                        Type = baDTO.Type,
                    };
                    entities.BankAccountTransactions.Add(bTran);
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool UpdateBankAccountTransaction(BankAccountTransactionDTO baDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = entities.BankAccountTransactions.FirstOrDefault(g => g.BankAccountTransactionID == baDTO.BankAccountTransactionID);

                    bTran.BankAccountTransactionID = baDTO.BankAccountTransactionID;
                    bTran.BankAccountTypeID = baDTO.BankAccountTypeID;
                    bTran.TransactionType = baDTO.TransactionType;
                    bTran.Amount = baDTO.Amount;
                    bTran.TransactionDate = baDTO.TransactionDate;
                    bTran.Description = baDTO.Description;
                    bTran.CreatedDate = baDTO.CreatedDate;
                    bTran.Createdby = baDTO.CreatedBy;
                    bTran.Modifiedby = baDTO.ModifiedBy;
                    bTran.ModifiedDate = baDTO.ModifiedDate;
                    bTran.Type = baDTO.Type;
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public bool DeleteBankAccountTransaction(int banTranId)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = entities.BankAccountTransactions.FirstOrDefault(g => g.BankAccountTransactionID == banTranId);

                    entities.BankAccountTransactions.Remove(bTran);
                    entities.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }

            return flag;

        }

        public List<BankAccountTypeDTO> GetBankAccountType()
        {
            List<BankAccountTypeDTO> lst = new List<BankAccountTypeDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                lst = (from bt in entities.BankAccountTypes
                       select new BankAccountTypeDTO
                       {
                            BankAccountTypeID = bt.BankAccountTypeID,
                            BankAccountTypeDescription = bt.Description,
                       }).ToList();
            }
            return lst;
        }
    }
}
