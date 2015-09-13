using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.PhoneCommands;

namespace CoachingPlan.ApplicationService
{
    public class PhoneApplicationService : BaseApplicationService, IPhoneApplicationService
    {
        private IPhoneRepository _repository;

        public PhoneApplicationService(IPhoneRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Phone Create(CreatePhoneCommand command)
        {
            var phone = new Phone(command.DDD, command.Number, command.IdPerson, command.Description);
            phone.Validate();
            _repository.Create(phone);

            if (Commit())
                return phone;

            return null;
        }

        public Phone Delete(Guid id)
        {
            var phone = _repository.GetOne(id);
            _repository.Delete(phone);

            if (Commit())
                return phone;

            return null;
        }

        public List<Phone> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Phone> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Phone GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Phone GetOnebyPerson(Guid idPerson)
        {
            return _repository.GetOnebyPerson(idPerson);
        }
        public Phone Update(ChangePhoneCommand command)
        {
            var phone = _repository.GetOne(command.Id);
            if (command.DDD != null)
                phone.ChangeDDD(command.DDD);
            if (command.Number != null)
                phone.ChangeNumber(command.Number);
            if (command.Description != null)
                phone.ChangeDescription(command.Description);

            _repository.Update(phone);

            if (Commit())
                return phone;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
