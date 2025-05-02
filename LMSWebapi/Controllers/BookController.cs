
using Microsoft.AspNetCore.Mvc;
//we have to add the NewtonSoft and JsonPatch packages in order to use Patch method
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace LMS
{
   [ApiController]
   [Route("[Controller]")]
   public class BookController : ControllerBase
   {
      Library libraryObject;
      public BookController(Library libraryObj)
      {
         this.libraryObject = libraryObj;
      }
      [HttpGet]
      [Produces("application/xml")]
      public IActionResult GetAllBooks()
      {
         List<Book> result = libraryObject.Display();
         if (result == null)
         {
            return BadRequest("Empty Library");
         }
         else
         {
            return Ok(result);
         }
      }


      [HttpGet("ID/{id:int}")]
      public IActionResult GetById(int ID)
      {
         Book existedBook = libraryObject.DisplayByID(ID);
         return (existedBook == null) ? NotFound("Book not found with given id") : Ok(existedBook);
      }

      [HttpGet("Author/{Author:alpha}")]
      public IActionResult GetByAuthor(string Author)
      {
         List<Book> booksWithGivenAuthor = libraryObject.DisplayByAuthor(Author);
        
         return booksWithGivenAuthor==null?NotFound("No books with the given Author name or empty library"):Ok(booksWithGivenAuthor);
       
      }


      [HttpGet("Genre/{Genre:alpha}")]
      public IActionResult GetByGenre(string Genre)
      {
         List<Book> booksWithGivenGnere = libraryObject.DisplayByGenre(Genre);
         return booksWithGivenGnere==null?NotFound("No books with the given Genre name or empty library"):Ok(booksWithGivenGnere);
      }


      [HttpGet("Published_Year/{Published_Year:int}")]
      public IActionResult GetByPublished_Year(int Published_Year)
      {
         List<Book> booksWithGivenPublished_Year = libraryObject.DisplayByPublished_Year(Published_Year);
         return booksWithGivenPublished_Year==null?NotFound("No books with the given year or empty library"):Ok(booksWithGivenPublished_Year);
      }

      [HttpGet("SortBy/{sortByProperty:alpha}")]
      public IActionResult Sort(string sortByProperty)
      {
         List<Book> SortedList = libraryObject.Sort(sortByProperty);
         return SortedList == null?BadRequest("Empty library"):Ok(SortedList);
      }

      [HttpHead]
      public IActionResult GetResourceDetails(int id)
      {
         Book BookExsits= libraryObject.DisplayByID(id);
         return Ok(BookExsits);
      }
      
      [HttpPost]
      public void Post(string title, string authorName, string genre, int Published_Year)
      {
         libraryObject.Add(title, authorName, genre, Published_Year);
      }

      [HttpPut]
      public IActionResult Put(int bookIdtoUpdate, [FromBody] Book book)
      {
         bool isBookExists = libraryObject.Update(bookIdtoUpdate, book);
         return isBookExists ? Ok("put successful") : NotFound("NO BOOK WITH THE PROVIDED ID");
      }

      [HttpDelete]
      public IActionResult Delete(int bookIdToDelete)
      {
         bool isBookDeleted = libraryObject.Remove(bookIdToDelete);
         return isBookDeleted ? Ok("Deletion successful") : NotFound("NO BOOK WITH THE PROVIDED ID");
      }
      
      [HttpPatch]
      public IActionResult Patch(int bookIdtoUpdate,[FromBody]JsonPatchDocument<Book> book)
      {
             Book existingBook=libraryObject.DisplayByID(bookIdtoUpdate);
             if(existingBook !=null) 
             {
                 book.ApplyTo(existingBook,ModelState);
                if (!TryValidateModel(book))
               {
                  return BadRequest(ModelState);
               }
                return Ok("errors"); 
             }
             
            return BadRequest("Book with the given not found");
      }
   }
}
