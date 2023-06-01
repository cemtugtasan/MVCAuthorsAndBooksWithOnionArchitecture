using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcOnion.Application.Dtos.AuthorDtos;
using MvcOnion.Application.Dtos.BookDtos;
using MvcOnion.Application.IServices;
using MvcOnion.Presentation.ViewModels.AuthorVms;

namespace MvcOnion.Presentation.Controllers
{
	public class AuthorController : Controller
	{
		private readonly IAuthorService _authorService;
		private readonly IBookService _bookService;

		public AuthorController(IBookService bookService, IAuthorService authorService)
		{
			_authorService = authorService;
			_bookService = bookService;
		}

		// GET: AuthorController
		public async Task<IActionResult> Index()
		{
			List<AuthorListVm> authorlist = _authorService.AuthorList()
											.Result.Select(author => new AuthorListVm(author)).ToList();

			return View(authorlist);
		}

		// GET: AuthorController/Details/5
		public async Task<IActionResult> Details(int id)
		{
			AuthorCreateDto authorCreateDto = await _authorService.GetByAuthorId(id);
			List<BooklistDto> booklistDtos = _bookService.GetBooksByAuthorId(id).Result.ToList();
			return View(new AuthorDetailVm(authorCreateDto, booklistDtos));
		}

		// GET: AuthorController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AuthorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(AuthorCreateDto authorCreateDto, IFormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var bookList = collection["book"].ToList();
					bool authorCreate = await _authorService.AuthorCreate(authorCreateDto);

					if (authorCreate && bookList.Count() > 0)
					{
						int authorId = await _authorService.GetIdByAuthorNameAndLastName(authorCreateDto.FirstName, authorCreateDto.LastName);

						List<BookCreateDto> bookCreateDtos = bookList.Select(bookName => new BookCreateDto
						{
							BookName = bookName,
							AuthorId = authorId,
						}).ToList();

						bool bookCreateRange = await _bookService.BookCreateRange(bookCreateDtos);

						if (!bookCreateRange)
						{
							return View(authorCreateDto);
						}
					}
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(authorCreateDto);
			}
		}

		// GET: AuthorController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AuthorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AuthorController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AuthorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
