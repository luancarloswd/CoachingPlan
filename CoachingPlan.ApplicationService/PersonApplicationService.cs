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
            var Person = new Person(command.Name, command.CPF, command.BirthDate, command.Genre, command.Address, command.Phone, command.Photograph);
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
        public List<Person> GetAllIncludeDetails()
        {
            return _repository.GetAllIncludeDetails();
        }
        public List<Person> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public List<Person> GetAllByNameIncludeCoach(string name)
        {
            return _repository.GetAllByNameIncludeCoach(name);
        }

        public List<Person> GetAllByNameIncludeCoachee(string name)
        {
            return _repository.GetAllByNameIncludeCoachee(name);
        }

        public Person GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public Person GetOneIncludeDetails(Guid id)
        {
            return _repository.GetOneIncludeDetails(id);
        }
        public Person Update(UpdatePersonCommand command)
        {
            Person person = _repository.GetOneIncludeDetails(command.Id);
            if (command.BirthDate != null)
                person.ChangeBirthDate(command.BirthDate);
            if (!string.IsNullOrEmpty(command.Name))
                person.ChangeName(command.Name);
            if (!string.IsNullOrEmpty(command.Photograph))
                person.ChangePhotograph(command.Photograph);


            foreach (var address in command.Address)
            {
                person.AddAddress(address);
            }
            foreach (var phone in command.Phone)
            {
                person.AddPhone(phone);
            }

            _repository.Update(person);

            if (Commit())
                return person;

            return null;
        }

        public Person GetOneByCPF(string cpf)
        {
            return _repository.GetOneByCPF(cpf);
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
