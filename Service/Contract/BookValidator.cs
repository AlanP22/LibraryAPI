using FluentValidation;
using LibraryAPI.Controllers;

namespace LibraryAPI.Service.Contract
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Id).NotNull();
            RuleFor(b => b.Title).NotNull().WithMessage("Title is required.")
                                 .Length(0, 100).WithMessage("Title can be up to 100 characters long.");
            RuleFor(b => b.Description).NotNull().WithMessage("Describiton is required.");
            RuleFor(b => b.Rating).NotNull().WithMessage("Rating is required.")
                                  .InclusiveBetween(1,10).WithMessage("Rating must be in range between 1 to 10");
            RuleFor(b => b.Isbn).NotNull().WithMessage("ISBN number is required.")
                                .Length(13).WithMessage("ISBN must be 13 digits long.")
                                .Matches("-0123456789").WithMessage("ISBN must be in specified format: XXX-XXXXXXXXXX or only numbers.");
            RuleFor(b => b.PublicationDate).NotNull().WithMessage("Publication Date is required.");
                                 
        }
    }
}
