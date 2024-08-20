using BankApi.DataAccess;
using BankApi.Entities;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.ConstrainedExecution;

namespace BankApiFinder.API.Fake
{
    public class FakeDataBranch
    {
        private static readonly List<Branch> _branches = GenerateBranches();
        private static bool _dataGenerated = false;
        private static List<Branch> GenerateBranches()
        {
            var branchFaker = new Faker<Branch>("tr")
                .RuleFor(branch => branch.branch_name, f => f.PickRandom(
                    "Ziraat Bankası",
                    "Halkbank",
                    "VakıfBank",
                    "Garanti BBVA",
                    "İş Bankası",
                    "Yapı Kredi",
                    "Akbank",
                    "QNB Finansbank",
                    "DenizBank",
                    "TEB"))
                .RuleFor(branch => branch.location, f => $"{f.Address.StreetAddress()}, {f.Address.City()}, Türkiye")
                .RuleFor(branch => branch.phone_number, f => f.Phone.PhoneNumberFormat())
                .RuleFor(branch => branch.email, (f, branch) => $"{branch.branch_name.Replace(" ", "")}@gmail.com")
                .RuleFor(branch => branch.status, f => f.PickRandom("Active", "Inactive"));

            var branches = branchFaker.Generate(10); // 10 şube oluştur

            // ID'leri 1'den başlayacak şekilde ayarla
            int id = 1;
            foreach (var branch in branches)
            {
                branch.Id = id++;
            }

            return branches;
        }

        public static List<Branch> GetBranches()
        {
            if (!_dataGenerated)
            {
                using (var context = new BranchDbContext())
                {
                    // Veritabanında şubeler var mı kontrol et
                    if (!context.Branches.Any())
                    {
                        foreach (var branch in _branches)
                        {
                            context.Branches.Add(branch);
                        }
                        context.SaveChanges();
                    }
                }

                _dataGenerated = true;
            }

            return _branches;
        }
    }
}