using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.TrainerViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Classes;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    internal class TrainerService : ITrainerService
    {
        private readonly IUniteOfWork _unitOfWork;
        TrainerService(IUniteOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }
        public bool CreateTrainer(CreateTrainerViewModel createTrainer)
        {
            try
            {
                var Repo = _unitOfWork.GetRepository<Trainer>();
                if (isEmailExists(createTrainer.Email) || isPhoneExists(createTrainer.Phone)) return false;

                var Trainer = new Trainer()
                {
                    Name = createTrainer.Name,
                    Email = createTrainer.Email,
                    Phone = createTrainer.Phone,
                    Gender = createTrainer.Gender,
                    specialities = createTrainer.Specialities,
                    DateOfBirth = createTrainer.DateOfBirth,
                    Address = new Address()
                    {
                        street = createTrainer.Street,
                        city = createTrainer.City,
                        BuildingNumber = createTrainer.BuildingNumber,
                    }
                };
                Repo.Add(Trainer);
                return _unitOfWork.SaveChanges()>0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var Trainers = _unitOfWork.GetRepository<Trainer>().GetAll();
            if (Trainers is null || !Trainers.Any()) return [];
            return Trainers.Select(X => new TrainerViewModel()
            {
                Name = X.Name,
                Email = X.Email,
                Phone = X.Phone,
                Id = X.Id,
                Specialities = X.specialities.ToString(),
            });
        }

        public TrainerViewModel? GetTrainerDetails(int trainerId)
        {
            var Trainer = _unitOfWork.GetRepository<Trainer>().GetById(trainerId);
            if (Trainer is null) return null;
            return new TrainerViewModel()
            {
                Name = Trainer.Name,
                Email = Trainer.Email,
                Phone = Trainer.Phone,
                Specialities = Trainer.specialities.ToString(),
            };

        }

        public TrainerToUpdateViewModel? GetTrainerToUpdate(int trainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(trainerId);
            if (trainer is null) return null;
            return new TrainerToUpdateViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                City = trainer.Address.city,
                Street = trainer.Address.street,
                BuildingNumber = trainer.Address.BuildingNumber,
                Specialities = trainer.specialities,
            };
        }

        public bool RemoveTrainer(int trainerId)
        {
            var Repo = _unitOfWork.GetRepository<Trainer>();
            var trainerToRemove = Repo.GetById(trainerId);
            if (trainerToRemove is null || HasActiveSessions(trainerId)) return false;
            Repo.Delete(trainerToRemove);
            return _unitOfWork.SaveChanges()>0;
        }

        public bool UpdateTrainerDatails(int trainerId, TrainerToUpdateViewModel trainerToUpdate)
        {
            var repo = _unitOfWork.GetRepository<Trainer>();
            var Trainertoupd = repo.GetById(trainerId);
            if(Trainertoupd is null || isEmailExists(trainerToUpdate.Email) || isPhoneExists(trainerToUpdate.Phone)) return false;

            Trainertoupd.Name = trainerToUpdate.Name;
            Trainertoupd.Phone = trainerToUpdate.Phone;
            Trainertoupd.Address.BuildingNumber = trainerToUpdate.BuildingNumber;
            Trainertoupd.Address.city = trainerToUpdate.City;
            Trainertoupd.Address.street = trainerToUpdate.Street;
            Trainertoupd.specialities = trainerToUpdate.Specialities;
            Trainertoupd.UpdatedAt=DateTime.Now;
            repo.Update(Trainertoupd);
            return _unitOfWork.SaveChanges()<0;
        }
        #region healper methods
        private bool isEmailExists(string Email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(X => X.Email == Email).Any();
        }
        private bool isPhoneExists(string Phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(X => X.Phone == Phone).Any();
        }
        private bool HasActiveSessions(int trainerId)
        {
            return _unitOfWork.GetRepository<Session>().GetAll(X => X.TrainerId == trainerId && X.StartDate <DateTime.Now && X.EndDate>DateTime.Now).Any();
        }


        #endregion
    }
}
