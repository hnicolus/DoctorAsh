using DoctorAsh.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DoctorAsh.Permissions
{
    public class DoctorAshPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DoctorAshPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DoctorAshPermissions.MyPermission1, L("Permission:MyPermission1"));

            var appointmentPermission = myGroup.AddPermission(DoctorAshPermissions.Appointment.Default, L("Permission:Appointment"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.Create, L("Permission:Create"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.Update, L("Permission:Update"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.Delete, L("Permission:Delete"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.ViewOthers, L("Permission:ViewOthers"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.Cancel, L("Permission:Cancel"));
            appointmentPermission.AddChild(DoctorAshPermissions.Appointment.Reschedule, L("Permission:Reschedule"));

            var doctorPermission = myGroup.AddPermission(DoctorAshPermissions.Doctor.Default, L("Permission:Doctor"));
            doctorPermission.AddChild(DoctorAshPermissions.Doctor.Create, L("Permission:Create"));
            doctorPermission.AddChild(DoctorAshPermissions.Doctor.Update, L("Permission:Update"));
            doctorPermission.AddChild(DoctorAshPermissions.Doctor.Delete, L("Permission:Delete"));

            var patientPermission = myGroup.AddPermission(DoctorAshPermissions.Patient.Default, L("Permission:Patient"));
            patientPermission.AddChild(DoctorAshPermissions.Patient.Create, L("Permission:Create"));
            patientPermission.AddChild(DoctorAshPermissions.Patient.Update, L("Permission:Update"));
            patientPermission.AddChild(DoctorAshPermissions.Patient.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DoctorAshResource>(name);
        }
    }
}
