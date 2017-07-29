using MM.DataLayer;
using MM.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.BusinessLayer.Admin
{
    public class CashTransactionBL
    {

        public List<CashTransactionDTO> GetCashTransaction()
        {
            var lstCashTran = new List<CashTransactionDTO>();
            using (var entities = new ManiMotorsEntities1())
            {
                lstCashTran = (from bat in entities.CashTransactions
                                  select new CashTransactionDTO
                                  {
                                      CashTransactionID = bat.CashTransactionID,
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

            return lstCashTran;
        }

        public bool AddCashTransaction(CashTransactionDTO baDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = new CashTransaction()
                    {
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
                    entities.CashTransactions.Add(bTran);
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

        public bool UpdateCashTransaction(CashTransactionDTO baDTO)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = entities.CashTransactions.FirstOrDefault(g => g.CashTransactionID == baDTO.CashTransactionID);

                    bTran.CashTransactionID = baDTO.CashTransactionID;
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

        public bool DeleteCashAccountTransaction(int banTranId)
        {
            var flag = true;
            try
            {
                using (var entities = new ManiMotorsEntities1())
                {
                    var bTran = entities.CashTransactions.FirstOrDefault(g => g.CashTransactionID == banTranId);

                    entities.CashTransactions.Remove(bTran);
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

    }
}
