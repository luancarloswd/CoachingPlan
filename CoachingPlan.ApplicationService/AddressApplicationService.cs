using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.AddressCommands;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.ApplicationService
{
    public class AddressApplicationService : BaseApplicationService, IAddressApplicationService
    {
        private IAddressRepository _repository;

        public AddressApplicationService(IAddressRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Address Create(CreateAddressCommand command)
        {
            var Address = new Address(command.CEP, command.State, command.City, command.Street, command.Number, command.Type, command.Description );
            Address.Validate();
            _repository.Create(Address);

            if (Commit())
                return Address;

            return null;
        }
        public List<Address> AddToPerson(dynamic body)
        {
            List<Address> listAddress = new List<Address>();
            foreach (var item in body)
            {
                if ((item.city != null) || (item.city != ""))
                {
                    if (item.id != null)
                        Update(new ChangeAddressCommand(
                            Guid.Parse((string)item.id),
                            (string)item.cep,
                            (EStates)item.state,
                            (string)item.city,
                            (string)item.street,
                            (int)item.number,
                            (EAddressType)item.type,
                            (string)item.description));
                    else
                        listAddress.Add(new Address(
                            (string)item.cep,
                            (EStates)item.state,
                            (string)item.city,
                            (string)item.street,
                            (int)item.number,
                            (EAddressType)item.type,
                            (string)item.description)
                            );
                }
            }
            return listAddress;

        }

        public Address Delete(Guid id)
        {
            var Address = _repository.GetOne(id);
            _repository.Delete(Address);

            if (Commit())
                return Address;

            return null;
        }

        public List<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Address> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Address GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Address GetOnebyPerson(Guid idPerson)
        {
            return _repository.GetOneByPerson(idPerson);
        }
        public Address Update(ChangeAddressCommand command)
        {
            var address = _repository.GetOne(command.Id);
            if(command.CEP != null)
                address.ChangeCEP(command.CEP);
            if (command.City != null)
                address.ChangeCity(command.City);
            if (command.Description != null)
                address.ChangeDescription(command.Description);
            if (command.Number != 0)
                address.ChangeNumber(command.Number);
            address.ChangeState(command.State);
            if(command.Street != null)
                address.ChangeStreet(command.Street);
            address.ChangeType(command.Type);

            _repository.Update(address);

            if (Commit())
                return address;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
