using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.PhoneCommands;
using CoachingPlan.Domain.Contracts.Services;

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
            var phone = new Phone(command.DDD, command.Number, command.Description);
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
            if (!string.IsNullOrEmpty(command.DDD))
                phone.ChangeDDD(command.DDD);
            if (!string.IsNullOrEmpty(command.Number))
                phone.ChangeNumber(command.Number);
            if (!string.IsNullOrEmpty(command.Description))
                phone.ChangeDescription(command.Description);

            _repository.Update(phone);

            if (Commit())
                return phone;

            return null;
        }
        public List<Phone> AddToPerson(dynamic body)
        {
            List<Phone> listPhone = new List<Phone>();
            foreach (var item in body)
            {
                if ((item.number != null) || (item.number != ""))
                {
                    if (item.id != null)
                        listPhone.Add(Update(new ChangePhoneCommand(
                            Guid.Parse((string)item.id),
                            (string)item.ddd,
                            (string)item.number,
                            (string)item.description
                            )));
                    else
                        listPhone.Add(new Phone(
                            (string)item.ddd,
                            (string)item.number,
                            (string)item.description
                            ));
                }
            }
            return listPhone;
        }

        public void CheckPhoneRemoved(List<Phone> listPhone, Guid idPerson)
        {
            var oldList = _repository.GetAllbyPerson(idPerson);
            foreach (var phone in oldList)
            {
                if (!listPhone.Contains(phone))
                {
                    _repository.Delete(phone);
                }
            }
        }
        public void Dispose()
        {
            _repository = null;
        }

    }
}
