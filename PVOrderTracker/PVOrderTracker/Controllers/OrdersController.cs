using Microsoft.AspNetCore.Mvc;
using OrderTracker.Data;
using PVOrderTracker.Models;

public class OrdersController : Controller
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ Helper method to check login
    private bool IsLoggedIn()
    {
        return HttpContext.Session.GetString("User") == "admin";
    }

    public IActionResult Index()
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        var orders = _context.Orders.ToList();
        return View(orders);
    }

    public IActionResult Create()
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        _context.Orders.Add(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        var order = _context.Orders.Find(id);
        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        _context.Orders.Update(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        if (!IsLoggedIn())
            return RedirectToAction("Login", "Account");

        var order = _context.Orders.Find(id);
        _context.Orders.Remove(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
