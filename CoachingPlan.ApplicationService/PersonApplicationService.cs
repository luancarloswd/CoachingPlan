using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.PersonCommands;

namespace CoachingPlan.ApplicationService
{
    public class PersonApplicationService : BaseApplicationService, IPersonApplicationService
    {
        private IPersonRepository _repository;

        public PersonApplicationService(IPersonRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Person Create(CreatePersonCommand command)
        {
            var Person = new Person(command.Name, command.CPF, command.BirthDate, command.Genre,command.Status, command.Address, command.Phone, command.Photograph);
            Person.Validate();
            _repository.Create(Person);

            if (Commit())
                return Person;

            return null;
        }

        public Person Delete(Guid id)
        {
            var person = _repository.GetOne(id);
            _repository.Delete(person);

            if (Commit())
                return person;

            return null;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Person> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Person GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public Person Update(CreatePersonCommand command)
        {
            var person = _repository.GetOne(command.Id);
            if(command.BirthDate != null)
                person.ChangeBirthDate(command.BirthDate);
            if (command.CPF != null)
                person.ChangeCPF(command.CPF);
            if (command.Name != null)
                person.ChangeName(command.Name);
            if (command.Photograph != null)
                person.ChangePhotograph(command.Photograph);

                person.ChangeStatus(command.Status);

            _repository.Update(person);

            if (Commit())
                return person;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
