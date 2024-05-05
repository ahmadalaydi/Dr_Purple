using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;

public record AppointmentUpdatedNotification(string FCM_Key) : INotification;