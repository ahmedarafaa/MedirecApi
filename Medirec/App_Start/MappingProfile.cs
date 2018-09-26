using AutoMapper;
using Medirec.Models;
using Medirec.Dtos;

namespace MediRec.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Doctors, DoctorsDtoSearch>();
            Mapper.CreateMap<Patients, PatientsDto>();
            Mapper.CreateMap<Allergies, AllergiesDto>();
            Mapper.CreateMap<Condations, CondationsDto>();
            Mapper.CreateMap<HumanBody, HumanBodyDto>();
            Mapper.CreateMap<BloodPressure, BloodPressureDto>();
            Mapper.CreateMap<Medications, MedicationsDto>();
            Mapper.CreateMap<MedicalDevices, MedicalDevicesDto>();
            Mapper.CreateMap<Resources, ResourcesDto>();
            Mapper.CreateMap<Contacts, ContactsDto>();
            Mapper.CreateMap<Vaccines, VaccinesDto>();
            Mapper.CreateMap<Immunizations, ImmunizationsDto>();
            Mapper.CreateMap<Countries, CountriesDto>();
            Mapper.CreateMap<Cities, CitiesDto>();
            Mapper.CreateMap<Areas, AreasDto>();
            Mapper.CreateMap<Specialties, SpecialtiesDto>();
            Mapper.CreateMap<Calenders, CalendersDto>();
            Mapper.CreateMap<CalendersDetails, CalendersDetailsDto>();

            //Dto to Domain 

            Mapper.CreateMap<DoctorsDtoSearch, Doctors>();
            Mapper.CreateMap<PatientsDto, Patients>();
            Mapper.CreateMap<AllergiesDto, Allergies>();
            Mapper.CreateMap<CondationsDto, Condations>();
            Mapper.CreateMap<HumanBodyDto, HumanBody>();
            Mapper.CreateMap<BloodPressureDto, BloodPressure>();
            Mapper.CreateMap<MedicationsDto, Medications>();
            Mapper.CreateMap<MedicalDevicesDto, MedicalDevices>();
            Mapper.CreateMap<ResourcesDto, Resources>();
            Mapper.CreateMap<ContactsDto, Contacts>();
            Mapper.CreateMap<VaccinesDto, Vaccines>();
            Mapper.CreateMap<ImmunizationsDto, Immunizations>();
            Mapper.CreateMap<CountriesDto, Countries>();
            Mapper.CreateMap<CitiesDto, Cities>();
            Mapper.CreateMap<AreasDto, Areas>();
            Mapper.CreateMap<SpecialtiesDto, Specialties>();
            Mapper.CreateMap<CalendersDto, Calenders>();
            Mapper.CreateMap<CalendersDetailsDto, Calenders>();

        }

    }
}