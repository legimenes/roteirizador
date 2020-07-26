using System;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Roteirizador.Domain.Core.Models;
using Roteirizador.Domain.Core.Notifications;
using Roteirizador.Domain.Core.Repositories;

namespace Roteirizador.Domain.Core.Services
{
    public abstract class CRUDServiceBase<T> : ServiceBase, ICRUDService<T>
        where T : Entity
    {
        protected readonly IValidator<T> _validator;
        protected readonly ICRUDRepository<T> _repository;

        protected CRUDServiceBase(INotificator notifications,
            IValidator<T> validator,
            ICRUDRepository<T> repository)
        : base(notifications)
        {
            _validator = validator;
            _repository = repository;
        }

        public virtual async Task<T> Salvar(T entity)
        {
            try
            {
                if (_validator != null)
                {
                    ValidationResult validationResult = await _validator.ValidateAsync(entity, ruleSet: "Salvar");
                    if (!validationResult.IsValid) return null;
                }

                if (entity.Id == 0)
                {
                    await _repository.Inserir(entity);
                }
                else
                {
                    await _repository.Alterar(entity);
                }
                
                return entity;
            }
            catch (Exception exception)
            {
                await Notify(exception);
                return null;
            }
        }
        public virtual async Task<bool> Excluir(long id)
        {
            try
            {
                if (id <= 0)
                {
                    await Notify("Id inválido para exclusão");
                    return false;
                }

                T entity = await _repository.Obter(id);

                if (_validator != null)
                {
                    ValidationResult validationResult = await _validator.ValidateAsync(entity, ruleSet: "Excluir");
                    if (!validationResult.IsValid) return false;
                }

                await _repository.Deletar(entity.Id);
                
                return true;
            }
            catch (Exception exception)
            {
                await Notify(exception);
                return false;
            }
        }
    }
}