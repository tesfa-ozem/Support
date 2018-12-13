using System;
using Support.Models;
using Support.Persistence;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Support.Repository
{
    public class Repo
    {
        UhcContext _context = new UhcContext();
        public static string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return ("FSA"+result.ToString());
        }
        public async Task<PaymentModel> GetAllPaymentsAsync(PaginationArg arg)
        {
            try
                {
                if (arg.searchString != null)
                {
                    arg.page = 1;
                }
                else
                {
                    arg.searchString = arg.currentFilter;
                }
                var Payments = from s in _context.Payments
                select s;
                if (!String.IsNullOrEmpty(arg.searchString))
                {
                    Payments = Payments.Where(s => s.DocumentNo.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.PhoneNo.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.AccountNo.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.PaymentName.ToUpper().Contains(arg.searchString.ToUpper()));
                               
               
                }
                    
                int pageSize = 5;
                return  new PaymentModel()
                {
                    ListOfPayments = await PaginatedList<Payments>.CreateAsync(Payments, arg.page ?? 1, pageSize),
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
                    PaymentName = payments.PaymentName,
                    Amount = 1100,
                    Status = 1,
                    DocumentNo = payments.DocumentNo,
                    Description = "Created Manualy",
                    TransactionDate = payments.PaymentDate,
                    PaymentDate = payments.PaymentDate,
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
        public PaymentModel readExcelPackageToStringBulk(ExcelPackage package, ExcelWorksheet worksheet,DateTime dateTime)
        {
            try
            {

                UhcContext _context = new UhcContext();
                var rowCount = worksheet.Dimension?.Rows;
                var colCount = worksheet.Dimension?.Columns;

                if (!rowCount.HasValue || !colCount.HasValue)
                {
                    return new PaymentModel()
                    {
                        Message = "No file"
                    };
                }
                List<Payments> FsaPayments = new List<Payments>();
                List<Payments> Existing = new List<Payments>();
                var sb = new StringBuilder();
                for (int row = 3; row <= rowCount.Value; row++)
                {
                   
                    try
                    {
                        Payments payments = new Payments()
                        {
                            PaymentName = worksheet.Cells[row, 2].Value.ToString(),
                            AccountNo = worksheet.Cells[row, 3].Value.ToString(),
                            MemberNo = worksheet.Cells[row, 3].Value.ToString(),
                            PhoneNo = (worksheet.Cells[row, 4].Value==null)?null: worksheet.Cells[row, 4].Value.ToString(),
                            PaymentType = "Cheque",
                            PaymentMode = "Cheque",
                            Amount = 1100,
                            Status = 1,
                            DocumentNo = GetUniqueKey(5),
                            Description = worksheet.Cells[row, 5].Value.ToString(),
                            TransactionDate = dateTime,
                            PaymentDate = dateTime,
                            DateModified = dateTime

                        };
                        var paymentId = _context.Payments.Where(e => e.AccountNo == payments.AccountNo).FirstOrDefault();

                        if (paymentId==null|| payments.PhoneNo!=null)
                        {
                            FsaPayments.Add(payments);
                        }
                        else
                        {
                            Existing.Add(payments);
                        }
                    }
                    catch (Exception e)
                    {
                        return new PaymentModel()
                        {
                            Message = e.Message.ToString()
                        };

                    }

                  

                }
                _context.Payments.AddRangeAsync(FsaPayments);

                _context.SaveChanges();
                return new PaymentModel()
                {
                    Message = "Sucessfull",
                    Existing = Existing,
                    
                };
            }
            catch (Exception e)
            {

                return new PaymentModel()
                {
                    Message = e.Message.ToString(),
                    

                };

            }
        }
        public async Task<PeopleModel> GetAllPeople(PaginationArg arg)
        {
            try
            {
                List<PeopleViewModel> AllPeople = new List<PeopleViewModel>();
                if (arg.searchString != null)
                {
                    arg.page = 1;
                }
                else
                {
                    arg.searchString = arg.currentFilter;
                }
                var person= from s in _context.People
                select s;
                if (!String.IsNullOrEmpty(arg.searchString))
                {
                    person = person.Where(s => s.IdentificationNo.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.PhoneNumber.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.MemberNo.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.LastName.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.FirstName.ToUpper().Contains(arg.searchString.ToUpper())
                               || s.MiddleName.ToUpper().Contains(arg.searchString.ToUpper()));
                               
               
                }
                    
                int pageSize = 5;
                var GroupOfPeople = await PaginatedList<People>.CreateAsync(person, arg.page ?? 1, pageSize);
                foreach (var item in GroupOfPeople)
                {
                    var OnePerson = new PeopleViewModel()
                    {
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName,
                        IdentificationNo =item.IdentificationNo,
                        PhoneNumber = item.PhoneNumber,
                        DateOfBirth = item.DateOfBirth,
                        PhotoImage = item.PhotoImage,
                        DateCreated = item.DateCreated,
                        ModifiedBy = item.ModifiedBy,
                        MemberNo = item.MemberNo
                    };
                    AllPeople.Add(OnePerson);
                }
                return  new PeopleModel()
                {
                    ListOfPeople = AllPeople,
                    Message = " Succesfull"
                };
                }
                catch (Exception e)
                {
                    
                    return new PeopleModel()
                {
                    ListOfPeople = null,
                    Message = e.Message.ToString()
                };
                }
        }
    }

    public class SearchStr
    {
          public string SearchValue { get; set; }  
    }  
}