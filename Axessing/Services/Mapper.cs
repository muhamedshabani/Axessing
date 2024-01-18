using AutoMapper;
using Axessing.Models.Resource.InputModels;
using Axessing.Models.Resource.ViewModels;
using Axessing.Models.Schema;

namespace Axessing.Services;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Ticket, Ticket>();
        CreateMap<Ticket, TicketViewModel>();
        CreateMap<TicketInputModel, Ticket>()
            .ForMember(t => t.Title, opt => opt.MapFrom(t => t.Title))
            .ForMember(t => t.Description, opt => opt.MapFrom(t => t.Description))
            .ForMember(t => t.CreatedDate, opt => opt.MapFrom(t => t.CreatedDate))
            .ForMember(t => t.LastModifiedDate, opt => opt.MapFrom(t => t.LastModifiedDate))
            .ForMember(t => t.WorkspaceId, opt => opt.MapFrom(t => t.WorkspaceId));
        CreateMap<Workspace, Workspace>();
        CreateMap<Workspace, WorkspaceViewModel>();
        CreateMap<WorkspaceInputModel, Workspace>();
    }
}