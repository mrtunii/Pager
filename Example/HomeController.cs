using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PaginationExample
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index(int? page)
		{
			var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
			var pager = new Pager(dummyItems.Count(), page);
			
			var viewModel = new IndexViewModel
			{
				Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
				Pager = pager
			};
			
			return View(viewModel);
		}
	}
}