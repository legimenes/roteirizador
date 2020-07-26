using FluentValidation;
using Roteirizador.Domain.Models;
using Roteirizador.Domain.Repositories;

namespace Roteirizador.Domain.Validators
{
    public interface IUFValidator : IValidator<UF> { }
    public class UFValidator : AbstractValidator<UF>, IUFValidator
    {
        protected const string SalvarRuleSet = "Salvar";

        public UFValidator(IUFRepository ufRepository)
        {
            RuleSet("Salvar", () => SalvarAction());
            RuleSet("Excluir", () => ExcluirAction());
        }

        protected void ExcluirAction()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("O Id é inválido.");
        }
        protected void SalvarAction()
        {
            RuleFor(v => v.Sigla).NotEmpty().WithMessage("Sigla é informação obrigatória.");
            RuleFor(v => v.Nome).NotEmpty().WithMessage("Nome é informação obrigatória.");
        }
    }
}