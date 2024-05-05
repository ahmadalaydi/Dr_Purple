using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;

public record AppointmentCreatedNotification(string FCM_Key) : INotification;