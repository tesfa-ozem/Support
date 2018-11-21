using System;
using Support.Models;
using Support.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace Support.Repository
{
    public class Repo
    {
        UhcContext _context = new UhcContext();
        public PaymentModel GetAllPaymentsAsync()
        {
            try
                {
                var Payments = from s in _context.Payments
                select s;
                 return new PaymentModel()
                {
                    ListOfPayments = Payments.ToList(),
                    Message = " Succesfull"
                };
                }
                catch (Exception e)
                {
                    
                    return new PaymentModel()
                {
                    ListOfPayments = null,
                    Message = e.Message.ToString()
                };
                }
        }
        public void InsertAgent(AppUsers appUsers)
        {
            try
            {
                _context.AppUsers.Add(appUsers);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        public void UpdatePayments(PaymentViewModel payments)
        {
            var entity = _context.Payments.FirstOrDefault(p=>p.Id == payments.Id);
                if(entity!=null)
                {
                   entity.MemberNo = payments.AccountNo;
                   entity.AccountNo = payments.AccountNo;
                   entity.DocumentNo = payments.DocumentNo;
                   entity.PaymentName = payments.PaymentName;
                   entity.PhoneNo = payments.PhoneNo;
                   _context.Payments.Update(entity);
                   _context.SaveChanges();

                }
        }
        public string CreatePayment(PaymentViewModel payments)
        {
            try
            {
                var NewPayment = new Payments()
                {
                    PaymentMode = "Mpesa",
                    PaymentType = "Mpesa",
                    MemberNo = payments.AccountNo,
                    PhoneNo = payments.PhoneNo,
                    AccountNo = payments.AccountNo,
                    Amount = 1100,
                    Status = 1,
                    DocumentNo = payments.DocumentNo,
                    Description = "Created Manualy",
                    PaymentDate = payments.PaymentDate,
                    TransactionDate = payments.PaymentDate,
                    DateModified = payments.PaymentDate

                    


                };
                _context.Add(NewPayment);
                _context.SaveChanges();
                return "Added";
            }
            catch (Exception e)
            {
                
                return e.Message.ToString();
            }
        }
    }
}