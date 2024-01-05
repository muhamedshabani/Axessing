using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Axessing.Models.Schema;

public class Attachment
{
    public Attachment()
    {
        AttachmentName = AttachmentName ?? string.Empty;
    }

    [Key]
    public int Id { get; set; }
    public string AttachmentName { get; set; }
    public byte[] Data { get; set; } = new byte[10000000]; // maxsize: 10mb 

    // Relationship
    public int TicketId { get; set; }
    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = new Ticket();
}
