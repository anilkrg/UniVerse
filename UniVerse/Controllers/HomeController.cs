using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using UniVerse.Model.ViewModel;
using UniVerse.Models;

namespace UniVerse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly List<customer> _customers;
        private readonly List<Loan> _loans;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<customer> customers = GetCustomers();
            return View(customers);
        }


        [HttpPost]
        public async Task<IActionResult> Index(int id, string name, string loanName)
        {
            var filteredCustomers = GetCustomers();

            if (id != 0)
            {
                filteredCustomers = filteredCustomers.Where(c => c.Id == id).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                filteredCustomers = filteredCustomers.Where(c => c.Name.Contains(name)).ToList();
            }

            // Further filtering for loanName if needed

            if (filteredCustomers.Count == 0)
            {
                return View((List<customer>)null);// Or any other action/result for handling no matches
            }

            return View(filteredCustomers);
        }



        private List<customer> GetCustomers()
        {
            return new List<customer>
            {
            new customer { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "1234567890" },
            new customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Phone = "0987654321" },
            new customer { Id = 3, Name = "denn", Email = "denn@example.com", Phone = "0967657421" },
            new customer { Id = 4, Name = "genny", Email = "genny@example.com", Phone = "0977754321" }
            // Add more customers as needed
        };

        }


        private List<Loan> GetLoans()
        {
            return new List<Loan>
            {
             new Loan { LoanId = 1, LoanName = "Home Loan", Fee = "2000", AdharNumber = "1274-5678-9012" },
             new Loan { LoanId = 2, LoanName = "business Loan", Fee = "4000", AdharNumber = "1964-5678-9012" },
             new Loan { LoanId = 3, LoanName = "bike Loan", Fee = "5000", AdharNumber = "1964-5678-9012" },
            new Loan { LoanId = 4, LoanName = "Car Loan", Fee = "1000", AdharNumber = "9320-5432-1098" }
            // Add more customers as needed
        };

        }

































        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
