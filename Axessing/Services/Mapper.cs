using AutoMapper;
using Axessing.Models.Resource.ViewModels;
using Axessing.Models.Schema;

namespace Axessing.Services;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Ticket, Ticket>();
        CreateMap<Ticket, TicketViewModel>();
    }
}