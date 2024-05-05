using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;

public record AppointmentDeletedNotification(string FCM_Key) : INotification;