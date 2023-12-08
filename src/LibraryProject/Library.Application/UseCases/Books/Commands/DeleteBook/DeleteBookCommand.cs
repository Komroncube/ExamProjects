using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Books.Commands.DeleteBook;
public class DeleteBookCommand : ICommand<bool>
{
    public int Id { get; set; }
}
